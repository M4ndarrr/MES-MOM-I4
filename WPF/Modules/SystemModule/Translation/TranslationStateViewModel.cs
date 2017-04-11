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
// ==================================
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MES_2.Modules.SystemModule.Translation;
using WPF.Helpers;
using WPF.Modules.Base;

namespace WPF.Modules.SystemModule.Translation
{
    public class TranslationStateViewModel : ViewModelBase
    {
        private TranslationRepository _repo = new TranslationRepository();
        private List<TranslationModel> _allTranslation;

        public TranslationStateViewModel(int p_entiti)
        {
            if (p_entiti != 0)
            {
                _allTranslation = _repo.RetrieveByEntityId(p_entiti).ToList();
            }
            else
            {
                _allTranslation = _repo.Retrieve().ToList();
            }

            AddTranslationCommand = new RelayCommand(OnAddTranslation);
            EditTranslationCommand =
                new RelayCommand<TranslationModel>(OnEditTranslation);

            Translations =
                new ObservableCollection<TranslationModel>(_allTranslation);
        }

        private ObservableCollection<TranslationModel> _translations;

        public ObservableCollection<TranslationModel> Translations
        {
            get { return _translations; }
            set { SetProperty(ref _translations, value); }
        }

        public RelayCommand AddTranslationCommand { get; private set; }

        public RelayCommand<TranslationModel> EditTranslationCommand { get; private set; }


        public event Action<TranslationModel> AddEditTranslationRequested =
            delegate { };


        private void OnAddTranslation()
        {
            AddEditTranslationRequested(null);
        }

        private void OnEditTranslation(TranslationModel p_translation)
        {
            AddEditTranslationRequested(p_translation);
        }
    }
}