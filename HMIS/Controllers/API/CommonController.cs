using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Services;
using HMIS.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PHCP.Models.Common;
using static Models.Common.CommonModels;

namespace HMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private CommonServices _commonServices;
        public CommonController()
        {
            _commonServices = new CommonServices();

        }
        #region DivisionList
        [HttpGet]
        [Route("GetDivisionList")]
        public IActionResult GetDivisionList(string geoLevel)
        {
            try
            {
                return Ok(CommonUtility.GetResponse<List<DDLModel>>(_commonServices.GetDivision(geoLevel)));
            }
            catch (Exception ex)
            {
                return Ok(CommonUtility.GetExResponse<Exception>(ex));
            }
        }
        #endregion
        #region DistrictList
        [HttpGet]
        [Route("GetDistrictList/{DivisionCode}")]
        public IActionResult GetDistrictList(string DivisionCode)
        {
            try
            {
                return Ok(CommonUtility.GetResponse<List<DDLModel>>(_commonServices.GetDistrict(DivisionCode)));
            }
            catch (Exception ex)
            {
                return Ok(CommonUtility.GetExResponse<Exception>(ex));
            }
        }
        #endregion
        #region TehsilList
        [HttpGet]
        [Route("GetTehsilList/{DistrictCode}")]
        public IActionResult GetTehsilList(string DistrictCode)
        {
            try
            {
                return Ok(CommonUtility.GetResponse<List<DDLModel>>(_commonServices.GetTehsil(DistrictCode)));
            }
            catch (Exception ex)
            {
                return Ok(CommonUtility.GetExResponse<Exception>(ex));
            }
        }
        #endregion
        #region HealthFacilityList
        [HttpGet]
        [Route("GetHealthFacilityList/{TehsilCode}")]
        public IActionResult GetHealthFacilityList(string TehsilCode = "",string HealthFacilityCode = "")
        {
            try
            {
                return Ok(CommonUtility.GetResponse<List<DDLModel>>(_commonServices.GetHealthFacilities(TehsilCode, HealthFacilityCode)));
            }
            catch (Exception ex)
            {
                return Ok(CommonUtility.GetExResponse<Exception>(ex));
            }
        }
        #endregion
        #region GetOccupationList
        [HttpGet]
        [Route("GetOccupationList")]
        public IActionResult GetOccupationList()
        {
            try
            {
                return Ok(CommonUtility.GetResponse<List<DDLModel>>(_commonServices.GetOccupationList()));
            }
            catch (Exception ex)
            {
                return Ok(CommonUtility.GetExResponse<Exception>(ex));
            }
        }
        #endregion
      
    }
}
