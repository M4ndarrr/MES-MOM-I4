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

namespace MES_2.Modules.SystemModule.State
{
    public class State
    {
        public int ID_STA { get; set; }
        public string Name_Entity { get; set; }
        public int? ID_State { get; set; }
        public string Purpous { get; set; }
        public bool? L_START_STATE { get; set; }
        public bool? L_END_STATE { get; set; }
        public bool? L_VALID { get; set; }
        public string Comments { get; set; }
    }
}