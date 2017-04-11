using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF.Annotations;

namespace WPF.Helpers
{
    public class BindableBase : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T val,
            [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;

            member = val;
            OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string p_propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p_propertyName));
        }
    }
}
