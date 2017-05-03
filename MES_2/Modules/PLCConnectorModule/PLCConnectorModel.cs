//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-15
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : PLCConnectorModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-15
//  Change History: 
// 
// ==================================

using System;
using System.Collections.Generic;
using MES_2.DB.Tables;

namespace MES_2.Modules.PLCConnectorModule
{
    public class PLCConnectorModel
    {
        public Guid ID_PLC { get; set; }
        public int Status { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public int Slot { get; set; }
        public int Rack { get; set; }
        public string P_Created { get; set; }
        public string P_Modified { get; set; }
        public System.DateTime TimeCreated { get; set; }
        public System.DateTime TimeModified { get; set; }
    }

    public class PLCConnectorDetailModel : PLCConnectorModel
    {
        public virtual ICollection<COM_ComObject> COM_ComObject { get; set; }
    }

}