//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-29
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : TranslationStateViewModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-29
//  Change History: 
// 
// ==================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MES_2.Modules.SystemModule.Translation;
using WPF.Helpers;
using WPF.Modules.Base;

namespace WPF.Modules.SystemModule.Translation
{
    public class TranslationStateViewModel : ViewModelBase
    {
        private TranslationModel _repo = new TranslationModel();
        private List<MES_2.Modules.SystemModule.Translation.Translation> _allTranslation;

        public TranslationStateViewModel(string p_entityName)
        {
            if (p_entityName != null)
            {
                _allTranslation = _repo.RetrieveByEntityName(p_entityName).ToList();
            }
            else
            {
                _allTranslation = _repo.Retrieve().ToList();
            }

            AddTranslationCommand = new RelayCommand(OnAddTranslation);
            EditTranslationCommand = new RelayCommand<MES_2.Modules.SystemModule.Translation.Translation>(OnEditTranslation);

            Translations = new ObservableCollection<MES_2.Modules.SystemModule.Translation.Translation>(_allTranslation);

        }

        private ObservableCollection<MES_2.Modules.SystemModule.Translation.Translation> _translations;
        public ObservableCollection<MES_2.Modules.SystemModule.Translation.Translation> Translations
        {
            get { return _translations; }
            set { SetProperty(ref _translations, value); }
        }

        public RelayCommand AddTranslationCommand { get; private set; }
        public RelayCommand<MES_2.Modules.SystemModule.Translation.Translation> EditTranslationCommand { get; private set; }


        public event Action<MES_2.Modules.SystemModule.Translation.Translation> AddEditTranslationRequested = delegate { };


        private void OnAddTranslation()
        {
            AddEditTranslationRequested(null);
        }

        private void OnEditTranslation(MES_2.Modules.SystemModule.Translation.Translation p_translation)
        {
            AddEditTranslationRequested(p_translation);
        }



    }
}