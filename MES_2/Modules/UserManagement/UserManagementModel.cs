using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MES_2.DB.Database;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.UserManagement
{
    public  class UserManagementModel : IRepository<UserFull, object>
    {
        // singleton - lazy learning
        private static UserManagementModel instance;

        public static UserManagementModel Instance
        {
            get
            {
                if (instance == null) instance = new UserManagementModel();
                return instance;
            }
        }


        public UserFull Retrieve(int p_id)
        {
            return null;
        }

        public IEnumerable<UserFull> Retrieve()
        {
            yield break;
        }

        public UserFull Add(object p_entity)
        {
            return null;
        }

        public void Add(UserFull p_userFull)
        {
            var Temp = MapperUserFull.MapUserFullToUSREntity(p_userFull);
            using (var db = new MES_DATABASE())
            {

                db.USR_UserList.Add(Temp);
                db.SaveChanges();

            }
        }

        public void Delete(UserFull p_userFull)
        {
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(UserFull p_userFull)
        {

            var Temp = MapperUserFull.MapUserFullToUSREntity(p_userFull);
            using (var db = new MES_DATABASE())
            {
                db.USR_UserList.Attach(Temp);
                db.Entry(Temp).State = EntityState.Modified;
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
