//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-03
//  ===============================
//  Namespace        : MES_2.DAL
//  Class                   : ComObjectTable.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-03
//  Change History: 
// 
// ==================================

using System;
using System.ComponentModel.DataAnnotations;

namespace MES_2.DB.Tables
{
    public class COM_ComObject
    {

        [Key]
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

        public virtual PLC_PLCConnector PLC_PLCConnector { get; set; }

    }
}