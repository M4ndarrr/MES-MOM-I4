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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MES_2.DB.Tables
{
    public class PLC_PLCConnector
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public PLC_PLCConnector()
        {
            this.COM_ComObject = new HashSet<COM_ComObject>();
        }
        [Key]
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

        public virtual ICollection<COM_ComObject> COM_ComObject { get; set; }
    }
}