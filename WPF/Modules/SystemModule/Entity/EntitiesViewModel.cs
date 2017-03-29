using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MES_2.DB.Database;
using MES_2.Modules.SystemModule.Entity;
using WPF.Helpers;
using WPF.Modules.Base;

namespace WPF.Modules.SystemModule.Entity
{
    class EntitiesViewModel : ViewModelBase
    {
        private EntitiesModel _repo = new EntitiesModel();
        private List<MES_2.Modules.SystemModule.Entity.Entity> _allEntities;

        public EntitiesViewModel()
        {
            //            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            //            EditCustomerCommand = new RelayCommand<MES_2.Modules.SystemModule.Entity.Entity>(OnEditUser);
            //            ClearSearchCommand = new RelayCommand(OnClearSearch);
            _repo.Add(null);
            _allEntities = _repo.Retrive().ToList();
            Entities = new ObservableCollection<MES_2.Modules.SystemModule.Entity.Entity>(_allEntities);

        }

        private ObservableCollection<MES_2.Modules.SystemModule.Entity.Entity> _entities;
        public ObservableCollection<MES_2.Modules.SystemModule.Entity.Entity> Entities
        {
            get { return _entities; }
            set { SetProperty(ref _entities, value); }
        }

//        private void FilterUsers(string searchInput)
//        {
//            if (string.IsNullOrWhiteSpace(searchInput))
//            {
//                Entities = new ObservableCollection<MES_2.Modules.SystemModule.Entity.Entity>(_allEntities);
//                return;
//            }
//            else
//            {
//                //   Users = new ObservableCollection<USR_UserList>(_allUsers.Where(c => c.FullName.ToLower().Contains(searchInput.ToLower())));
//            }
//        }

        public RelayCommand<MES_2.Modules.SystemModule.Entity.Entity> StatesOfItemCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }

        public event Action<int> StatesOfSelectRequested = delegate { };

        public void OnStateOfItem(MES_2.Modules.SystemModule.Entity.Entity p_item)
        {
            //Users = new ObservableCollection<USR_UserList>(_allUsers.Where(c => c.FullName.ToLower().Contains(searchInput.ToLower())));
            //StatesOfSelectRequested();
        }

    }
}
