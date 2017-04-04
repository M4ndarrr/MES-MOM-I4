//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-29
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : AddEditUserManagementViewModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-29
//  Change History: 
// 
// ==================================

using System;
using MES_2.Modules.SystemModule.Translation;
using MES_2.Modules.UserManagement;
using WPF.Helpers;
using WPF.Modules.Base;
using WPF.Modules.UserManagement;

namespace WPF.Modules.SystemModule.Translation
{
    public class AddEditTranslationViewModel : ViewModelBase
    {

        private bool _isEditMode = true;
        public bool isEditMode
        {
            get { return _isEditMode; }
            set { SetProperty(ref _isEditMode, value); }
        }

        public AddEditTranslationViewModel(MES_2.Modules.SystemModule.Translation.Translation p_translation)
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
            SetTranslation(p_translation);
        }

        private TranslationFullEditable _Translation;
        public TranslationFullEditable Translation
        {
            get { return _Translation; }
            set { SetProperty(ref _Translation, value); }
        }

        private MES_2.Modules.SystemModule.Translation.Translation _edditingTranslation;

        public void SetTranslation(MES_2.Modules.SystemModule.Translation.Translation p_translation)
        {
            if (p_translation == null)
            {
                isEditMode = false;
                p_translation = new MES_2.Modules.SystemModule.Translation.Translation();
            }

            _edditingTranslation = p_translation;
            if (Translation != null) Translation.ErrorsChanged -= RaiseCanExecuteChanged;
            Translation = new TranslationFullEditable();
            Translation.ErrorsChanged += RaiseCanExecuteChanged;
            CopyTranslation(_edditingTranslation, Translation);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action<string> Done = delegate { };


        private void OnCancel()
        {
            Done(Translation.NAME_ENT);
        }

        private void OnSave()
        {
            UpdateCustomer(Translation, _edditingTranslation);
            if (isEditMode)
                TranslationModel.Instance.Edit(_edditingTranslation);
            else
                TranslationModel.Instance.Add(_edditingTranslation);
            Done(Translation.NAME_ENT);
        }

        private void UpdateCustomer(TranslationFullEditable source, MES_2.Modules.SystemModule.Translation.Translation target)
        {
//            target.NAME_ENT = source.NAME_ENT;
//            target.ID_STA_FROM = source.ID_STA_FROM;
//            target.ID_STA_TO = source.ID_STA_TO;
            target.Description = source.Description;
            target.L_BLOCK = source.L_BLOCK;
            target.L_VALID = source.L_VALID;
        }

        private bool CanSave()
        {
            return !Translation.HasErrors;
        }

        private void CopyTranslation(MES_2.Modules.SystemModule.Translation.Translation source, TranslationFullEditable target)
        {
            if (isEditMode)
            {
//                target.NAME_ENT = source.NAME_ENT;
//                target.ID_STA_FROM = source.ID_STA_FROM;
//                target.ID_STA_TO = source.ID_STA_TO;
                target.Description = source.Description;
                target.L_BLOCK = source.L_BLOCK;
                target.L_VALID = source.L_VALID;

            }
        }
    }
}