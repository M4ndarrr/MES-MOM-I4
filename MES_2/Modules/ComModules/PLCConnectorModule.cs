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
        public int MinPeriod { get; set; }
        public SQLRepository.SQLRepository databaze { get; set; }

        public EConnectionState EStateConnection { get; private set; }
        public EStateDiagram EStateDiagramState { get; private set; }

        #endregion

        #region Setup object

        public PlcConnectorModule(PLCConnectorModuleConfigure p_PlcModuleConfigure)
        {
            databaze = SQLRepository.SQLRepository.Instance;


            objClient = new S7Client();
            CommunicationObjects = new List<ComObject>();
            t = new Thread(new ThreadStart(StateDiagram)); // zde bude cela smyčka pro čtení
            PlcModuleConfigure = p_PlcModuleConfigure;
            t.Name = "PLCCommunication" + Id;
            t.Start();
            Configure();
        }

        public override void Run()
        {
            if (Connection() == 0)
            {
                EModuleState = BaseModuleEState.Running;
            }
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
                Stop();

// throw new ArgumentException(error.ToString());
                return 1;
            }
            else
            {
                EStateConnection = EConnectionState.Online;
                return 0;
            }
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
            Stop();
            objClient = null;

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

            //tohle musí být mimo v tom prostředí
            using (var db = new TestDatabaseEntities())
            {
                db.ComObjecTable.Add(new ComObjecTable()
                {
                    ID = instance.Id,
                    Status = (int)instance.EModuleState,
                    AreaMemory = instance.ObjectConfigure.AreaOfMemory,
                    StartOffSet = instance.ObjectConfigure.StartOffset,
                    Period = instance.ObjectConfigure.PeriodOfCheck,
                    ReadWrite = instance.ObjectConfigure.ERW,
                    DBnumber = instance.ObjectConfigure.DbNumber,
                    WorldLen = instance.ObjectConfigure.WorldLen,
                    IDPLC = Id
                });
                db.SaveChanges();
            }
            GetMinPeriod();
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
                    // zasilni dat databazy 
                    Console.WriteLine(temp.Data);
                    databaze.ListReceivedResult.Add(new ResultTable()
                        {
                            ResultData = temp.Data,
                            IDComObject = temp.IdComObj,
                            PLCStamp = temp.TimeStamp

                        }
                    );
                }
            }
        }

        public void WriteComObjects()
        {
        }

        public void StateDiagram()
        {
            while (true)
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

                Thread.Sleep(5000);
            }
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

            Thread.Sleep(MinPeriod);
            EStateDiagramState = EStateDiagram.Send;
        }

        private void StateDiagramRunPhaseSend()
        {
            lock (Lock)
            {
                WriteComObjects();
            }

            Thread.Sleep(MinPeriod);
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

        public void GetMinPeriod()
        {
            var item = CommunicationObjects
                .OrderBy(x => x.ObjectConfigure.PeriodOfCheck)
                .First();
            MinPeriod = item.ObjectConfigure.PeriodOfCheck;
        }


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
