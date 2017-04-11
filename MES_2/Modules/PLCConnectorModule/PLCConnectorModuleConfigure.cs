//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-24
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : PLCConnectorModuleConfigure.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-24
//  Change History: 
// ==================================

using System;

namespace MES_2.Modules.PLCConnectorModule
{
    public class PLCConnectorModuleConfigure
    {
        public Guid Id { get; private set; } = Utils.Utils.generateID();
        public int Rack { get; set; }
        public int Slot { get; set; }
        public string IpString { get; set; }
        public string PortString { get; set; }
    }
}