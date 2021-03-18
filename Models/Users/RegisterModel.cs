using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Models.Common.CommonModels;

namespace Models.Users
{
    public class RegisterModel
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string CNIC { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string HealthFacilityCode { get; set; }
        public bool Active { get; set; }
        public DDLModel Division { get; set; }
        public DDLModel District { get; set; }
        public DDLModel Tehsil { get; set; }
        public DDLModel HealthFacility { get; set; }
        public string tehsilcode { get; set; }
    }
}
