//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-05
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : AddEditComObjectViewModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-05
//  Change History: 
// ==================================
using System;
using System.Collections.ObjectModel;
using System.Linq;
using MES_2.Modules.ComModule;
using MES_2.Modules.PLCConnectorModule;
using MES_2.Modules.SystemModule.Entity;
using WPF.Helpers;
using WPF.Modules.Base;
using WPF.Modules.PLCConnectorModule;

namespace WPF.Modules.ComModule
{
    public class AddEditComObjectViewModel : ViewModelBase
    {
        private bool _isEditMode = true;

        public bool isEditMode
        {
            get { return _isEditMode; }
            set { SetProperty(ref _isEditMode, value); }
        }

        private ObservableCollection<PLCConnectorModuleConfigure> _PLCAll;

        public ObservableCollection<PLCConnectorModuleConfigure> PLCAll
        {
            get { return _PLCAll; }
            set { SetProperty(ref _PLCAll, value); }
        }

        private PLCConnectorModuleConfigure _PLC;

        public PLCConnectorModuleConfigure PLC
        {
            get { return _PLC; }
            set { SetProperty(ref _PLC, value); }
        }

        public AddEditComObjectViewModel(ComObjectConfigure p_comObject)
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);

            if (p_comObject != null)
            {
                SetComObject(p_comObject);
            }
            else
            {
                SetComObject(null);
            }
        }

        private ComObjectFullEditable _ComObject;

        public ComObjectFullEditable ComObject
        {
            get { return _ComObject; }
            set { SetProperty(ref _ComObject, value); }
        }

        private ComObjectConfigure _edditingComObjectConfigure;

        public ComObjectConfigure EdditingComObjectConfigure
        {
            get { return _edditingComObjectConfigure; }
            set { _edditingComObjectConfigure = value; }
        }

        public void SetComObject(ComObjectConfigure p_ComObject)
        {
            if (p_ComObject == null)
            {
                isEditMode = false;
                p_ComObject = new ComObjectConfigure();
                PLCAll =
                    new ObservableCollection<PLCConnectorModuleConfigure>(
                        PlcConnectorModuleRepository.Instance.PlcConnectorModulesList.Select(x => x.PlcModuleConfigure)
                            .ToList());
            }

            EdditingComObjectConfigure = p_ComObject;
            if (ComObject != null) ComObject.ErrorsChanged -= RaiseCanExecuteChanged;
            ComObject = new ComObjectFullEditable();
            ComObject.ErrorsChanged += RaiseCanExecuteChanged;
            CopyState(EdditingComObjectConfigure, ComObject);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action<Guid> Done = delegate { };


        private void OnCancel()
        {
            Done(Guid.Empty);
        }

        private void OnSave()
        {
            UpdateState(ComObject, EdditingComObjectConfigure);


            // if (isEditMode)
            // StatesRepository.Instance.Edit(_edditin - změny zatím nebudou aktivní - pouze přidávání odebírání
            // else
            var temp =PlcConnectorModuleRepository.Instance.PlcConnectorModulesList.First(x => x.PlcModuleConfigure.Id == PLC.Id);
            var instance = ComObjectRepository.Instance.Add(EdditingComObjectConfigure);
            temp.CommunicationObjects.Add(instance);
            Done(temp.PlcModuleConfigure.Id);
        }

        private bool CanSave()
        {
            return !ComObject.HasErrors;
        }

        private void UpdateState(ComObjectFullEditable source, ComObjectConfigure target)
        {
            // target.Id = source.; // musi byt lockle pro edit - musí se vytvářet samo
            target.AreaOfMemory = source.AreaOfMemory;
            target.DbNumber = source.DbNumber;
            target.PeriodOfCheck = source.PeriodOfCheck;
            target.StartOffset = source.StartOffset;
            target.WorldLen = source.WorldLen;
        }

        private void CopyState(ComObjectConfigure source, ComObjectFullEditable target)
        {
            if (isEditMode)
            {
                target.AreaOfMemory = source.AreaOfMemory;
                target.DbNumber = source.DbNumber;
                target.PeriodOfCheck = source.PeriodOfCheck;
                target.StartOffset = source.StartOffset;
                target.WorldLen = source.WorldLen;
            }
        }
    }
}