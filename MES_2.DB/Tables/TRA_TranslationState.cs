//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-03
//  ===============================
//  Namespace        : MES_2.DAL
//  Class                   : TRA_TranslationState.cs
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
    public class TRA_TranslationState
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public TRA_TranslationState()
        {
        }

        [Key]
        public int ID_TRA { get; set; }
        public string NAME_ENT { get; set; }
        public int ID_STA_PICA_FROM { get; set; }
        public int ID_STA_PICA_TO { get; set; }

        public string Description { get; set; }
        public bool? L_BLOCK { get; set; }
        public bool? L_VALID { get; set; }

        public virtual STA_StateList STATE_FROM { get; set; }
        public virtual STA_StateList STATE_TO { get; set; }
    }
}