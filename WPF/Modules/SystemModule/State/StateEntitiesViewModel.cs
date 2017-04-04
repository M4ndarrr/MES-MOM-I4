using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MES_2.DB.Database;
using MES_2.Modules.SystemModule.State;
using WPF.Helpers;
using WPF.Modules.Base;

namespace WPF.Modules.SystemModule.State
{
    class StateEntitiesViewModel : ViewModelBase
    {
        private string EntityName { get; set; }
        private StatesModel _repo = new StatesModel();
        private List<MES_2.Modules.SystemModule.State.State> _allStates;

        public StateEntitiesViewModel(string p_entityName)
        {
            if (p_entityName != null)
            {
                _allStates = _repo.RetrieveByEntityName(p_entityName).ToList();
            }
            else
            {
                _allStates = _repo.Retrieve().ToList();
            }

            AddStateCommand = new RelayCommand(OnAddState);
            EditStateCommand = new RelayCommand<MES_2.Modules.SystemModule.State.State>(OnEditState);
            TranslationCommand = new RelayCommand<MES_2.Modules.SystemModule.State.State>(OnTranslation);
            
            States = new ObservableCollection<MES_2.Modules.SystemModule.State.State>(_allStates);

        }

        private ObservableCollection<MES_2.Modules.SystemModule.State.State> _states;
        public ObservableCollection<MES_2.Modules.SystemModule.State.State> States
        {
            get { return _states; }
            set { SetProperty(ref _states, value); }
        }
        public RelayCommand<MES_2.Modules.SystemModule.State.State> TranslationCommand { get; private set; }
        public RelayCommand<MES_2.Modules.SystemModule.State.State> EditStateCommand { get; private set; }
        public RelayCommand AddStateCommand { get; private set; }

        public event Action<MES_2.Modules.SystemModule.State.State> AddEditStateRequested = delegate { };
        public event Action<string> TranslationRequested = delegate { };

        private void OnAddState()
        {
            AddEditStateRequested(null);
        }

        private void OnEditState(MES_2.Modules.SystemModule.State.State p_state)
        {
            AddEditStateRequested(p_state);
        }

        private void OnTranslation(MES_2.Modules.SystemModule.State.State p_state)
        {
          TranslationRequested(p_state.NAME_ENT);
        }
    }
}
