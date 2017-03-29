using System.Collections.Generic;
using System.Linq;
using MES_2.DB.Database;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.SystemModule.Entity
{
    public class EntitiesModel : IRepository<Entity, object>
    {

        public IEnumerable<Entity> Retrive()
        {
            List<Entity> Temp = new List<Entity>();

            using (var db = new TestDatabaseEntities())
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
        {
            using (var db = new TestDatabaseEntities())
            {
                db.ENT_Entity.Add(MapperEntity.MapEntityToENT(new Entity()
                {
                    NAME_ENT = "USR_UserList",

                }));
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
