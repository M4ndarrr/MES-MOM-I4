//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-10
//  ===============================
//  Namespace        : WPF
//  Class                   : MainViewModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-10
//  Change History: 
// 
// ==================================

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.Helpers;
using WPF.Model;
using WPF.Modules.Base;
using WPF.Modules.SystemModule.Authentication;

namespace WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
       // public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }
        public RelayCommand NewControlCommand { get; set; }
        public RelayCommand NewWindowCommand { get; set; }
        public RelayCommand NewControl2Command { get; set; }

        public AuthenticationViewModel AuthVM { get; set; }
        
        private FrameworkElement _SubView;
        public FrameworkElement SubView
        {
            get { return _SubView; }
            set
            {
                if (value != _SubView)
                {
                    _SubView = value;
                    RaisePropertyChanged("SubView");
                }
            }
        }

        private double _InputValue;
        public double InputValue
        {
            get { return _InputValue; }
            set
            {
                if (value != _InputValue)
                {
                    _InputValue = value;
                    RaisePropertyChanged("InputValue");
                }
            }
        }

        public List<MyMenuItem> TheMenu { get; set; }

        public MainViewModel(Border Stage)
        {
            AuthVM = new AuthenticationViewModel();

            LoginCommand = new RelayCommand(DoLogin);
            LogoutCommand = new RelayCommand(DoLogout, AuthVM.CanDoAuthenticated);
            NewControlCommand = new RelayCommand(DoNewControl, CanDoNewControl);
            NewWindowCommand = new RelayCommand(DoNewWindow, CanDoNewWindow);
            NewControl2Command = new RelayCommand(DoNewControl2, CanDoNewControl2);

            TheMenu = new List<MyMenuItem>
            {
                new MyMenuItem { Header = "Log off", Command = LogoutCommand },
                new MyMenuItem { Header = "Other stuff",
                    Children = new List<MyMenuItem>
                    {
                        new MyMenuItem { Header = "Load new control", Command = NewControlCommand },
                        new MyMenuItem { Header = "Load control v2", Command = NewControl2Command },
                        new MyMenuItem { Header = "Open new window", Command = NewWindowCommand },
                    },
                },
            };

            //ApplicationController.GetInstance().SetStage(Stage);
        }

        private void DoLogin()
        {
            AuthVM.Authenticate();
        }

        private bool CanDoLogout()
        {
            return AuthVM.IsAuthenticated;
        }

        private void DoLogout()
        {
            AuthVM.LogOff();
        }

        private bool CanDoNewControl()
        {
            return AuthVM.IsAuthenticated;
        }

        private void DoNewControl()
        {
          //  ApplicationController.GetInstance().GoToPage(Model.ApplicationPage.NewControl1);
        }

        private bool CanDoNewWindow()
        {
            return AuthVM.IsAuthenticated;
        }

        private void DoNewWindow()
        {
          //  ApplicationController.GetInstance().GoToPage(Model.ApplicationPage.NewWindow2);
        }

        private bool CanDoNewControl2()
        {
            return AuthVM.IsAuthenticated;
        }

        private void DoNewControl2()
        {
            var element = new Slider { Width = 100 };
            element.SetBinding(Slider.ValueProperty, new Binding("InputValue") { Mode = BindingMode.TwoWay });
            element.SetBinding(Slider.IsEnabledProperty, new Binding("IsAuthenticated") { Source = AuthVM });
            SubView = element;
        }
    }
}