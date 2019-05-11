using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserServices.Models;

namespace UserServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserContext _context;

        public LoginController(UserContext context)
        {
            _context = context;
        }   

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> LoginApi([FromHeader] string Username, [FromHeader]string Password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool user = await _context.Users.Where(e => e.Username==Username).AnyAsync(f=> String.Equals(f.Password,Password,StringComparison.CurrentCulture));

            if (!user)
            {
                return NotFound();
            }            

            return Ok(user);
        }       

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}