//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-29
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : UserFullEditable.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-29
//  Change History: 
// ==================================

using System.ComponentModel.DataAnnotations;
using WPF.Helpers;

namespace WPF.Modules.SystemModule.Entity
{
    public class EntityFullEditable : ValidatableBindableBase
    {

        private string _NAME_ENT;

        [Required]
        public string NAME_ENT
        {
            get { return _NAME_ENT; }
            set { SetProperty(ref _NAME_ENT, value); }
        }

        private int? _State;

        public int? State
        {
            get { return _State; }
            set { SetProperty(ref _State, value); }
        }

        private bool? _VALID;
       // private bool? _test;

        public bool? VALID
        {
            get { return _VALID; }
            set { SetProperty(ref _VALID, value); }
        }
        
    }
}