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

        private StatesModel _repo = new StatesModel();
        private List<MES_2.Modules.SystemModule.State.State> _allStates;

        public StateEntitiesViewModel()
        {
            //            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            //            EditCustomerCommand = new RelayCommand<ENT_Entity>(OnEditUser);
            //            ClearSearchCommand = new RelayCommand(OnClearSearch);
            _repo.Add(null);
            _allStates = _repo.Retrive().ToList();
            States = new ObservableCollection<MES_2.Modules.SystemModule.State.State>(_allStates);

        }

        private ObservableCollection<MES_2.Modules.SystemModule.State.State> _states;
        public ObservableCollection<MES_2.Modules.SystemModule.State.State> States
        {
            get { return _states; }
            set { SetProperty(ref _states, value); }
        }

        //        private void FilterUsers(string searchInput)
        //        {
        //            if (string.IsNullOrWhiteSpace(searchInput))
        //            {
        //                Entities = new ObservableCollection<ENT_Entity>(_allEntities);
        //                return;
        //            }
        //            else
        //            {
        //                //   Users = new ObservableCollection<USR_UserList>(_allUsers.Where(c => c.FullName.ToLower().Contains(searchInput.ToLower())));
        //            }
        //        }

        public RelayCommand<MES_2.Modules.SystemModule.State.State> StatesOfItemCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }

        public event Action<int> StatesOfSelectRequested = delegate { };

        public void OnStateOfItem(MES_2.Modules.SystemModule.State.State p_item)
        {
            //Users = new ObservableCollection<USR_UserList>(_allUsers.Where(c => c.FullName.ToLower().Contains(searchInput.ToLower())));
            //StatesOfSelectRequested();
        }

    }
}
