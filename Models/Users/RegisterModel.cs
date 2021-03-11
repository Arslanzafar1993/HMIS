using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        public string division { get; set; }
        public string district { get; set; }
        public string tehsil { get; set; }
    }
}
