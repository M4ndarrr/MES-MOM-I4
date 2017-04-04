//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-10
//  ===============================
//  Namespace        : WPF
//  Class                   : ViewModelBase.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-10
//  Change History: 
// ==================================

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF.Modules.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            //if (PropertyChanged == null) return;
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        private bool _isRightsMode = false;

        public bool IsRightsMode
        {
            get { return _isRightsMode; }
            set { SetProperty(ref _isRightsMode, value); }

        }
    }
}