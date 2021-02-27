using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BMSDemoAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BMSDemoAPI.Controllers.V1.Authentication
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthUsersController : ControllerBase
    {
        private readonly BMSDemoAPIDBContext _context;

        private string AuthAPIKey { get; set; }

        public AuthUsersController(BMSDemoAPIDBContext context)
        {
            _context = context;
            AuthAPIKey = "A";
        }

        [HttpGet("{APIKey}/{UserName}/{UserPassword}")]
        public async Task<ActionResult<Users>> GetUserDetailed(string APIKey, string UserName, string UserPassword)
        {
            if (APIKey == AuthAPIKey)
            {
                var result = await _context.Users.FindAsync(UserName, UserPassword);

                if (result != null)
                {
                    if (result.IsActive != "Y")
                    {
                        return new NotFoundObjectResult(new JsonResult("สถานะผู้ใช้งานถูกระงับชั่วคราว"));
                    }
                }
                else
                {
                    return new NotFoundObjectResult(new JsonResult("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง"));
                }
                return new OkObjectResult(new JsonResult(1));
            }
            return new NotFoundObjectResult(new JsonResult("Invalid API Key"));
        }
    }
}
