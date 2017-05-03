//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-05
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : PLCConnectorViewModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-05
//  Change History: 
// 
// ==================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MES_2.Modules.PLCConnectorModule;
using MES_2.Modules.SystemModule.State;
using WPF.Helpers;
using WPF.Modules.Base;

namespace WPF.Modules.PLCConnectorModule
{
    public class PLCConnectorViewModel : ViewModelBase
    {
        private string EntityName { get; set; }
        private List<PLCConnectorModuleConfigure> _allPLCConfigure = new List<PLCConnectorModuleConfigure>();

        public PLCConnectorViewModel()
        {
                _allPLCConfigure = PlcConnectorModuleRepository.Instance.PlcConnectorModulesList
                    .Select(x => x.PlcModuleConfigure)
                    .ToList();


            AddPLCCommand = new RelayCommand(OnAddPLC);
            EditPLCCommand = new RelayCommand<PLCConnectorModuleConfigure>(OnEditPLC);
            RunPLCCommand = new RelayCommand<PLCConnectorModuleConfigure>(OnRunPLC);
            StopPLCCommand = new RelayCommand<PLCConnectorModuleConfigure>(OnStopPLC);
            RestartPLCCommand = new RelayCommand<PLCConnectorModuleConfigure>(OnRestartPLC);
            ComObjectCommand = new RelayCommand<PLCConnectorModuleConfigure>(OnComObject);

            PLCs = new ObservableCollection<PLCConnectorModuleConfigure>(_allPLCConfigure);
        }

        private ObservableCollection<PLCConnectorModuleConfigure> _PLCs;

        public ObservableCollection<PLCConnectorModuleConfigure> PLCs
        {
            get { return _PLCs; }
            set { SetProperty(ref _PLCs, value); }
        }

        public RelayCommand<PLCConnectorModuleConfigure> ComObjectCommand { get; private set; }
        public RelayCommand<PLCConnectorModuleConfigure> EditPLCCommand { get; private set; }
        public RelayCommand<PLCConnectorModuleConfigure> RunPLCCommand { get; private set; }
        public RelayCommand<PLCConnectorModuleConfigure> StopPLCCommand { get; private set; }
        public RelayCommand<PLCConnectorModuleConfigure> RestartPLCCommand { get; private set; }
        public RelayCommand AddPLCCommand { get; private set; }

        public event Action<PLCConnectorModuleConfigure> AddEditPLCRequested = delegate { };
        public event Action<Guid> ComObjectRequested = delegate { };

        private void OnAddPLC()
        {
            AddEditPLCRequested(null);
        }

        private void OnEditPLC(PLCConnectorModuleConfigure p_state)
        {
            AddEditPLCRequested(p_state);
        }

        private void OnComObject(PLCConnectorModuleConfigure p_state)
        {
            ComObjectRequested(p_state.Id);
        }
        private void OnRestartPLC(PLCConnectorModuleConfigure p_obj)
        {

        }

        private void OnStopPLC(PLCConnectorModuleConfigure p_obj)
        {

        }

        private void OnRunPLC(PLCConnectorModuleConfigure p_obj)
        {

        }
    }
}
