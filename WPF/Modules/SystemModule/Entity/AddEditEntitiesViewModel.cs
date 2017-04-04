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
using MES_2.Modules.SystemModule.Entity;
using MES_2.Modules.UserManagement;
using WPF.Helpers;
using WPF.Modules.Base;
using WPF.Modules.UserManagement;

namespace WPF.Modules.SystemModule.Entity
{
    public class AddEditEntitiesViewModel : ViewModelBase
    {

        private bool _isEditMode = true;
        public bool isEditMode
        {
            get { return _isEditMode; }
            set { SetProperty(ref _isEditMode, value); }
        }

        public AddEditEntitiesViewModel(MES_2.Modules.SystemModule.Entity.Entity p_Entity)
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
            SetEntity(p_Entity);
        }

        private EntityFullEditable _Entity;
        public EntityFullEditable Entity
        {
            get { return _Entity; }
            set { SetProperty(ref _Entity, value); }
        }

        private MES_2.Modules.SystemModule.Entity.Entity _edditingEntity;

        public void SetEntity(MES_2.Modules.SystemModule.Entity.Entity p_Entity)
        {
            if (p_Entity == null)
            {
                isEditMode = false;
                p_Entity = new MES_2.Modules.SystemModule.Entity.Entity();
            }

            _edditingEntity = p_Entity;
            if (Entity != null) Entity.ErrorsChanged -= RaiseCanExecuteChanged;
            Entity = new EntityFullEditable();
            Entity.ErrorsChanged += RaiseCanExecuteChanged;
            CopyEntity(_edditingEntity, Entity);
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
            UpdateCustomer(Entity, _edditingEntity);
            if (isEditMode)
                EntitiesModel.Instance.Edit(_edditingEntity);
            else
                EntitiesModel.Instance.Add(_edditingEntity);
            Done();
        }

        private void UpdateCustomer(EntityFullEditable source, MES_2.Modules.SystemModule.Entity.Entity target)
        {
            target.NAME_ENT = source.NAME_ENT;
            target.State = source.State;
            target.VALID = source.VALID;
        }

        private bool CanSave()
        {
            return !Entity.HasErrors;
        }

        private void CopyEntity(MES_2.Modules.SystemModule.Entity.Entity source, EntityFullEditable target)
        {
            if (isEditMode)
            {
                target.NAME_ENT = source.NAME_ENT;
                target.State = source.State;
                target.VALID = source.VALID;
            }
        }
    }
}