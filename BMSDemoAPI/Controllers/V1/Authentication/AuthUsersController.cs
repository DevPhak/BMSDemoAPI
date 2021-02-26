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

        public AuthUsersController(BMSDemoAPIDBContext context)
        {
            _context = context;
        }

        [HttpGet("{APIKey}/{UserName}/{UserPassword}")]
        public ActionResult<Users> GetUserDetails(string APIKey, string UserName, string UserPassword)
        {
            if (APIKey != "ABC" || APIKey == string.Empty || APIKey == null)
            {
                return NotFound("API Key Not Found.");
            }

            var res = _context.Users.Find(UserName, UserPassword);

            if (res == null)
            {
                return NotFound();

            }

            if (res.IsActive == "Y")
            {
                return Ok(res.IsActive);
            }

            return NotFound("N");
        }
    }
}
