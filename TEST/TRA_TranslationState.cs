//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MES_2.DB.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRA_TranslationState
    {
        public int ID_TRA { get; set; }
        public string NAME_ENT { get; set; }
        public int ID_STA_FROM { get; set; }
        public int ID_STA_TO { get; set; }
        public string Description { get; set; }
        public bool L_BLOCK { get; set; }
        public Nullable<bool> L_VALID { get; set; }
    }
}