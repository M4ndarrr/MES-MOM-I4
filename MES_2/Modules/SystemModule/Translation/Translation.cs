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
namespace MES_2.Modules.SystemModule.Translation
{
    public class Translation
    {
        public int ID_TRA { get; set; }
        public string NAME_ENT { get; set; }
        public int ID_STA_FROM { get; set; }
        public int ID_STA_TO { get; set; }
        public string Description { get; set; }
        public bool L_BLOCK { get; set; }
        public bool? L_VALID { get; set; }
    }
}