using Ludo.Application.Commands.AddAdvertisement;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ludo.Api.Controllers
{
    [Route("api/[controller]")]
    public class AdvertisementsController : ControllerBase
    {
            private readonly IMediator _mediator;
            public AdvertisementsController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpPost]
            public async Task<IActionResult> AddAdvertisement(AddAdvertisementCommand command)
            {
               var ret = await _mediator.Send(command);
                return Ok(ret);
            }
        }
    }
