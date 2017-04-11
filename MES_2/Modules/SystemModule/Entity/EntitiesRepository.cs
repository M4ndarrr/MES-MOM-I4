using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using MES_2.DB.Database;
using MES_2.DB.Tables;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.SystemModule.Entity
{
    public class EntitiesRepository : IRepository<EntityModel, object>
    {
        
        // singleton - lazy learning
        private static EntitiesRepository instance;

        public static EntitiesRepository Instance
        {
            get
            {
                if (instance == null) instance = new EntitiesRepository();
                return instance;
            }
        }


        public EntityModel Retrieve(int p_id)
        {
            EntityModel Temp = new EntityModel();

            using (var db = new MES_DATABASE())
            {
                Temp = db.ENT_Entity
                    .Where(x => x.ID_ENT == p_id)
                    .Select(Mapper.Map<EntityModel>)
                    .SingleOrDefault();
                //  .Select(MapperEntity.MapENTToMapperEntity)
            }
            return Temp;
        }

        public IEnumerable<EntityModel> Retrieve()
        {
            List<EntityModel> Temp = new List<EntityModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.ENT_Entity
                    .Select(Mapper.Map<EntityModel>)
                    .ToList();
                //.Select(MapperEntity.MapENTToMapperEntity)
            }
            return Temp;
        }

        public EntityDetailModel RetrieveDetail(int p_id)
        {
            EntityDetailModel Temp = new EntityDetailModel();

            using (var db = new MES_DATABASE())
            {
                Temp = db.ENT_Entity
                    .Where(x => x.ID_ENT == p_id)
                    .Select(Mapper.Map<EntityDetailModel>)
                    .SingleOrDefault();
            }
            return Temp;
        }

        public IEnumerable<EntityDetailModel> RetrieveDetail()
        {
            List<EntityDetailModel> Temp = new List<EntityDetailModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.ENT_Entity
                    .Select(Mapper.Map<EntityDetailModel>)
                    .ToList();

                //.Select(MapperEntity.MapENTToMapperEntityDetail)
            }
            return Temp;
        }


        public EntityModel Add(object p_entity)
        {
            return null;
        }

        public void Add(EntityModel p_entity)
        { //musi se vytvořit také základní translation a state
            using (var db = new MES_DATABASE())
            {
               // db.ENT_Entity.Add(MapperEntity.MapEntityToENT(p_entity));
                db.ENT_Entity.Add(Mapper.Map<ENT_Entity>(p_entity));
                db.SaveChanges();
            }
        }

        public void Delete(EntityModel p_entity)
        {
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(EntityModel p_entity)
        {
           // var Temp = MapperEntity.MapEntityToENT(p_entity);
            var Temp = Mapper.Map<ENT_Entity>(p_entity);
            using (var db = new MES_DATABASE())
            {
                if (!db.ENT_Entity.Local.Any(c => c.ID_ENT == p_entity.ID_ENT))
                {
                    db.ENT_Entity.Attach(Temp);
                    db.Entry(Temp).State = EntityState.Modified;

                }
                db.SaveChanges();
            }
        }

        public void Edit(EntityDetailModel p_entity)
        {
//            var Temp = MapperEntity.MapEntityDetilToENT(p_entity);
            var Temp = Mapper.Map<ENT_Entity>(p_entity); ;
            using (var db = new MES_DATABASE())
            {
                if (!db.ENT_Entity.Local.Any(c => c.ID_ENT == p_entity.ID_ENT))
                {
                    db.ENT_Entity.Attach(Temp);
                    db.Entry(Temp).State = EntityState.Modified;

                }
                db.SaveChanges();
            }
        }

        public void Edit(object p_entity)
        {

        }

        public bool Save()
        {
            return false;
        }
    }
}
