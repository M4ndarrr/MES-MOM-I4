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

namespace MES_2.Modules.SystemModule.Translation
{
    public class Translation
    {
        public int ID_TRA { get; set; }
        public string NAME_ENT { get; set; }
        public int ID_STA_PICA_FROM { get; set; }
        public int ID_STA_PICA_TO { get; set; }
        public string Description { get; set; }
        public bool? L_BLOCK { get; set; }
        public bool? L_VALID { get; set; }
    }
}