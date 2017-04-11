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
        private EntitiesRepository _repo = new EntitiesRepository();
        private List<EntityModel> _allEntities;

        public EntitiesViewModel()
        {
            AddEntityCommand = new RelayCommand(OnAddEntity);
            EditEntityCommand = new RelayCommand<EntityModel>(OnEditEntity);
            StatesEntityCommand = new RelayCommand<EntityModel>(OnStatesEntity);
            TranslationEntityCommand =
                new RelayCommand<EntityModel>(OnTranslationEntity);

            _allEntities = _repo.Retrieve().ToList();
            Entities = new ObservableCollection<EntityModel>(_allEntities);
        }

        private ObservableCollection<EntityModel> _entities;

        public ObservableCollection<EntityModel> Entities
        {
            get { return _entities; }
            set { SetProperty(ref _entities, value); }
        }

        public RelayCommand<EntityModel> EditEntityCommand { get; private set; }
        public RelayCommand AddEntityCommand { get; private set; }
        public RelayCommand<EntityModel> StatesEntityCommand { get; private set; }

        public RelayCommand<EntityModel> TranslationEntityCommand { get; private set; }

        public event Action<EntityModel> AddEditEntityRequested = delegate { };
        public event Action<int> StatesEntityRequested = delegate { };
        public event Action<int> TranslationEntityRequested = delegate { };


        private void OnAddEntity()
        {
            AddEditEntityRequested(null);
        }

        private void OnEditEntity(EntityModel p_entity)
        {
            AddEditEntityRequested(p_entity);
        }

        private void OnStatesEntity(EntityModel p_entity)
        {
            StatesEntityRequested(p_entity.ID_ENT);
        }

        private void OnTranslationEntity(EntityModel p_entity)
        {
            TranslationEntityRequested(p_entity.ID_ENT);
        }
    }
}