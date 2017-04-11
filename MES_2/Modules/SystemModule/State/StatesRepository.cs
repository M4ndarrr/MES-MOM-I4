using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MES_2.DB.Database;
using MES_2.DB.Tables;
using MES_2.Modules.Interfaces;
using MES_2.Modules.SystemModule.Entity;

namespace MES_2.Modules.SystemModule.State
{
    public class StatesRepository : IRepository<StateModel, object>
    {
        // singleton - lazy learning
        private static StatesRepository instance;

        public static StatesRepository Instance
        {
            get
            {
                if (instance == null) instance = new StatesRepository();
                return instance;
            }
        }

        public StateModel Retrieve(int p_id)
        {
            var Temp = new StateModel();
            using (var db = new MES_DATABASE())
            {
                Temp = db.STA_StateList
                    .Where(id => id.ID_STA == p_id)
                    .Select(MapperState.MapSTAToState)
                    .SingleOrDefault();
            }
            return Temp;
        }

        public IEnumerable<StateModel> Retrieve()
        {
            List<StateModel> Temp = new List<StateModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.STA_StateList
                    .Select(MapperState.MapSTAToState)
                    .ToList();
            }

            return Temp;
        }

        public IEnumerable<StateModel> RetrieveByEntityId(int p_EntityId)
        {
            List<StateModel> Temp = new List<StateModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.STA_StateList
                    .Where(x => x.ENT_Entity.ID_ENT == p_EntityId)
                    .Select(MapperState.MapSTAToState)
                    .ToList();
            }

            return Temp;
        }

        public StateDetailModel RetrieveDetail(int p_id)
        {
            var Temp = new StateDetailModel(); 
            using (var db = new MES_DATABASE())
            {
                Temp = db.STA_StateList
                    .Where(id => id.ID_STA == p_id)
                    .Select(MapperState.MapSTAToStateDetail)
                    .SingleOrDefault();
            }
            return Temp;
        }

        public IEnumerable<StateDetailModel> RetrieveDetail()
        {
            List<StateDetailModel> Temp = new List<StateDetailModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.STA_StateList
                    .Select(MapperState.MapSTAToStateDetail)
                    .ToList();
            }

            return Temp;
        }

        public IEnumerable<StateDetailModel> RetrieveDetailByEntityId(int p_EntityId)
        {
            List<StateDetailModel> Temp = new List<StateDetailModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.STA_StateList
                    .Where(x => x.ENT_Entity.ID_ENT == p_EntityId)
                    .Select(MapperState.MapSTAToStateDetail)
                    .ToList();
            }

            return Temp;
        }

        public StateModel Add(object p_entity)
        {
            return null;
        }

        public void Add(StateModel p_entity)
        {
            using (var db = new MES_DATABASE())
            {
                db.STA_StateList.Add(MapperState.MapStateToSTA(p_entity));
                db.SaveChanges();
            }
        }

        public void Delete(StateModel p_entity)
        {
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(StateModel p_entity)
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