//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-05
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : LoadPLCs.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-05
//  Change History: 
// ==================================
using MES_2.Modules.PLCConnectorModule;

namespace MES_2
{
    public class LoadPLCs
    {
        public void load () { 
        int index;
        PlcConnectorModule jednicka = PlcConnectorModuleRepository.Instance.Add
        (
            new PLCConnectorModuleConfigure()
            {
                IpString = "10.132.70.232",
                PortString = "102",
                Rack = 0,
                Slot = 1
            }
        );

            
    jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLInt, 0, 1000, 10, 2);
    jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLInt, 2, 100, 10, 2);
    jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLReal, 4, 1000, 10, 2);
    jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 64, 10000, 10, 2);
    jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLBit, 65, 100000, 10, 2);
    jednicka.AddComobject(S7Consts.S7AreaDB, S7Consts.S7WLReal, 8, 100000, 10, 2);
    }

    }

}