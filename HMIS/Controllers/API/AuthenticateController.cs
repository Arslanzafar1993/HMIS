using HMIS.Authentication;
using HMIS.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Common;
using Models.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        // private readonly UserService _UserService;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            //_UserService = new UserService(userManager);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return null;
            }
        } 

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!string.IsNullOrEmpty(model.UserID))
            {
                ApplicationUser UserInfo = await userManager.FindByIdAsync(model.UserID);
                if (UserInfo != null)
                {
                    UserInfo.UserName = model.Username;
                    UserInfo.CNIC = model.CNIC;
                    UserInfo.Email = model.Email;
                    UserInfo.PhoneNumber = model.ContactNumber;
                    UserInfo.HealthFacilityCode = model.HealthFacility.Code;
                    UserInfo.UpdatedOn = DateTime.Now;
                    await userManager.UpdateAsync(UserInfo);
                }
            }
            else
            {
                var userExists = await userManager.FindByNameAsync(model.Username);
                if (userExists != null)
                    return Ok(CommonUtility.GetExResponse<Exception>("User is already Exist"));
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Username,
                    CNIC = model.CNIC,
                    Email = model.Email,
                    PhoneNumber = model.ContactNumber,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    RawPassword = model.Password,
                    RawConfirmPassword = model.ConfirmPassword,
                    HealthFacilityCode = model.HealthFacilityCode,
                    Status = true,
                    CreatedOn = DateTime.Now
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return Ok(CommonUtility.GetExResponse<Exception>("User creation failed! Please check user details and try again."));
            }
            return Ok(CommonUtility.GetResponse<Response>(null, string.IsNullOrEmpty(model.UserID) ? "User created successfully" : "User Updated Successfully"));
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        #region Roles
       // [Authorize]
        [HttpGet]
        [Route("Roles")]
        public async Task<IActionResult> Roles(string role)
        {
            try
            {
                return Ok(new { userroles = roleManager.Roles.Where(a => a.Name.Contains(string.IsNullOrEmpty(role) ? a.Name : role)).OrderBy(x => x.Name).Select(y => y.Name).ToList() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("CreateRole/{role}")]
        public async Task<IActionResult> CreateRole(string role)
        {
            bool x = await roleManager.RoleExistsAsync(role);
            if (!x)
            {
                var userRole = new IdentityRole { Name = role };
                var result = await roleManager.CreateAsync(userRole);

                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        userroles = roleManager.Roles.OrderBy(x => x.Name).Select(y => y.Name).ToList()
                    });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            return BadRequest("Role Already Exists");
        }

        [HttpDelete]
        [Route("DeleteRole/{role}")]
        public async Task<IActionResult> DeleteRole(string role)
        {

            try
            {
                var userRole = await roleManager.FindByNameAsync(role);

                var result = await roleManager.DeleteAsync(userRole);

                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        userroles = roleManager.Roles.OrderBy(x => x.Name).Select(y => y.Name).ToList()
                    });
                }

            }
            catch (Exception ex)
            {
                return Ok(CommonUtility.GetExResponse<Exception>(ex));
            }
            return BadRequest("");
        }

        #endregion
    }
}
