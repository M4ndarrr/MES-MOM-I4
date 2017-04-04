using System;
using MES_2.Modules.UserManagement;
using WPF.Helpers;
using WPF.Modules.Base;
using WPF.Modules.SystemModule.Authentication;

namespace WPF.Modules.SystemModule.Login
{
    public class LoginControlViewModel : ViewModelBase
    {
        public RelayCommand LoginCommand { get; set; }
        private bool _isNotLoginSuccesFull = false;
        public bool isNotLoginSuccesFull
        {
            get { return _isNotLoginSuccesFull; }
            set
            {
                SetProperty(ref _isNotLoginSuccesFull, value);
            }
        }
        private User _CurrentUser;
        public User CurrentUser
        {
            get { return _CurrentUser; }
            set
            {
                SetProperty(ref _CurrentUser, value);
            }
        }

        public event Action SuccesFullLogin = delegate { };


        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public LoginControlViewModel()
        {
            CurrentUser = new User();
            LoginCommand = new RelayCommand(DoLogin);
        }

        private void DoLogin()
        {
            if (AuthenticationViewModel.Instance.Authenticate(CurrentUser))
            {
                AuthenticationViewModel.Instance.CurrentUser = CurrentUser;
                SuccesFullLogin();
            }
            else
            {
                isNotLoginSuccesFull = true;
                // pokud ne  změna pole username or password je špatně - musi vyskočit hláška
            }

        }



    }
}
