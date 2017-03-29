//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-10
//  ===============================
//  Namespace        : WPF
//  Class                   : AuthenticationViewModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-10
//  Change History: 
// 
// ==================================

using MES_2.Modules.UserManagement;
using WPF.Modules.Base;

namespace WPF.Modules.SystemModule.Authentication
{
    public class AuthenticationViewModel : ViewModelBase
    {


        public AuthenticationViewModel()
        {
            CurrentUser = new User ();
        }

        // singleton lazy learning 
        private static AuthenticationViewModel instance;

        public static AuthenticationViewModel Instance
        {
            get
            {
                if (instance == null) instance = new AuthenticationViewModel();
                return instance;
            }
        }

        private bool _IsAuthenticated;
        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set
            {
                if (value != _IsAuthenticated)
                {
                    _IsAuthenticated = value;
                    RaisePropertyChanged("IsAuthenticated");
                    RaisePropertyChanged("IsNotAuthenticated");
                }
            }
        }

        public bool IsNotAuthenticated
        {
            get
            {
                return !IsAuthenticated;
            }
        }

        public bool CanDoAuthenticated()
        {
            return IsAuthenticated;
        }

        private User _CurrentUser;
        public User CurrentUser
        {
            get { return _CurrentUser; }
            set

            {
                if (value != _CurrentUser)
                {
                    _CurrentUser = value;
                    RaisePropertyChanged("CurrentUser");
                }
            }
        }

        public bool Authenticate()
        {
            IsAuthenticated = MES_2.Modules.Authetication.Authentication.Authenticate(CurrentUser);
            return IsAuthenticated;
        }
//        public bool Authenticate(string UserName, string Password)
//        {
//            IsAuthenticated = WPF.Model.Authentication.Authenticate(UserName, Password);
//            return IsAuthenticated;
//        }

        public bool Authenticate(User p_user)
        {
            IsAuthenticated = MES_2.Modules.Authetication.Authentication.Authenticate(p_user);
            return IsAuthenticated;
        }

        public void LogOff()
        {
            IsAuthenticated = false;
        }
    }
}