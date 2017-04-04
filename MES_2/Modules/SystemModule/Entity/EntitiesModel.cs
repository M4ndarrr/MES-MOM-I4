using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MES_2.DB.Database;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.SystemModule.Entity
{
    public class EntitiesModel : IRepository<Entity, object>
    {
        
        // singleton - lazy learning
        private static EntitiesModel instance;

        public static EntitiesModel Instance
        {
            get
            {
                if (instance == null) instance = new EntitiesModel();
                return instance;
            }
        }
        public IEnumerable<Entity> Retrive()
        {
            List<Entity> Temp = new List<Entity>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.ENT_Entity
                    .Select(MapperEntity.MapENTToMapperEntity)
                    .ToList();
            }
            return Temp;
        }

        public Entity Retrieve(int p_id)
        {
            return null;
        }

        public IEnumerable<Entity> Retrieve()
        {
            yield break;
        }

        public Entity Add(object p_entity)
        {
            return null;
        }

        public void Add(Entity p_entity)
        { //musi se vytvořit také základní translation a state
            using (var db = new MES_DATABASE())
            {
                db.ENT_Entity.Add(MapperEntity.MapEntityToENT(p_entity));
                db.SaveChanges();
            }
        }

        public void Delete(Entity p_entity)
        {
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(Entity p_entity)
        {
            var Temp = MapperEntity.MapEntityToENT(p_entity);
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
