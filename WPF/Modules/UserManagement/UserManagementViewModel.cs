using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MES_2.Modules.UserManagement;
using WPF.Helpers;
using WPF.Modules.Base;

namespace WPF.Modules.UserManagement
{
    public class UserManagementViewModel : ViewModelBase
    {
        private UserRepository _repo = new UserRepository();
        private List<UserFull> _allUsers;

        public UserManagementViewModel()
        {
            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            EditCustomerCommand = new RelayCommand<UserFull>(OnEditUser);
            ClearSearchCommand = new RelayCommand(OnClearSearch);
            _allUsers = _repo.Retrieve().ToList();
            Users = new ObservableCollection<UserFull>(_allUsers);

        }

        private ObservableCollection<UserFull> _users;
        public ObservableCollection<UserFull> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }
        private string _SearchInput;
        public string SearchInput
        {
            get { return _SearchInput; }
            set
            {
                SetProperty(ref _SearchInput, value);
                FilterUsers(_SearchInput);
            }
        }

        private void FilterUsers(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Users = new ObservableCollection<UserFull>(_allUsers);
                return;
            }
            else
            {
             //   Users = new ObservableCollection<USR_UserList>(_allUsers.Where(c => c.FullName.ToLower().Contains(searchInput.ToLower())));
            }
        }

        public RelayCommand<UserFull> PlaceOrderCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand<UserFull> EditCustomerCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public event Action<Guid> PlaceOrderRequested = delegate { };
        public event Action<UserFull> AddUserRequested = delegate { };
        public event Action<UserFull> EditUserRequested = delegate { };
        private void OnAddCustomer()
        {
            AddUserRequested(new UserFull());

        }
        private void OnEditUser(UserFull user)
        {
            EditUserRequested(user);
        }

        private void OnClearSearch()
        {
            SearchInput = null;
        }
    }
}
