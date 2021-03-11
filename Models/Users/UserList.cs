using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Users
{
    public class UserList
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string RawPassword { get; set; }
        public string DistrictCode { get; set; }
        public string District_Name { get; set; }
        public string DivisionCode { get; set; }
        public string Division_Name { get; set; }
        public string TehsilCode { get; set; }
        public string Tehsil_Name { get; set; }
        public string FacilityCode { get; set; }
        public string Health_Facility_Name { get; set; }
        public int ProgramId { get; set; }
        public string CNIC { get; set; }
        public string Designation { get; set; }
        public string FullName { get; set; }
        public string DoctorType { get; set; }
        public string UserType { get; set; }
        public string Address { get; set; }
        public string GEOLVL { get; set; }

    }
}
