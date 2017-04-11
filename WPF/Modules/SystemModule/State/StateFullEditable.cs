//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-02
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : StateFullEditable.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-02
//  Change History: 
// 
// ==================================

using System.ComponentModel.DataAnnotations;
using WPF.Helpers;


namespace WPF.Modules.SystemModule.State
{
    public class StateFullEditable : ValidatableBindableBase
    {


        //choose from combo box or 
        private int _ID_ENT;
        [Required]
        public int ID_ENT
        {
            get { return _ID_ENT; }
            set { SetProperty(ref _ID_ENT, value);  } // pri zmene tohoto se musi aktualizovat 
        }


        private string _NAME_ENT;
        [Required]
        public string NAME_ENT
        {
            get { return _NAME_ENT; }
            set { SetProperty(ref _NAME_ENT, value); } // pri zmene tohoto se musi aktualizovat 
        }

        private string _Purpous;
        [Required]
        public string Purpous
        {
            get { return _Purpous; }
            set { SetProperty(ref _Purpous, value); }
        }

        private bool? _L_START_STATE;
        public bool? L_START_STATE
        {
            get { return _L_START_STATE; }
            set { SetProperty(ref _L_START_STATE, value); }
        }

        private bool? _L_END_STATE;
        public bool? L_END_STATE
        {
            get { return _L_END_STATE; }
            set { SetProperty(ref _L_END_STATE, value); }
        }

        private bool? _L_VALID;
        public bool? L_VALID
        {
            get { return _L_VALID; }
            set { SetProperty(ref _L_VALID, value); }
        }

        private string _Comments;
        public string Comments
        {
            get { return _Comments; }
            set { SetProperty(ref _Comments, value); }
        }
    }
}