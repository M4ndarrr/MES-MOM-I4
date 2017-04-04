//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-29
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : AddEditUserManagementViewModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-29
//  Change History: 
// 
// ==================================

using System;
using MES_2.Modules.UserManagement;
using WPF.Helpers;
using WPF.Modules.Base;
using WPF.Modules.Interfaces;

namespace WPF.Modules.UserManagement
{
    public class AddEditUserManagementViewModel : ViewModelBase
    {

        private bool _isEditMode = true;
        public bool isEditMode
        {
            get { return _isEditMode; }
            set { SetProperty(ref _isEditMode, value); }
        }

        public AddEditUserManagementViewModel(UserFull p_User)
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
            SetUser(p_User);
        }

        private UserFullEditable _User;
        public UserFullEditable User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }

        private UserFull _edditingUser;

        public void SetUser(UserFull p_user)
        {
            if (p_user == null)
            {
                isEditMode = false;
                p_user = new UserFull();
            }

            _edditingUser = p_user;
            if (User != null) User.ErrorsChanged -= RaiseCanExecuteChanged;
            User = new UserFullEditable();
            User.ErrorsChanged += RaiseCanExecuteChanged;
            CopyCustomer(_edditingUser, User);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };


        private void OnCancel()
        {
            Done();
        }

        private void OnSave()
        {
            UpdateCustomer(User, _edditingUser);
            if (isEditMode)
                UserManagementModel.Instance.Edit(_edditingUser);
            else
                UserManagementModel.Instance.Add(_edditingUser);
            Done();
        }

        private void UpdateCustomer(UserFullEditable source, UserFull target)
        {
            
            target.First_Name = source.First_Name;
            target.Last_Name = source.Last_Name;
            target.Title_after = source.Title_after;
            target.Title_before = source.Title_before;
            target.Phone = source.Phone;
            target.Email = source.Email;
            target.Company = source.Company;
            target.Mobile = source.Mobile;
            target.LOGIN = source.LOGIN;
            target.PASSWORD = source.PASSWORD;
        }

        private bool CanSave()
        {
            return !User.HasErrors;
        }

        private void CopyCustomer(UserFull source, UserFullEditable target)
        {
            if (isEditMode)
            {
                target.First_Name = source.First_Name;
                target.Last_Name = source.Last_Name;
                target.Title_after = source.Title_after;
                target.Title_before = source.Title_before;
                target.Phone = source.Phone;
                target.Email = source.Email;
                target.Company = source.Company;
                target.Mobile = source.Mobile;
                target.LOGIN = source.LOGIN;
                target.PASSWORD = source.PASSWORD;
            }
        }
    }
}