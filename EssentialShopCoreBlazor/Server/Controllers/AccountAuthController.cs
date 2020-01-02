using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EssentialShopCoreBlazor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EssentialShopCoreBlazor.Server.Controllers
{
    [Route("essential/users/")]
    public class AccountAuthController : ControllerBase
    {

        private static UserModel LoggedOutUser = new UserModel { IsAuthenticated = false };

        private readonly UserManager<IdentityUsersModel> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUsersModel> signInManager;

        public AccountAuthController(UserManager<IdentityUsersModel> _userManager, SignInManager<IdentityUsersModel> _signInManager, IConfiguration _configuration)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            configuration = _configuration;
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ApplicationUserModel>> CreateUser([FromBody] ApplicationUserModel model)
        {
            var NewUser = new IdentityUsersModel
            {
                UserName = model.UserName,
                BusinessName = model.BusinessName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = await userManager.CreateAsync(NewUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return BadRequest(new RegistrationResult { Successful = false, Errors = errors });
            }
            return Ok(new RegistrationResult { Successful = true });
        }


     

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
            {
                var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

                if (!result.Succeeded) return BadRequest(new UserLogInResult { Successful = false, Error = "Username and password are invalid." });

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, login.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(Convert.ToInt32(configuration["JwtExpiryInDays"]));

                var token = new JwtSecurityToken(
                    configuration["JwtIssuer"],
                    configuration["JwtAudience"],
                    claims,
                    expires: expiry,
                    signingCredentials: creds
                );

                return Ok(new UserLogInResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
        
    }
}