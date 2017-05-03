//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-20
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : ReceivedResult.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-20
//  Change History: 
// ==================================

using System;
using MES_2.DB.Tables;

namespace MES_2.Modules.ComModule
{
    public class ReceivedResult
    {

        public int ID_RES { get; set; }

        public DateTime PLCStamp { get; set; } = DateTime.Now;
        public Guid ID_COM { get; set; }
        public int ResultData { get; set; }

        public int ErrorNumber { get; set; } = 0;

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
//        public override string ToString()
//        {
//            return PLCStamp.ToString() + " - " + ErrorNumber.ToString() + " - " + PLCStamp.ToString();
//        }
    }

    public class ReceivedResultDetail : ReceivedResult
    {
        public virtual COM_ComObject COM_Object { get; set; }
    }

}