using System;
using System.Collections.Generic;
using System.Text;

namespace Models.HealthFacility
{
    public class HealthFacilityListModel
    {
        public int id { get; set; }
        public string divisionCode { get; set; }
        public string DivisionName { get; set; }
        public string districtCode { get; set; }
        public string DistrictName { get; set; }
        public string tehsilCode { get; set; }
        public string TehsilName { get; set; }
        public string HospitalName { get; set; }
        public string category { get; set; }
        public string Identifier { get; set; }

    }
}
