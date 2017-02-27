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

namespace MES_application.Modules.CommunicationModule
{
    public class ReceivedResult
    {
        public int Data { get; set; }
        public int ErrorNumber { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string IdPLC { get; set; } // nebude potreba, dle 
        public string IdComObj { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return TimeStamp.ToString() + " - " + ErrorNumber.ToString() + " - " + Data.ToString();
        }
    }
}