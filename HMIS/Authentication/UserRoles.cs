namespace HMIS.Authentication
{
    public class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public string UserId { get; set; }
        public string[] AddRoleId { get; set; }
        public string[] DeleteRoleId { get; set; }
    }
}
