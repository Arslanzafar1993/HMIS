using System;
using System.Collections.Generic;
using System.Text;

namespace Models.HealthFacility
{
    public class HealthFacilityModel
    {
        public int? ID { get; set; }
        public string DivisionCode { get; set; }
        public string DistrictCode { get; set; }
        public string TehsilCode { get; set; }
        public string Category { get; set; }
        public string HospitalName { get; set; }
    }
}
