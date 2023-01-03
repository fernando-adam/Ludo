using Ludo.Application.Commands.CreateUser;
using Ludo.Application.Commands.LoginUser;
using Ludo.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ludo.Api.Controllers
{
    [Route("users")]
    [Authorize]
    public class UsersController: ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);

            var user = await _mediator.Send(query);

            if(user == null) return NotFound();

            return Ok(user);

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if(loginUserViewModel == null) return BadRequest();

            return Ok(loginUserViewModel);

        }
        
    }
}
