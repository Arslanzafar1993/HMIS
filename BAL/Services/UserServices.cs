using DAL.Data.Database.Tables;
using DAL;
using Models.Common;
using Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class UserServices
    {
        private UsersDAL _UsersDAL;

        public UserServices()
        {
            _UsersDAL = new UsersDAL();
        }
        #region GetUsersList
        public PaginationResult<AspNetUser> GetAllUsers(PaginationViewModel model)
        {
            try
            {
                PaginationResult<AspNetUser> UserResult;
                UserResult = _UsersDAL.GetAllUsers(model);
                return UserResult;
            }
            catch
            {
                throw;
            }
        }
        #endregion
       
    }
}
