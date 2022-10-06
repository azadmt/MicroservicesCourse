using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private IConfiguration _config;

        public SecurityController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            string token = string.Empty;
            //authenticate 

            if (InMemoryDB.Users.Any(p => p.Username == loginModel.Username && p.Password == loginModel.Password))
            {
                token = Guid.NewGuid().ToString();
                InMemoryDB.Tokens.Add
                    (token,
                    new SecurityToken()
                    {
                        Roles = InMemoryDB.UserPermissions[loginModel.Username],
                        Username = loginModel.Username

                    });
            }
            return Ok(new { Token = token });
        }

        [HttpGet]
        public IActionResult Get(string token)
        {
            var permission = InMemoryDB.Tokens[token];
            if (permission is null)
                return Unauthorized();

            return Ok(permission);
        }

        private UserModel AuthenticateUser(LoginModel login)
        {
            UserModel user = null;
            //TODO: Read From DB
            if (login.Username == "myUserName")
            {
                user = new UserModel { Username = "myUserName", EmailAddress = "myUserName@gmail.com" };
            }
            return user;
        }
    }
}
