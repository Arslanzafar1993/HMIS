using DAL.Data.Database.HMISDbContext;
using DAL.Data.Database.Tables;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UsersDAL
    {
        public PaginationResult<AspNetUser> GetAllUsers(PaginationViewModel model)
        {
            try
            {
                using (var db = new HMISDbContext())
                { 
                    IQueryable<AspNetUser> UserList;
                    UserList = db.AspNetUsers.AsQueryable();
                    var TotalCount = UserList.Count();
                    UserList = UserList.OrderByDescending(x => x.Id);//.Skip((model.Page - 1) * (model.PageSize)).Take(model.PageSize);
                    var res = UserList.ToList();
                    return new PaginationResult<AspNetUser> { Data = res, RecordsTotal = TotalCount };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
