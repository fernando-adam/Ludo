﻿using Ludo.Application.Commands.CreateGameCommand;
using Ludo.Application.Commands.UpdateGameCommand;
using Ludo.Application.Queries.GetAllGames;
using Ludo.Application.Queries.GetGameByID;
using MediatR;
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
        public async Task<IActionResult> Get(string query)
        {
            var getAllGamesQuery = new GetAllGamesQuery(query);
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
            if(command.Title == null)
            {
                return BadRequest("O Jogo deve conter um nome");
            }

            var ret = await _mediator.Send(command);

            return Ok(ret);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateGameCommand command)
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