using Ludo.Application.Commands.CreateGameCommand;
using Ludo.Application.Commands.UpdateGameCommand;
using Ludo.Application.Queries.GetAllGames;
using Ludo.Application.Queries.GetGameByID;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ludo.Api.Controllers
{
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var getAllGamesQuery = new GetAllGamesQuery();
            var games = await _mediator.Send(getAllGamesQuery);

            return Ok(games);   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetGameByIdQuery(id);
            var game = await _mediator.Send(query);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateGameCommand command)
        {
            var ret = await _mediator.Send(command);

            return Ok(ret);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateGameCommand command)
        {
            if(command.Description.Length > 300 || command.Title == null)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }



    }
    
}
