using DAL.Data.Database.HMISDbContext;
using Models.Common;
using Models.HealthFacility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Models.Common.CommonModels;

namespace DAL
{
    public class CommonDAL
    {
        #region GetDropdowns
        public List<DDLModel> GetDivision(string provinceCode)
        {
            try
            {
                using (var db = new HMISDbContext())
                {
                    return db.HealthFacilityDetails.OrderBy(x => x.DivisionName).Select(x => new DDLModel { Code = x.DivisionCode, Name = x.DivisionName }).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<DDLModel> GetDistrict(string divisionCode)
        {
            try
            {
                using (var db = new HMISDbContext())
                {

                    return db.HealthFacilityDetails.Where(a=>a.DivisionCode == divisionCode).OrderBy(x => x.DistrictName).Select(x => new DDLModel {  Code = x.DistrictCode, Name = x.DistrictName }).Distinct().ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<DDLModel> GetTehsil(string districtCode)
        {
            try
            {
                using (var db = new HMISDbContext())
                {
                    var abc = db.HealthFacilityDetails.Where(a => a.DistrictCode == districtCode).OrderBy(x => x.TehsilName).Select(x => new DDLModel { Code = x.TehsilCode, Name = x.TehsilName }).Distinct().ToList();
                    return abc;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<DDLModel> GetHealthfacilities(string tehsilCode = "",string HealthFacilityCode = "")
        {
            try
            {
                using (var db = new HMISDbContext())
                {
                    return db.HealthFacilityDetails.Where(a=>a.TehsilCode == (string.IsNullOrEmpty(tehsilCode) ? a.TehsilCode : tehsilCode) && a.Id.ToString() == (string.IsNullOrEmpty(HealthFacilityCode) ? a.Id.ToString() : HealthFacilityCode)).Select(x => new DDLModel {  Code = x.HFMISCode, Name = x.FullName }).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<DDLModel> GetOccupationList()
        {
            try
            {
                using (var db = new HMISDbContext())
                {
                    return db.Occupations.Select(x => new DDLModel { Id = x.Id, Name = x.Name }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public HealthFacilityListModel GetHealthFacilitiesData(string HealthFacilityCode = "")
        {
            try
            {
                using (var db = new HMISDbContext())
                {
                    return db.HealthFacilityDetails.Where(a => a.HFMISCode == HealthFacilityCode).Select(x => new HealthFacilityListModel
                    {
                        divisionCode = x.DivisionCode,
                        DivisionName = x.DivisionName,

                        districtCode = x.DistrictCode,
                        DistrictName = x.DistrictName,

                        tehsilCode = x.TehsilCode,
                        TehsilName = x.TehsilName,

                        HFMISCode = x.HFMISCode,
                        HeathFacilityName = x.FullName,
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
