using Application.Features.Users.Commands;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            RegisteredUserDto result = await Mediator.Send(registerUserCommand);
            return Created("", result);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserQuery loginUserQuery)
        {
            LoggedInUserDto result = await Mediator.Send(loginUserQuery);
            return Ok(result);
        }
    }
}
