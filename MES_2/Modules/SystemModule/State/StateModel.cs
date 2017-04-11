//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-29
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : Entity.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-29
//  Change History: 
// 
// ==================================

using System;
using System.Collections.Generic;
using MES_2.DB.Tables;

namespace MES_2.Modules.SystemModule.State
{
    public class StateModel
    {
        public int ID_STA { get; set; }
        public int ID_ENT { get; set; }
        public string Purpous { get; set; }
        public bool? L_START_STATE { get; set; }
        public bool? L_END_STATE { get; set; }
        public bool? L_VALID { get; set; }
        public string Comments { get; set; }
    }

    public class StateDetailModel : StateModel  
    {
        public virtual ENT_Entity ENT_Entity { get; set; } = new ENT_Entity();
        public virtual ICollection<TRA_TranslationState> TRA_FROM { get; set; }
        public virtual ICollection<TRA_TranslationState> TRA_TO { get; set; }
    }
}