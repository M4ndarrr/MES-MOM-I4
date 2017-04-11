//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-03
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : TranslationFullEditable.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-03
//  Change History: 
// 
// ==================================

using System.ComponentModel.DataAnnotations;
using WPF.Helpers;

namespace WPF.Modules.SystemModule.Translation
{
    public class TranslationFullEditable : ValidatableBindableBase
    {
        private string _NAME_ENT;
        [Required]
        public string NAME_ENT
        {
            get { return _NAME_ENT; }
            set { SetProperty(ref _NAME_ENT, value); }
        }

        private int _ID_ENT;
        [Required]
        public int ID_ENT
        {
            get { return _ID_ENT; }
            set { SetProperty(ref _ID_ENT, value); }
        }

        private int _ID_STA_FROM;
        [Required]
        public int ID_STA_FROM
        {
            get { return _ID_STA_FROM; }
            set { SetProperty(ref _ID_STA_FROM, value); }
        }

        private int _ID_STA_TO;
        [Required]
        public int ID_STA_TO
        {
            get { return _ID_STA_TO; }
            set { SetProperty(ref _ID_STA_TO, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        private bool? _L_BLOCK;
        public bool? L_BLOCK
        {
            get { return _L_BLOCK; }
            set { SetProperty(ref _L_BLOCK, value); }
        }

        private bool? _L_VALID;
        public bool? L_VALID
        {
            get { return _L_VALID; }
            set { SetProperty(ref _L_VALID, value); }
        }


    }
}