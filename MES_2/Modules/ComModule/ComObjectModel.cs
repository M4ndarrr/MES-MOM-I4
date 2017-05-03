//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-16
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : ComObjectModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-16
//  Change History: 
// 
// ==================================

using System;
using System.Collections.Generic;
using MES_2.DB.Tables;

namespace MES_2.Modules.ComModule
{
    public class ComObjectModel
    {
        public Guid ID_COM { get; set; }
        public Guid ID_PLC { get; set; }
        public int Status { get; set; }
        public int ReadWrite { get; set; }
        public int AreaMemory { get; set; }
        public int StartOffSet { get; set; }
        public int WorldLen { get; set; }
        public int DBnumber { get; set; }
        public int Period { get; set; }
        public string P_Created { get; set; }
        public string P_Modified { get; set; }
        public System.DateTime TimeCreated { get; set; }
        public System.DateTime TimeModified { get; set; }
    }

    public class ComObjectDetailModel : ComObjectModel
    {
        public virtual PLC_PLCConnector PLC_PLCConnector { get; set; }
        public virtual ICollection<RES_ResultTable> RES_ResultTable { get; set; }
    }

}