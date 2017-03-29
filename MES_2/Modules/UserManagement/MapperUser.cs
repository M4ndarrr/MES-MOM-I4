using MES_2.DB.Database;

namespace MES_2.Modules.UserManagement
{
    public static class Mapper
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
                Title_after = entity.Title_after?.Trim()
            };
        }

        public static USR_UserList MapUserFullToUSREntity(UserFull entity)
        {
            return new USR_UserList()
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
                Title_after = entity.Title_after?.Trim()
            };
        }





    }
}