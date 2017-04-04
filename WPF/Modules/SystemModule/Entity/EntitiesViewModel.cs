using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MES_2.DB.Database;
using MES_2.Modules.SystemModule.Entity;
using MES_2.Modules.SystemModule.State;
using WPF.Helpers;
using WPF.Modules.Base;

namespace WPF.Modules.SystemModule.Entity
{
    class EntitiesViewModel : ViewModelBase
    {
        private EntitiesModel _repo = new EntitiesModel();
        private List<MES_2.Modules.SystemModule.Entity.Entity> _allEntities;

        public EntitiesViewModel()
        {
            AddEntityCommand = new RelayCommand(OnAddEntity);
            EditEntityCommand = new RelayCommand<MES_2.Modules.SystemModule.Entity.Entity>(OnEditEntity);
            StatesEntityCommand = new RelayCommand<MES_2.Modules.SystemModule.Entity.Entity>(OnStatesEntity);
            TranslationEntityCommand = new RelayCommand<MES_2.Modules.SystemModule.Entity.Entity>(OnTranslationEntity);

            _allEntities = _repo.Retrive().ToList();
            Entities = new ObservableCollection<MES_2.Modules.SystemModule.Entity.Entity>(_allEntities);

        }

        private ObservableCollection<MES_2.Modules.SystemModule.Entity.Entity> _entities;
        public ObservableCollection<MES_2.Modules.SystemModule.Entity.Entity> Entities
        {
            get { return _entities; }
            set { SetProperty(ref _entities, value); }
        }

        public RelayCommand<MES_2.Modules.SystemModule.Entity.Entity> EditEntityCommand { get; private set; }
        public RelayCommand AddEntityCommand { get; private set; }
        public RelayCommand<MES_2.Modules.SystemModule.Entity.Entity> StatesEntityCommand { get; private set; }
        public RelayCommand<MES_2.Modules.SystemModule.Entity.Entity> TranslationEntityCommand { get; private set; }

        public event Action<MES_2.Modules.SystemModule.Entity.Entity> AddEditEntityRequested = delegate { };
        public event Action<string> StatesEntityRequested = delegate { };
        public event Action<string> TranslationEntityRequested = delegate { };


        private void OnAddEntity()
        {
            AddEditEntityRequested(null);
        }

        private void OnEditEntity(MES_2.Modules.SystemModule.Entity.Entity p_entity)
        {
            AddEditEntityRequested(p_entity);
        }

        private void OnStatesEntity(MES_2.Modules.SystemModule.Entity.Entity p_entity)
        {
            StatesEntityRequested(p_entity.NAME_ENT);
        }

        private void OnTranslationEntity(MES_2.Modules.SystemModule.Entity.Entity p_entity)
        {
            TranslationEntityRequested(p_entity.NAME_ENT);
        }












    }
}
