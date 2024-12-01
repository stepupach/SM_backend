using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public struct LoginData
        {
            public string login { get; set; }
            public string password { get; set; }
        }
        [HttpPost]
        public object GetToken ([FromBody] LoginData ld)
        {
            var user = AuthOptions.users.FirstOrDefault(u => u.Login == ld.login && u.Password == ld.password);
            if (user==null)
            {
                Response.StatusCode = 401;
                return new { message = "Неправильный логин или пароль" };
            }    
            return AuthOptions.GenerateToken(user.IsAdmin);
        }
        // [HttpGet("users")]
        // public List<User> GetUsers ()
        // {
        //     return SharedData.Users;
        // }
        // [HttpGet("token")]
        // public object GetToken ()
        // {
        //     return AuthOptions.GenerateToken();
        // }
        // [HttpGet("token/secret")]
        // public object GetAdminToken ()
        // {
        //     return AuthOptions.GenerateToken(true);
        // }
    }
}