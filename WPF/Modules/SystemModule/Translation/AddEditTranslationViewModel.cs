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
// ==================================
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MES_2.Modules.SystemModule.Entity;
using MES_2.Modules.SystemModule.State;
using MES_2.Modules.SystemModule.Translation;
using MES_2.Modules.UserManagement;
using Telerik.Windows.Controls.Map;
using WPF.Helpers;
using WPF.Modules.Base;
using WPF.Modules.UserManagement;

namespace WPF.Modules.SystemModule.Translation
{
    public class AddEditTranslationViewModel : ViewModelBase
    {
        private bool _isEditMode = true;

        public bool isEditMode
        {
            get { return _isEditMode; }
            set { SetProperty(ref _isEditMode, value); }
        }

        public AddEditTranslationViewModel(TranslationModel p_translation)
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);

            if (p_translation != null)
            {
                SetTranslation(TranslationRepository.Instance.RetrieveDetail(p_translation.ID_TRA));
            }
            else
            {
                SetTranslation(null);
            }
        }

        private ObservableCollection<EntityModel> _entityAll;

        public ObservableCollection<EntityModel> EntityAll
        {
            get { return _entityAll; }
            set { SetProperty(ref _entityAll, value); }
        }


        private List<StateModel> _stateAll = new List<StateModel>();

        private ObservableCollection<StateModel> _statefromAll = new ObservableCollection<StateModel>();

        public ObservableCollection<StateModel> StateFromAll
        {
            get { return _statefromAll; }
            set { SetProperty(ref _statefromAll, value); }
        }

        private ObservableCollection<StateModel> _statetoAll = new ObservableCollection<StateModel>();

        public ObservableCollection<StateModel> StateToAll
        {
            get { return _statetoAll; }
            set { SetProperty(ref _statetoAll, value); }
        }

        private EntityModel _entity;

        public EntityModel Entity
        {
            get { return _entity; }
            set
            {
                SetProperty(ref _entity, value);

                if (value != null && value.ID_ENT != 0)
                {
                    StateFromAll.RemoveAll();
                    StateToAll.RemoveAll();
                    foreach (var stateModel in _stateAll.Where(x => x.ID_ENT == _entity.ID_ENT))
                    {
                        StateFromAll.Add(stateModel);
                        StateToAll.Add(stateModel);
                    }
                }
            }
        }

        private StateModel _statefrom;

        public StateModel StateFrom
        {
            get { return _statefrom; }
            set { SetProperty(ref _statefrom, value); }
        }

        private StateModel _stateto;

        public StateModel StateTo
        {
            get { return _stateto; }
            set { SetProperty(ref _stateto, value); }
        }


        private TranslationFullEditable _Translation;

        public TranslationFullEditable Translation
        {
            get { return _Translation; }
            set { SetProperty(ref _Translation, value); }
        }

        public TranslationDetailModel EdditingTranslation { get; set; }


        public void SetTranslation(TranslationDetailModel p_translation)
        {
            if (p_translation == null)
            {
                isEditMode = false;
                p_translation = new MES_2.Modules.SystemModule.Translation.TranslationDetailModel();
                EntityAll = new ObservableCollection<EntityModel>(EntitiesRepository.Instance.Retrieve());
                _stateAll = new List<StateModel>(StatesRepository.Instance.Retrieve());
                
            }
            else
            {
                _stateAll = new List<StateModel>(StatesRepository.Instance.RetrieveByEntityId(p_translation.ENT_Entity.ID_ENT));
                Entity = new EntityModel();
                Entity = MapperEntity.MapENTToMapperEntity(p_translation.ENT_Entity);
                StateFrom = new StateModel();
                StateFrom = MapperState.MapSTAToState(p_translation.STATE_FROM);
                StateTo = new StateModel();
                StateTo = MapperState.MapSTAToState(p_translation.STATE_TO);

            }

            EdditingTranslation = p_translation;
            if (Translation != null) Translation.ErrorsChanged -= RaiseCanExecuteChanged;
            Translation = new TranslationFullEditable();
            Translation.ErrorsChanged += RaiseCanExecuteChanged;
            CopyTranslation(EdditingTranslation, Translation);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action<int> Done = delegate { };


        private void OnCancel()
        {
            Done(EdditingTranslation.ID_ENT);
        }

        private void OnSave()
        {
            UpdateCustomer(Translation, EdditingTranslation);
            if (isEditMode)
                TranslationRepository.Instance.Edit(EdditingTranslation as TranslationModel);
            else
                TranslationRepository.Instance.Add(EdditingTranslation as TranslationModel);
            Done(EdditingTranslation.ID_ENT);
        }

        private void UpdateCustomer(TranslationFullEditable source,
            TranslationDetailModel target)
        {
            target.ID_ENT = Entity.ID_ENT;
            target.ID_STA_PICA_FROM = StateFrom.ID_STA;
            target.ID_STA_PICA_TO = StateTo.ID_STA;
            target.Description = source.Description;
            target.L_BLOCK = source.L_BLOCK;
            target.L_VALID = source.L_VALID;
        }

        private bool CanSave()
        {
            return !Translation.HasErrors;
        }

        private void CopyTranslation(TranslationDetailModel source,
            TranslationFullEditable target)
        {
            if (isEditMode)
            {
                target.ID_ENT = target.ID_ENT;
                target.NAME_ENT = source.ENT_Entity.NAME_ENT;

                target.ID_STA_FROM = source.ID_STA_PICA_FROM;

                target.ID_STA_TO = source.ID_STA_PICA_TO;
                target.Description = source.Description;
                target.L_BLOCK = source.L_BLOCK;
                target.L_VALID = source.L_VALID;
            }
        }
    }
}