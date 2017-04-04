//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-03
//  ===============================
//  Namespace        : MES_2.DAL
//  Class                   : PLCTable.cs
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
    public class PLCTable
    {
        public string ID { get; set; }
        public int Status { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public int Slot { get; set; }
        public int Rack { get; set; }
        public string P_Created { get; set; }
        public string P_Modified { get; set; }
        public Nullable<System.DateTime> TimeCreated { get; set; }
        public Nullable<System.DateTime> TimeModified { get; set; }
    }
}