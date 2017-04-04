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

namespace MES_2.DB.Tables
{
    public class ComObjectTable
    {
        public string ID { get; set; }
        public string IDPLC { get; set; }
        public int Status { get; set; }
        public int ReadWrite { get; set; }
        public int AreaMemory { get; set; }
        public int StartOffSet { get; set; }
        public int WorldLen { get; set; }
        public int DBnumber { get; set; }
        public int Period { get; set; }
        public string P_Created { get; set; }
        public string P_Modified { get; set; }
        public Nullable<System.DateTime> TimeCreated { get; set; }
        public Nullable<System.DateTime> TimeModified { get; set; }
    }
}