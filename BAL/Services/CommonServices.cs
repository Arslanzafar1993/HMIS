using DAL;
using Models.Common;
using Models.HealthFacility;
using System;
using System.Collections.Generic;
using System.Text;
using static Models.Common.CommonModels;

namespace BAL.Services
{
    public class CommonServices
    {
        #region Class Level Fields and Objects
        private CommonDAL _commonDAL;
        #endregion
        #region Constructor
        public CommonServices()
        {
            _commonDAL = new CommonDAL();
        }
        #endregion
        #region GetDropDowns
        public List<DDLModel> GetDivision(string provinceCode)
        {
            try
            {

                return new List<DDLModel>(_commonDAL.GetDivision(provinceCode));

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

                return new List<DDLModel>(_commonDAL.GetDistrict(divisionCode));

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

                return new List<DDLModel>(_commonDAL.GetTehsil(districtCode));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<DDLModel> GetHealthFacilities(string tehsilCode = "",string HealthFacilityCode = "")
        {
            try
            {
                return new List<DDLModel>(_commonDAL.GetHealthfacilities(tehsilCode, HealthFacilityCode));
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
                return new List<DDLModel>(_commonDAL.GetOccupationList());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
