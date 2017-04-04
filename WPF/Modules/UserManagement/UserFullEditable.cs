//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-29
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : UserFullEditable.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-29
//  Change History: 
// ==================================
using System.ComponentModel.DataAnnotations;
using WPF.Helpers;

namespace WPF.Modules.UserManagement
{
    public class UserFullEditable : ValidatableBindableBase
    {
        private string _LOGIN;

        [Required]
        public string LOGIN
        {
            get { return _LOGIN; }
            set { SetProperty(ref _LOGIN, value); }
        }

        private string _PASSWORD;

        [Required]
        public string PASSWORD
        {
            get { return _PASSWORD; }
            set { SetProperty(ref _PASSWORD, value); }
        }

        private string _Title_before;

        public string Title_before
        {
            get { return _Title_before; }
            set { SetProperty(ref _Title_before, value); }
        }

        private string _First_Name;

        [Required]
        public string First_Name
        {
            get { return _First_Name; }
            set { SetProperty(ref _First_Name, value); }
        }

        private string _Last_Name;

        [Required]
        public string Last_Name
        {
            get { return _Last_Name; }
            set { SetProperty(ref _Last_Name, value); }
        }

        private string _Title_after;

        public string Title_after
        {
            get { return _Title_after; }
            set { SetProperty(ref _Title_after, value); }
        }

        private string _Company;

        public string Company
        {
            get { return _Company; }
            set { SetProperty(ref _Company, value); }
        }

        private string _Email;

        [Required]
        [EmailAddress]
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }

        private string _Phone;

        [Phone]
        public string Phone
        {
            get { return _Phone; }
            set { SetProperty(ref _Phone, value); }
        }

        private string _Mobile;

        [Phone]
        public string Mobile
        {
            get { return _Mobile; }
            set { SetProperty(ref _Mobile, value); }
        }
    }
}