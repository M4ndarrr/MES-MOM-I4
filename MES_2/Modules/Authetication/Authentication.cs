//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-10
//  ===============================
//  Namespace        : WPF
//  Class                   : Authentication.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-10
//  Change History: 
// 
// ==================================

using System.Linq;
using MES_2.DB.Database;
using MES_2.Modules.UserManagement;

namespace MES_2.Modules.Authetication
{
    public static class Authentication
    {
        public static bool Authenticate(User p_user)
        {

            bool result = false;

            //Přihlášení -> komunikace s entity frameworkem -> přihlášení do systému
            using (var db = new MES_DATABASE())
            {
                var getUser = db.USR_UserList.Where(x => x.LOGIN == p_user.UserName).FirstOrDefault();
                

                if (getUser?.PASSWORD.Trim() == p_user.Password)
                {
                    p_user.ID = getUser.ID_USR;
                    result = true;
                }

            }
            return result; // Do authentication against database, web service, whatever
        }
    }
}