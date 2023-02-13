using Ludo.Application.Commands.AddAdvertisement;
using Ludo.Application.Queries.GetAdvertisementById;
using Ludo.Application.Queries.GetAllAdsQuery;
using Ludo.Application.VIewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;

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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllAdsQuery = new GetAllAdsQuery();
            var ads = await _mediator.Send(getAllAdsQuery);

            return Ok(ads);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAdvertisementByIdQuery(id);
            var ad = await _mediator.Send(query);

            if (ad == null) return BadRequest();

            return Ok(ad);

        }

        [HttpPost]
        public async Task<IActionResult> Post(AddAdvertisementCommand command)
        {
            var ret = await _mediator.Send(command);
            return Ok(ret);
        }
    }
}
