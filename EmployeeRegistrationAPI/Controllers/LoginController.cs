using EmployeeRegistrationAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration _configuration)
        {
            this._configuration = _configuration; 
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("please provide username and Password");
            }
            LoginResponse response = new() { username = Model.username };
            if (Model.username == "Shivam" && Model.Password == "Shivam123")
            {
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret"));
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        //Username
                        new Claim(ClaimTypes.Name,Model.username),
                        //Role
                        new Claim(ClaimTypes.Role,"Admin")

                    }),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.token = tokenHandler.WriteToken(token);

            }
            else
            {
                return Ok("Invalid username and password");
            }
            return Ok(response);

        }
    }
}
