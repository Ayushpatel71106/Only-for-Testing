using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApIAngular.contract.request;
using WebApIAngular.contract.response;
using WebApIAngular.model;
using WebApIAngular.respository;

namespace WebApIAngular.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IConfiguration _config;
        private IUsers UserService;
        public UsersController(IConfiguration configuration, IUsers _user)
        {
            _config = configuration;
            UserService = _user;
        }

        [HttpPost]
        [Route("api/users/login")]
        public IActionResult Login(LoginModel user)
        {
            var authenticate = UserService.SignIn(user);
            if (authenticate != null)
            {
                var result = new LoginResult()
                {
                    Message = "Login Successfull",
                    Status = "ok",
                    Data = authenticate,
                    Token = BuildToken()
                };
                return Ok(result);
            }
            else
            {
                var result = new LoginResult()
                {
                    Message = "Invalid login credentials !",
                    Status = "failed",
                    Data = null,

                };
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("api/users/signup")]
        public ActionResult SignUp(Users user)
        {
            var result = UserService.SignUp(user);
            return Ok(result);
        }

        [NonAction]
        public string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}