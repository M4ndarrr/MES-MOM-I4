using System.Linq;
using MES_2.DB.Database;

namespace MES_2.Modules.UserManagement
{
    public static class ProfileModel
    {
        public static UserFull ProfileFull  { get; set; }

        public static bool GetInformation(int p_Id)
        {
            ProfileFull = new UserFull();
            bool isFound = false;
            using (var db = new TestDatabaseEntities())
            {
                var result = db.USR_UserList.FirstOrDefault(x => x.ID_USR == p_Id);
                ProfileFull = Mapper.MapUSREntityToUserFull(result);
                isFound = true;
            }
            return isFound;

        }
    }
}
