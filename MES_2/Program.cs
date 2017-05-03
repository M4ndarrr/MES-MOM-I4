using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MES_2.Modules.ComModule;
using MES_2.Modules.PLCConnectorModule;
using MES_2.Modules.SystemModule.Entity;
using MES_2.Modules.SystemModule.State;
using MES_2.Utils;

namespace MES_2
{
    class Program
    {
        static void Main(string[] args)
        {
//            int index;
//            AutoMapperConfig.RegisterMappings();
//
//            //AddRanom result
//            var Cas = new DateTime();
//            Cas = DateTime.Now;
//            var Random = new Random();
//            for (int i = 0; i < 1000; i++)
//            {
//                ReceivedResultRepository.Instance.Add(new ReceivedResult()
//                {
//                    ErrorNumber = 0,
//                    ID_COM = new Guid("eebe6be4-b9ed-4a19-b3b1-04d25825e5c6"),
//                    PLCStamp = Cas.AddMinutes(i),
//                    ResultData = Random.Next(1, 1000)
//
//                });
//            }

//                        PlcConnectorModule jednicka = new PlcConnectorModule("10.132.70.232", 0, 1);
//            
//                        Console.WriteLine(jednicka.Id);
//                        //Console.WriteLine(jednicka.test());
//                        //start je dle bytu nebo BITU
//                        // index = jednicka.addcomobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 0, 0, 10);
//                        // index = jednicka.addcomobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 1, 0, 10);
//            
//                    
//                        index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLInt, 0, 10, 10);
//                        index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLInt, 2, 100, 10);
//                        index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLReal, 4, 1000, 10);
//                        index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 64, 10000, 10);
//                        index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 65, 100000, 10);
//                        index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLReal, 8, 100000, 10);

            //            PlcConnectorModule jednicka = PlcConnectorModuleRepository.Instance.Add
            //                (
            //                new PLCConnectorModuleConfigure()
            //                    {
            //                        //IpString = "10.132.70.232",
            //                        IpString = "172.20.192.41",
            //                        PortString = "102",
            //                        Rack = 0,
            //                        Slot = 1
            //                    }
            //            );

            //            PlcConnectorModule dvojka = PlcConnectorModuleRepository.Instance.Add
            //    (
            //    new PLCConnectorModuleConfigure()
            //    {
            //                     IpString = "10.132.70.232",
            //                    //IpString = "172.20.192.41",
            //        PortString = "102",
            //        Rack = 0,
            //        Slot = 1
            //    }
            //);
            //
            //            index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLInt, 0, 1000, 20,2);
            //            index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLInt, 2, 100, 20,2);
            //            index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLReal, 4, 1000, 20,2);
            //            index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 64, 10000, 20,2);
            //            index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 65, 100000, 20,2);
            //            index = jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLReal, 8, 100000, 20,2);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLInt, 0, 1000, 10,2);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLInt, 2, 100, 10,2);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLReal, 4, 1000, 10,2);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 64, 10000, 10,2);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 65, 100000, 10,2);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLReal, 8, 100000, 10,2);



            //PlcConnectorModuleRepository.Instance.Delete(jednicka);

            // jednicka.CommunicationObjects[0].WriteBufferData = new byte[];

            //            jednicka.CommunicationObjects[0].WriteData = 80;
            //            jednicka.CommunicationObjects[0].WriteSuccessful = false;
            //                PlcConnectorModule dvojka = PlcConnectorModuleRepository.Instance.Add
            //                (
            //                new PLCConnectorModuleConfigure()
            //                {
            //                    IpString = "10.132.70.232",
            //                    PortString = "103",
            //                    Rack = 0,
            //                    Slot = 1
            //                }
            //            );
            //
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLInt, 0, 10, 10);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLInt, 2, 100, 10);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLReal, 4, 1000, 10);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 64, 10000, 10);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 65, 100000, 10);
            //            index = dvojka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLReal, 8, 100000, 10);

            while (true)
            {
                Thread.Sleep(Timeout.Infinite);
            }



        }
    }
}
