using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MES_2.DB.Database;
using MES_2.DB.Tables;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.SystemModule.State
{
    public class StatesModel : IRepository<State, object>
    {
        // singleton - lazy learning
        private static StatesModel instance;

        public static StatesModel Instance
        {
            get
            {
                if (instance == null) instance = new StatesModel();
                return instance;
            }
        }

        public State Retrieve(int p_id)
        {
            return null;
        }

        public IEnumerable<State> Retrieve()
        {
            List<State> Temp = new List<State>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.STA_StateList
                    .Select(MapperState.MapSTAToState)
                    .ToList();
            }
            return Temp;
        }

        public IEnumerable<State> RetrieveByEntityName(string p_EntityName)
        {
            List<State> Temp = new List<State>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.STA_StateList
                    .Where(x => x.ENT_Entity.NAME_ENT == p_EntityName)
                    .Select(MapperState.MapSTAToState)
                    .ToList();
            }
            return Temp;
        }

        public State Add(object p_entity)
        {
            return null;
        }

        public void Add(State p_entity)
        {
            using (var db = new MES_DATABASE())
            {
                db.STA_StateList.Add(MapperState.MapStateToSTA(p_entity));
                db.SaveChanges();
            }
        }

        public void Delete(State p_entity)
        {
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(State p_entity)
        {
            var Temp = MapperState.MapStateToSTA(p_entity);
            using (var db = new MES_DATABASE())
            {
                if (!db.STA_StateList.Local.Any(c => c.ID_STA == p_entity.ID_STA))
                {
                    db.STA_StateList.Attach(Temp);
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
