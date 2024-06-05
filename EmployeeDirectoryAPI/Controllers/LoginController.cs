using System.IdentityModel.Tokens.Jwt;
using System.Text;
using EmployeeDirectory.Models.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeDirectoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        [HttpGet]
        public User AuthenticateUser(User user)
        {
            User usr = null;
            if (user.UserName == "admin" && user.Password == "12345")
            {
                usr= new User { UserName = "Ayush" };
            }
            return usr;
        }
        private string GenerateToken(User user)
        {
            var securityKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],null,expires:DateTime.Now.AddMinutes(2),signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]User user)
        {
            IActionResult response = Unauthorized();
            User usr = AuthenticateUser(user);
            if (usr != null)
            {
                var token = GenerateToken(usr);
                response =   Ok(new { token = token });
            }
            return response;
        }
    }
}
