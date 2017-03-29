//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-22
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : UserRepository.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-22
//  Change History: 
// 
// ==================================

using System;
using System.Collections.Generic;
using System.Linq;
using MES_2.DB.Database;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.UserManagement
{
    public class UserRepository : IRepository<UserFull, object>
    {
        public UserFull Retrieve(int p_id)
        {
            UserFull Temp = new UserFull();

            using (var db = new TestDatabaseEntities())
            {
                Temp = db.USR_UserList.Where(x => x.ID_USR == p_id)
                        .Select(Mapper.MapUSREntityToUserFull)
                        .FirstOrDefault();
            }
            return Temp;
        }

        public IEnumerable<UserFull> Retrieve()
        {
            List<UserFull> Temp = new List<UserFull>();

            using (var db = new TestDatabaseEntities())
            {
                Temp = db.USR_UserList
                    .Select(Mapper.MapUSREntityToUserFull)
                    .ToList();

            }
            return Temp;
        }


        public void Add(UserFull p_entity)
        {
            var Temp = Mapper.MapUserFullToUSREntity(p_entity);
            using (var db = new TestDatabaseEntities())
            {
                db.USR_UserList.Add(Temp);
                db.SaveChanges();
            }
        }

        public void Delete(UserFull p_entity)
        {
            // nesmí se smazat pouze se změní jeho stav na smazany
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(UserFull p_entity)
        {
            var Temp = Mapper.MapUserFullToUSREntity(p_entity);
            using (var db = new TestDatabaseEntities())
            {
                if (!db.USR_UserList.Local.Any(c => c.ID_USR == p_entity.ID_USR))
                {
                    db.USR_UserList.Attach(Temp);
                }
                db.SaveChanges();
            }

        }

        public bool Save()
        {
            return false;
        }

        public UserFull Add(object p_entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(object p_entity)
        {
            throw new NotImplementedException();
        }
    }
}