using System;
using MES_2.Modules.UserManagement;
using WPF.Helpers;
using WPF.Modules.Base;
using WPF.Modules.SystemModule.Authentication;

namespace WPF.Modules.UserManagement
{
    public class ProfileUserViewModel : ViewModelBase
    {
        public event Action<string> StateViewRequested = delegate { };
        public event Action<UserFull> AddEditUserRequested = delegate { };

        public RelayCommand OnStateViewCommand { get; set; }
        public RelayCommand OnEditCommand { get; set; }

        private UserFull _UserInformation = new UserFull();

        public UserFull UserInformation
        {
            get { return _UserInformation; }
            set { SetProperty(ref _UserInformation, value); }
        }

        private bool _EditMode;

        public ProfileUserViewModel()
        {
            OnStateViewCommand = new RelayCommand(DoStatesViewRequested);
            OnEditCommand = new RelayCommand(DoEditRequested);



            if (ProfileModel.Instance.GetInformation(AuthenticationViewModel.Instance.CurrentUser.ID))
            {
                UserInformation = ProfileModel.Instance.ProfileFull;
            }
        }
        public void DoStatesViewRequested ()
        {
            StateViewRequested("USR_UserList");

        }

        public void DoEditRequested()
        {
            //tady se zobrazí dialog napárování commandů SAVE/CANCEL

            AddEditUserRequested(UserInformation);
        }

        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        
    }
}
