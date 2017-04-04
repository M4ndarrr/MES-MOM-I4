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
// 
// ==================================

using System;
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

        public AddEditStateViewModel(MES_2.Modules.SystemModule.State.State p_State)
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
            SetState(p_State);
        }

        private StateFullEditable _State;
        public StateFullEditable State
        {
            get { return _State; }
            set { SetProperty(ref _State, value); }
        }

        private MES_2.Modules.SystemModule.State.State _edditingState;

        public void SetState(MES_2.Modules.SystemModule.State.State p_State)
        {
            if (p_State == null)
            {
                isEditMode = false;
                p_State = new MES_2.Modules.SystemModule.State.State();
            }

            _edditingState = p_State;
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

        public event Action<string> Done = delegate { };


        private void OnCancel()
        {
            Done(State.NAME_ENT);
        }

        private void OnSave()
        {
            UpdateCustomer(State, _edditingState);
            if (isEditMode)
                StatesModel.Instance.Edit(_edditingState);
            else
                StatesModel.Instance.Add(_edditingState);
            Done(State.NAME_ENT);
        }
        private bool CanSave()
        {
            return !State.HasErrors;
        }

        private void UpdateCustomer(StateFullEditable source, MES_2.Modules.SystemModule.State.State target)
        {

            target.NAME_ENT = source.NAME_ENT;
            target.Comments = source.Comments;
            target.L_END_STATE = source.L_END_STATE;
            target.L_START_STATE = source.L_START_STATE;
            target.L_VALID = source.L_VALID;
            target.Purpous = source.Purpous;

            
        }
        private void CopyState(MES_2.Modules.SystemModule.State.State source, StateFullEditable target)
        {
            if (isEditMode)
            {
                target.NAME_ENT = source.NAME_ENT;
                target.Comments = source.Comments;
                target.L_END_STATE = source.L_END_STATE;
                target.L_START_STATE = source.L_START_STATE;
                target.L_VALID = source.L_VALID;
                target.Purpous = source.Purpous;
            }
        }
    }
}