using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PHCP.Models.Common
{
    public static class Extensions
    {
        public static string GetUserId(this ControllerBase controllerBase)
        {
            return controllerBase.HttpContext.User.Claims.First(i => i.Type == JwtRegisteredClaimNames.Jti).Value;
        }
        public static string GetUserName(this ControllerBase controllerBase)
        {
            return controllerBase.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.Name).Value;
        }

        public static string GetFacilityCode(this ControllerBase controllerBase)
        {
            return controllerBase.HttpContext.User.Claims.First(i => i.Type == "FacilityCode").Value;
        }
    }
}
