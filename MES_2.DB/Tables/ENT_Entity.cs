//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-03
//  ===============================
//  Namespace        : MES_2.DAL
//  Class                   : ENT_Entity.cs
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
using MES_2.DB.Tables.Base;

namespace MES_2.DB.Tables
{
    public class ENT_Entity
    {
        public ENT_Entity()
        {
            this.STA_StateList = new HashSet<STA_StateList>();
            this.TRA_TranslationState = new HashSet<TRA_TranslationState>();
        }

        [Key]
        public int ID_ENT { get; set; }
        [Required]
        public string NAME_ENT { get; set; }
        public int? State { get; set; }
        public bool? VALID { get; set; }
        public virtual ICollection<STA_StateList> STA_StateList { get; set; }
        public virtual ICollection<TRA_TranslationState> TRA_TranslationState { get; set; }
    }
}