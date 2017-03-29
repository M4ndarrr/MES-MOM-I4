using System;
using MES_2.Modules.UserManagement;
using WPF.Helpers;
using WPF.Modules.Base;
using WPF.Modules.SystemModule.Authentication;

namespace WPF.Modules.UserManagement
{
    public class ProfileUserViewModel : ViewModelBase
    {
        public event Action<string> StateViewRequest = delegate { };
        public event Action EditViewRequest = delegate { };

        public RelayCommand<string> OnStateViewCommand { get; set; }

        private UserFull _UserInformation = new UserFull();

        public UserFull UserInformation
        {
            get { return _UserInformation; }
            set { SetProperty(ref _UserInformation, value); }
        }

        private bool _EditMode;

        public ProfileUserViewModel()
        {
            OnStateViewCommand = new RelayCommand<string>(DoStatesView);
                
            if (ProfileModel.GetInformation(AuthenticationViewModel.Instance.CurrentUser.ID))
            {
                UserInformation = ProfileModel.ProfileFull;
            }
        }
        public void DoStatesView (string p_text)
        {
            StateViewRequest(p_text);

        }

        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        
    }
}
