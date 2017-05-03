//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-03
//  ===============================
//  Namespace        : MES_2.DAL
//  Class                   : ResultTable.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-03
//  Change History: 
// ==================================
using System;
using System.ComponentModel.DataAnnotations;

namespace MES_2.DB.Tables
{
    public class RES_ResultTable
    {
        [Key]
        public int ID_RES { get; set; }

        public DateTime PLCStamp { get; set; }
        public Guid ID_COM { get; set; }
        public int ResultData { get; set; }


        public virtual COM_ComObject COM_Object { get; set; }
    }
}