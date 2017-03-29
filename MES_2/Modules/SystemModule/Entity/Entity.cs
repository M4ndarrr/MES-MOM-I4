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
namespace MES_2.Modules.SystemModule.Entity
{
    public class Entity
    {
        public int ID_ENT { get; set; }
        public string NAME_ENT { get; set; }
        public int? State { get; set; }
        public bool? VALID { get; set; }
    }
}