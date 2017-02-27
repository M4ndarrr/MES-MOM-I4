//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-01-28
//  ===============================
//  Namespace        : MES_application
//  Class                   : PLCConnectorModule.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-17
//  Change History: 
// ==================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using MES_2.Common;
using MES_2.Database;
using MES_application.Utils;
using Sharp7;

namespace MES_application.Modules.CommunicationModule
{
    public class PlcConnectorModule : BaseModule, ILoggable
    {
        #region Values and Property

        private const string _VERSION = "0.0.1"; // verze modulů
        private static readonly object Lock = new object();
        private static List<bool> UsedCounter = new List<bool>();
        private Thread t;

        public enum EConnectionState
        {
            Offline,
            Connecting,
            Online
        }
        public enum EStateDiagram
        {
            Init,
            Read,
            Send,
            Wait,
            Alarm,
            Disconnect
        }

        public enum ETypePLC
        {
        }

        public List<ComObject> CommunicationObjects { get; set; }

        public S7Client objClient; // { get; set; }
        public int AlarmCounter { get; private set; }
        public PLCConnectorModuleConfigure PlcModuleConfigure { get; set; }
        public EConnectionState EStateConnection { get; private set; }
        public EStateDiagram EStateDiagramState { get; private set; }
        #endregion

        #region Setup object

        public PlcConnectorModule(PLCConnectorModuleConfigure p_PlcModuleConfigure)
        {
            objClient = new S7Client();
            CommunicationObjects = new List<ComObject>();
            t = new Thread(new ThreadStart(StateDiagram)); // zde bude cela smyčka pro čtení
            PlcModuleConfigure = p_PlcModuleConfigure;
           
            Configure();

            t.Name = "PLCCommunication" + PlcModuleConfigure.Id;
            t.Start();
        }

        public override void Run()
        {
            Connection();
            EModuleState = BaseModuleEState.Running;
        }

        public override void Restart()
        {
            Disconnect();
            Thread.Sleep(250);
            Connection();
        }

        public override void Stop()
        {
            Disconnect();
            EModuleState = BaseModuleEState.Stopped;
        }

        private int Connection()
        {
            int error;
            EStateConnection = EConnectionState.Connecting;
            error = objClient.ConnectTo(PlcModuleConfigure.IpString, PlcModuleConfigure.Rack, PlcModuleConfigure.Slot);
            if (error != 0)
            {
                // objClient = null;
                LoggingService.Log(this, "asd");
                throw new ArgumentException(error.ToString());
            }

            EStateConnection = EConnectionState.Online;
            return 0;
        }

        private void Disconnect()
        {
            EStateConnection = EConnectionState.Offline;
            objClient.Disconnect();
        }

        public void Configure()
        {
            AlarmCounter = 10;
        }

        public void Delete()
        {
            // nutné přidat všechny pod moduly
            Disconnect();
            objClient = null;


// Dispose();
            CommunicationObjects.Clear();
            t.Abort();
        }

        #endregion

        #region Add/Dell Read/Write ComObject

        // bude použito ve vyšší třídě
        public int AddComobject(int p_area, int p_wordLen, int p_start, int p_iPeriod, int p_iDbNumber = 1,
            int p_rw = 0)
        {
            var tempConfiguration = new ComObjectConfigure()
            {
                AreaOfMemory = p_area,
                WorldLen = p_wordLen,
                StartOffset = p_start,
                PeriodOfCheck = p_iPeriod,
                DbNumber = p_iDbNumber,
                ERW = p_rw
            };
            var instance = ComObjectRepository.Instance.Add(tempConfiguration);
            CommunicationObjects.Add(instance);
            instance.StateChanged += OnChangeState;
            return 0;
        }

        public void Deletecomobject(int p_iId)
        {
            CommunicationObjects.RemoveAt(p_iId);
        }

        public void ReadComObjects()
        {
            ReceivedResult temp;
            foreach (var tempComObj in CommunicationObjects)
            {
                temp = tempComObj?.ReadWriteCycle(objClient);
                if (temp != null)
                {
                    Random jo = new Random();
                    using (var db = new TestDatabaseEntities())
                    {
                        db.Table1.Add(new Table1
                        {
                           ID = jo.Next(Int32.MaxValue),
                           ComDevice = tempComObj.ObjectConfigure.Id,
                           Value = temp.Data
                        });
                        db.SaveChanges();
                    }

                    Console.WriteLine(temp.Data);
                }
            }
        }

        public void WriteComObjects()
        {

        }

        public void StateDiagram()
        {
            while (this.EModuleState != BaseModuleEState.Stopped)
            {
                // komunikace je sledována na nejnižšší úrovniC
                if (this.EModuleState == BaseModuleEState.Starting)
                    Run();

                if (this.EModuleState == BaseModuleEState.Running)
                {
                    StateDiagramRunPhase();
                }
            }

            Thread.Sleep(10000);
        }

        private void StateDiagramRunPhase()
        {
            switch (EStateDiagramState)
            {
                case EStateDiagram.Init:
                    StateDiagramRunPhaseInit();
                    break;
                case EStateDiagram.Send:
                    StateDiagramRunPhaseSend();
                    break;
                case EStateDiagram.Read:
                    StateDiagramRunPhaseRead();
                    break;
                case EStateDiagram.Alarm:

                    // iStateDiagram =
                    break;
                case EStateDiagram.Wait:

                    // iStateDiagram
                    break;

                case EStateDiagram.Disconnect:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void StateDiagramRunPhaseRead()
        {
            lock (Lock)
            {
                ReadComObjects();
            }

            Thread.Sleep(100);
            EStateDiagramState = EStateDiagram.Send;
        }

        private void StateDiagramRunPhaseSend()
        {
            lock (Lock)
            {
                WriteComObjects();
                Thread.Sleep(100);
            }


// await Task.Delay(100);
            EStateDiagramState = EStateDiagram.Read;
        }

        private void StateDiagramRunPhaseInit()
        {
            if (EStateConnection == EConnectionState.Offline)
            {
                Connection(); // navrat INT pokud je hodnota rovna se error komunikace
                Thread.Sleep(1000);
                return;
            }

            EStateDiagramState = EStateDiagram.Send;
        }

        #endregion

        #region Servicies

        public override string Version()
        {
            return _VERSION;
        }

        public static void OnChangeState(object p_sender, ModuleStateChangedEventArgs p_args)
        {
            Console.WriteLine($"{p_args.EStateNOW} a {p_args.EStatePrev}");
        }
        public override bool Validate()
        {
            return false;
        }
        public string Log()
        {
            return null;
        }

        #endregion
    }
}