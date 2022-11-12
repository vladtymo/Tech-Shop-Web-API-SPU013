using BusinessLogic.DTOs;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using System.Net;

namespace First_Web_API_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto user)
        {
            if (!ModelState.IsValid) return BadRequest();

            await accountService.Register(user);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserCredentials credentials)
        {
            await accountService.Login(credentials.Email, credentials.Password);

            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await accountService.Logout();
            return Ok();
        }
    }
}
