using Gestion_facturas.DataAcces;
using Gestion_facturas.Helpers;
using Gestion_facturas.Models.DataModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Linq;

namespace Gestion_facturas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly FacturasDBContext _context;
        private readonly JwtSettings _jwtSettings;
       

        public AccountController(FacturasDBContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
            
        }
        //TODO: CHANGE BY REAL USERS IN DB
        private IEnumerable<Users> Logins = new List<Users>()
        {
            new Users() 
            {
                Id= 1,
                UserName = "Admin",
                Password = "Admin",
                Email = "juan@Admin.com"
            },new Users()
            {
                Id= 2,
                UserName = "User",
                Password = "pepe",
                Email = "pepe@pepe.com"
            }


        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins) {

            try
            {
                var token = new UserTokens();
                var Valid = Logins.Any(user => user.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));

                if (Valid)
                {
                    var user = Logins.FirstOrDefault(user => user.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));

                    token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = user.UserName,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid(),
                    },_jwtSettings);
                }
                else
                {
                    return BadRequest("Worng Password");
                }
                return Ok(token);
            }
            catch (Exception exception) {
                throw new Exception("GetToken Error", exception);
            
            }
            
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }

    }
}
