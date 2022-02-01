using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectSK8.Managers;
using ProiectSK8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager auth;

        public AuthenticationController(IAuthenticationManager auth)
        {
            this.auth = auth;
        }

        [HttpPost("Signup")]

        public async Task<IActionResult> Signup([FromBody] RegisterModel reg)
        {
            await auth.Signup(reg);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var tokens = await auth.Login(loginModel);

            if(tokens != null)
            {
                return Ok(tokens);
            }
            else
            {
                return BadRequest("Failed to login");
            }
            
        }
    }
}
