using System.Collections.Generic;
using System.Linq;
using MES_2.DB.Database;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.SystemModule.State
{
    public class StatesModel : IRepository<State, object>
    {
        public IEnumerable<State> Retrive()
        {
            List<State> Temp = new List<State>();

            using (var db = new TestDatabaseEntities())
            {
                Temp = db.STA_StateList
                    .Select(MapperState.MapSTAToState)
                    .ToList();
            }
            return Temp;
        }

        public State Retrieve(int p_id)
        {
            return null;
        }

        public IEnumerable<State> Retrieve()
        {
            yield break;
        }

        public State Add(object p_entity)
        {
            return null;
        }

        public void Add(State p_entity)
        {
            using (var db = new TestDatabaseEntities())
            {
                db.STA_StateList.Add(MapperState.MapStateToSTA(new State()
                {
                    Name_Entity = "USR_UserList",
                    Purpous = "Stav"

                }));
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
