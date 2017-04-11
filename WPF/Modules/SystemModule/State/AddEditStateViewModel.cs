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
using System.Collections.ObjectModel;
using MES_2.DB.Tables;
using MES_2.Modules.SystemModule.Entity;
using MES_2.Modules.SystemModule.State;
using WPF.Helpers;
using WPF.Modules.Base;

namespace WPF.Modules.SystemModule.State
{
    public class AddEditStateViewModel : ViewModelBase
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


        private EntityModel _entity;

        public EntityModel Entity
        {
            get { return _entity; }
            set { SetProperty(ref _entity, value); }
        }


        public AddEditStateViewModel(StateModel p_State)
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);

            if (p_State != null)
            {
                SetState(StatesRepository.Instance.RetrieveDetail(p_State.ID_STA));
            }
            else
            {
                SetState(null);
            }
        }

        private StateFullEditable _State;

        public StateFullEditable State
        {
            get { return _State; }
            set { SetProperty(ref _State, value); }
        }

        private StateDetailModel _edditingState;

        public StateDetailModel EdditingState
        {
            get { return _edditingState; }
            set { _edditingState = value; }
        }

        public void SetState(StateDetailModel p_State)
        {
            if (p_State == null)
            {
                isEditMode = false;
                p_State = new MES_2.Modules.SystemModule.State.StateDetailModel();
                EntityAll = new ObservableCollection<EntityModel>(EntitiesRepository.Instance.Retrieve());
            }
            else
            {
                Entity = new EntityModel();
                Entity = MapperEntity.MapENTToMapperEntity(p_State.ENT_Entity);
            }

            EdditingState = p_State;
            if (State != null) State.ErrorsChanged -= RaiseCanExecuteChanged;
            State = new StateFullEditable();
            State.ErrorsChanged += RaiseCanExecuteChanged;
            CopyState(_edditingState, State);
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
            Done(EdditingState.ID_ENT);
        }

        private void OnSave()
        {
            UpdateState(State, EdditingState);
            if (isEditMode)
                StatesRepository.Instance.Edit(EdditingState as StateModel);
            else
                StatesRepository.Instance.Add(EdditingState as StateModel);
            Done(EdditingState.ID_ENT);
        }

        private bool CanSave()
        {
            return !State.HasErrors;
        }

        private void UpdateState(StateFullEditable source, StateDetailModel target)
        {
            target.ID_ENT = Entity.ID_ENT; // musi byt lockle pro edit
            target.Comments = source.Comments;
            target.L_END_STATE = source.L_END_STATE;
            target.L_START_STATE = source.L_START_STATE;
            target.L_VALID = source.L_VALID;
            target.Purpous = source.Purpous;
        }


        private void CopyState(StateDetailModel source, StateFullEditable target)
        {
            if (isEditMode)
            {
                target.NAME_ENT = source.ENT_Entity.NAME_ENT;
                target.ID_ENT = source.ID_ENT;
                target.Comments = source.Comments;
                target.L_END_STATE = source.L_END_STATE;
                target.L_START_STATE = source.L_START_STATE;
                target.L_VALID = source.L_VALID;
                target.Purpous = source.Purpous;
            }
        }
    }
}