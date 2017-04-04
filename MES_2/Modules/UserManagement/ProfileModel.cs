using System.Linq;
using MES_2.DB.Database;

namespace MES_2.Modules.UserManagement
{
    public  class ProfileModel
    {

        // singleton - lazy learning
        private static ProfileModel instance;

        public static ProfileModel Instance
        {
            get
            {
                if (instance == null) instance = new ProfileModel();
                return instance;
            }
        }

        public  UserFull ProfileFull  { get; set; }

        public bool GetInformation(int p_Id)
        {
            ProfileFull = new UserFull();
            bool isFound = false;
            using (var db = new MES_DATABASE())
            {
                var result = db.USR_UserList.FirstOrDefault(x => x.ID_USR == p_Id);
                ProfileFull = MapperUserFull.MapUSREntityToUserFull(result);
                isFound = true;
            }
            return isFound;

        }
    }
}
