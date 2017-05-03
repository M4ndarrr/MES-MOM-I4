//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-05
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : ComObjectViewModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-05
//  Change History: 
// ==================================
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MES_2.Modules.ComModule;
using MES_2.Modules.PLCConnectorModule;
using MES_2.Modules.SystemModule.State;
using WPF.Helpers;
using WPF.Modules.Base;

namespace WPF.Modules.ComModule
{
    public class ComObjectViewModel : ViewModelBase
    {
        private string EntityName { get; set; }
        private List<ComObjectConfigure> _allComObj = new List<ComObjectConfigure>();

        public ComObjectViewModel(Guid p_PLCId)
        {
            //            _allComObj = ComObjectRepository.Instance.ComObjectList
            //                .Where(id => id.ObjectConfigure.Id == p_PLCId)
            //                .Select(x => x.ObjectConfigure)
            //                .ToList();

            var temp = PlcConnectorModuleRepository.Instance.PlcConnectorModulesList.FirstOrDefault(
                    x => x.PlcModuleConfigure.Id == p_PLCId).CommunicationObjects;

            foreach (var comObject in temp)
            {
                _allComObj.Add(comObject.ObjectConfigure);
            }
            
             

            AddComObjectCommand = new RelayCommand(OnAddComObject);
            EditComObjectCommand = new RelayCommand<ComObjectConfigure>(OnEditComObject);
            if (_allComObj != null) { 
                ComObjects = new ObservableCollection<ComObjectConfigure>(_allComObj);
            
            }
            else
            {
                ComObjects = new ObservableCollection<ComObjectConfigure>();
            }
        }

        private ObservableCollection<ComObjectConfigure> _comObjects;

        public ObservableCollection<ComObjectConfigure> ComObjects
        {
            get { return _comObjects; }
            set { SetProperty(ref _comObjects, value); }
        }

        public RelayCommand<ComObjectConfigure> EditComObjectCommand { get; private set; }
        public RelayCommand AddComObjectCommand { get; private set; }

        public event Action<ComObjectConfigure> AddEditComObjectRequested = delegate { };

        private void OnAddComObject()
        {
            AddEditComObjectRequested(null);
        }

        private void OnEditComObject(ComObjectConfigure p_state)
        {
            AddEditComObjectRequested(p_state);
        }
    }
}