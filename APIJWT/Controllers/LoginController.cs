using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APIJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APIJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        UserInfoDataAccessLayer userInfoDataAccessLayer = new UserInfoDataAccessLayer();
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Login(string username, string pass)
        {
            UserModel login = new UserModel();
            login.LoginId = username;
            login.Password = pass;
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }
            return response;
        }
        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = userInfoDataAccessLayer.GetloginUser(login);
            return user;

        }
        private string GenerateJSONWebToken(UserModel userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userinfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email,userinfo.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,userinfo.RoleName)
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials
            );
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        [Authorize]
        [HttpPost]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return "Welcome To: " + userName;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("AddTask")]
        public UserTask InsertTask(UserTask userTask)
        {
          
            userTask= userInfoDataAccessLayer.AddTask(userTask);
            return userTask;
          
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllAssignedTask")]
        public UserTask GetAssignTask()
        {
            UserTask userTask = new UserTask();
            userTask = userInfoDataAccessLayer.GetAllAssignedTask();
            return userTask;

        }
        [Authorize(Roles = "Employee")]
        [HttpGet("GetEmployesTask")]
        public UserTask GetEmployeesTask(UserModel user)
        {
            UserTask userTask = new UserTask();
            userTask = userInfoDataAccessLayer.GetEmployesTask(user);
            return userTask;

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("AddUser")]
        public UserModel InsertUser(UserModel userTask)
        {

            userTask = userInfoDataAccessLayer.AddUser(userTask);
            return userTask;

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("DeleteUser")]
        public UserModel Delete(UserModel userTask)
        {

            userTask = userInfoDataAccessLayer.DeleteUser(userTask);
            return userTask;

        }

    }

}