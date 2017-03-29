//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-29
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : TranslationStateViewModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-29
//  Change History: 
// 
// ==================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MES_2.Modules.SystemModule.Translation;
using WPF.Helpers;
using WPF.Modules.Base;

namespace WPF.Modules.SystemModule.Translation
{
    public class TranslationStateViewModel : ViewModelBase
    {
        private TranslationModel _repo = new TranslationModel();
        private List<MES_2.Modules.SystemModule.Translation.Translation> _allStates;

        public TranslationStateViewModel()
        {
            //            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            //            EditCustomerCommand = new RelayCommand<ENT_Entity>(OnEditUser);
            //            ClearSearchCommand = new RelayCommand(OnClearSearch);
            _repo.Add(null);
            _allStates = _repo.Retrieve().ToList();
            States = new ObservableCollection<MES_2.Modules.SystemModule.Translation.Translation>(_allStates);

        }

        private ObservableCollection<MES_2.Modules.SystemModule.Translation.Translation> _states;
        public ObservableCollection<MES_2.Modules.SystemModule.Translation.Translation> States
        {
            get { return _states; }
            set { SetProperty(ref _states, value); }
        }

        //        private void FilterUsers(string searchInput)
        //        {
        //            if (string.IsNullOrWhiteSpace(searchInput))
        //            {
        //                Entities = new ObservableCollection<ENT_Entity>(_allEntities);
        //                return;
        //            }
        //            else
        //            {
        //                //   Users = new ObservableCollection<USR_UserList>(_allUsers.Where(c => c.FullName.ToLower().Contains(searchInput.ToLower())));
        //            }
        //        }

        public RelayCommand<MES_2.Modules.SystemModule.Translation.Translation> StatesOfItemCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }

        public event Action<int> StatesOfSelectRequested = delegate { };

        public void OnStateOfItem(MES_2.Modules.SystemModule.Translation.Translation p_item)
        {
            //Users = new ObservableCollection<USR_UserList>(_allUsers.Where(c => c.FullName.ToLower().Contains(searchInput.ToLower())));
            //StatesOfSelectRequested();
        }
    }
}