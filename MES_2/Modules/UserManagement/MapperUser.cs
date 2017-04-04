using MES_2.DB.Database;
using MES_2.DB.Tables;
using MES_2.Modules.SystemModule.State;

namespace MES_2.Modules.UserManagement
{
    public static class MapperUserFull
    {
        public static UserFull MapUSREntityToUserFull(USR_UserList entity)
        {
            return new UserFull()
            {
                ID_USR = entity.ID_USR,
                ID_STA = entity.ID_STA,
                Company = entity.Company?.Trim(),
                Email = entity.Email?.Trim(),
                First_Name = entity.First_Name?.Trim(),
                Last_Name = entity.Last_Name?.Trim(),
                LOGIN = entity.LOGIN.Trim(),
                Mobile = entity.Mobile?.Trim(),
                Phone = entity.Phone?.Trim(),
                Title_before = entity.Title_before?.Trim(),
                Title_after = entity.Title_after?.Trim(),
                PASSWORD = entity.PASSWORD
            };
        }

        public static USR_UserList MapUserFullToUSREntity(UserFull p_userFull)
        {
            return new USR_UserList()
            {
                ID_USR = p_userFull.ID_USR,
                ID_STA = p_userFull.ID_STA,
                Company = p_userFull.Company?.Trim(),
                Email = p_userFull.Email?.Trim(),
                First_Name = p_userFull.First_Name?.Trim(),
                Last_Name = p_userFull.Last_Name?.Trim(),
                LOGIN = p_userFull.LOGIN.Trim(),
                Mobile = p_userFull.Mobile?.Trim(),
                Phone = p_userFull.Phone?.Trim(),
                Title_before = p_userFull.Title_before?.Trim(),
                Title_after = p_userFull.Title_after?.Trim(),
                PASSWORD = p_userFull.PASSWORD
            };
        }
    }
}