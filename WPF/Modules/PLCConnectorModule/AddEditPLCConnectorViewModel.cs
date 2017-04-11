//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-05
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : AddEditPLCConnectorViewModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-05
//  Change History: 
// 
// ==================================

using System;
using System.Collections.ObjectModel;
using MES_2.Modules.PLCConnectorModule;
using MES_2.Modules.SystemModule.Entity;
using MES_2.Modules.SystemModule.State;
using WPF.Helpers;
using WPF.Modules.Base;
using WPF.Modules.SystemModule.State;

namespace WPF.Modules.PLCConnectorModule
{
    public class AddEditPLCConnectorViewModel : ViewModelBase
    {
        private bool _isEditMode = true;

        public bool isEditMode
        {
            get { return _isEditMode; }
            set { SetProperty(ref _isEditMode, value); }
        }

        private ObservableCollection<EntityModel> _entityAll;

        public ObservableCollection<EntityModel> EntityAll
        {
            get { return _entityAll; }
            set { SetProperty(ref _entityAll, value); }
        }





        public AddEditPLCConnectorViewModel(PLCConnectorModuleConfigure p_PLC)
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);

            if (p_PLC != null)
            {
               // SetState(p_PLC);
            }
            else
            {
                SetState(null);
            }
        }

        private PLCConnectorFullEditable _PLC;

        public PLCConnectorFullEditable Plc
        {
            get { return _PLC; }
            set { SetProperty(ref _PLC, value); }
        }

        private PLCConnectorModuleConfigure _edditingPlcConnectorModuleConfigure;

        public PLCConnectorModuleConfigure EdditingPlcConnectorModuleConfigure
        {
            get { return _edditingPlcConnectorModuleConfigure; }
            set { _edditingPlcConnectorModuleConfigure = value; }
        }
        public void SetState(PLCConnectorModuleConfigure p_PLC)
        {
            if (p_PLC == null)
            {
                isEditMode = false;
                p_PLC = new PLCConnectorModuleConfigure();

            }

            EdditingPlcConnectorModuleConfigure = p_PLC;
            if (Plc != null) Plc.ErrorsChanged -= RaiseCanExecuteChanged;
            Plc = new PLCConnectorFullEditable();
            Plc.ErrorsChanged += RaiseCanExecuteChanged;
            CopyState(EdditingPlcConnectorModuleConfigure, Plc);
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
            UpdateState(Plc, EdditingPlcConnectorModuleConfigure);
            //if (isEditMode)
                //StatesRepository.Instance.Edit(_edditin - změny zatím nebudou aktivní - pouze přidávání odebírání
            //else
               PlcConnectorModuleRepository.Instance.Add(EdditingPlcConnectorModuleConfigure);
            Done();
        }

        private bool CanSave()
        {
            return !Plc.HasErrors;
        }

        private void UpdateState(PLCConnectorFullEditable source, PLCConnectorModuleConfigure target)
        {
           // target.Id = source.; // musi byt lockle pro edit - musí se vytvářet samo
            target.IpString = source.IpString;
            target.PortString = source.PortString;
            target.Rack = source.Rack;
            target.Slot = source.Slot;
        }

        private void CopyState(PLCConnectorModuleConfigure source, PLCConnectorFullEditable target)
        {
            if (isEditMode)
            {
                target.IpString = source.IpString;
                target.PortString = source.PortString;
                target.Rack = source.Rack;
                target.Slot = source.Slot;
            }
        }
    }
}