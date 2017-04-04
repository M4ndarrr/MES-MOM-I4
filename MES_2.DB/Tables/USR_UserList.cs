//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-03
//  ===============================
//  Namespace        : MES_2.DAL
//  Class                   : USR_UserList.cs
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
using System.ComponentModel.DataAnnotations.Schema;
using MES_2.DB.Tables.Base;

namespace MES_2.DB.Tables
{
    public class USR_UserList

    {
        public USR_UserList()
        {
        }
        [Key]
        public int ID_USR { get; set; }
        public int ID_STA { get; set; }
        public string LOGIN { get; set; }
        public string PASSWORD { get; set; }
        public string Title_before { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Title_after { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int? P_Created { get; set; }
        public int? P_Modified { get; set; }
        public System.DateTime? TimeCreated { get; set; }
        public System.DateTime? TimeModified { get; set; }
        public string PASSWORD_reset_token { get; set; }
        public System.DateTime? PASSWORD_reset_sent { get; set; }
        public int? Count_SignIN { get; set; }
        public System.DateTime? Current_SignIN { get; set; }
        public System.DateTime? Last_SignIN { get; set; }
        public string Current_SignIN_IP { get; set; }
        public string Last_SignIN_IP { get; set; }
    }
}