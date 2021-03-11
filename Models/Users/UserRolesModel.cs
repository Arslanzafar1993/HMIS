using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Users
{
    public class UserRolesModel
    {
        public IList<string> UserRoles { get; set; }
        public IList<string> AllRoles { get; set; }
    }
}
