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

using System.Collections.Generic;
using MES_2.DB.Tables;

namespace MES_2.Modules.SystemModule.Entity
{
    public class EntityModel
    {
        public int ID_ENT { get; set; }
        public string NAME_ENT { get; set; }
        public int? State { get; set; }
        public bool? VALID { get; set; }
    }
    public class EntityDetailModel : EntityModel
    {
        public virtual ICollection<STA_StateList> STA_StateList { get; set; }
        public virtual ICollection<TRA_TranslationState> TRA_TranslationState { get; set; }
    }
}

