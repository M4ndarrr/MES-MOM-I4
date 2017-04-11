//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-03
//  ===============================
//  Namespace        : MES_2.DAL
//  Class                   : STA_StateList.cs
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
    public class STA_StateList
    {

        public STA_StateList()
        {
            this.TRA_FROM = new HashSet<TRA_TranslationState>();
            this.TRA_TO = new HashSet<TRA_TranslationState>();
        }

        [Key]
        public int ID_STA { get; set; }

        public int ID_ENT { get; set; }
       // public string NAME_ENT { get; set; }
        
        public string Purpous { get; set; }
        public bool? L_START_STATE { get; set; }
        public bool? L_END_STATE { get; set; }
        public bool? L_VALID { get; set; }
        public string Comments { get; set; }

        public virtual ENT_Entity ENT_Entity { get; set; }
        public virtual ICollection<TRA_TranslationState> TRA_FROM { get; set; }
        public virtual ICollection<TRA_TranslationState> TRA_TO { get; set; }
    }
}