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
        private StatesRepository _repo = new StatesRepository();
        private List<StateModel> _allStates;

        public StateEntitiesViewModel(int p_entityId)
        {
            if (p_entityId != 0)
            {
                _allStates = _repo.RetrieveByEntityId(p_entityId).ToList();
            }
            else
            {
                _allStates = _repo.Retrieve().ToList();
            }

            AddStateCommand = new RelayCommand(OnAddState);
            EditStateCommand = new RelayCommand<StateModel>(OnEditState);
            TranslationCommand = new RelayCommand<StateModel>(OnTranslation);

            States = new ObservableCollection<StateModel>(_allStates);
        }

        private ObservableCollection<StateModel> _states;

        public ObservableCollection<StateModel> States
        {
            get { return _states; }
            set { SetProperty(ref _states, value); }
        }

        public RelayCommand<StateModel> TranslationCommand { get; private set; }
        public RelayCommand<StateModel> EditStateCommand { get; private set; }
        public RelayCommand AddStateCommand { get; private set; }

        public event Action<StateModel> AddEditStateRequested = delegate { };
        public event Action<int> TranslationRequested = delegate { };

        private void OnAddState()
        {
            AddEditStateRequested(null);
        }

        private void OnEditState(StateModel p_state)
        {
            AddEditStateRequested(p_state);
        }

        private void OnTranslation(StateModel p_state)
        {
            TranslationRequested(p_state.ID_ENT);
        }
    }
}