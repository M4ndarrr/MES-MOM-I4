using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MES_2.DB.Database;
using MES_2.DB.Tables;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.ComModule
{
    class ReceivedResultRepository : IRepository<ReceivedResult, ReceivedResult>
    {
        // singleton lazy learning 
        private static ReceivedResultRepository instance;

        public static ReceivedResultRepository Instance
        {
            get
            {
                if (instance == null) instance = new ReceivedResultRepository();
                return instance;
            }
        }

        public ReceivedResult Retrieve(int p_id)
        {
            ReceivedResult Temp = new ReceivedResult();

            using (var db = new MES_DATABASE())
            {
                Temp = db.RES_ResultTable
                    .Where(x => x.ID_RES == p_id)
                    .Select(Mapper.Map<ReceivedResult>)
                    .SingleOrDefault();
            }
            return Temp;
        }

        public IEnumerable<ReceivedResult> Retrieve()
        {
            yield break;
        }

        public ReceivedResult Add(ReceivedResult p_entity)
        {
            using (var db = new MES_DATABASE())
            {
                db.RES_ResultTable.Add(Mapper.Map<RES_ResultTable>(p_entity));
                db.SaveChanges();
            }
            return null;
        }
        public void Delete(ReceivedResult p_entity)
        {
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(ReceivedResult p_entity)
        {
        }

        public bool Save()
        {
            return false;
        }

        void IRepository<ReceivedResult, ReceivedResult>.Edit(ReceivedResult p_entity)
        {
            Edit(p_entity);
        }

        void IRepository<ReceivedResult, ReceivedResult>.Add(ReceivedResult p_entity)
        {
        }
    }
}
