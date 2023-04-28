using Application.Marketplaces.Models;
using Application.Marketplaces.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Marketplaces
{
    [ApiController]
    [Route("v1")]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class MarketplaceController : ControllerBase
    {
        public readonly IMediator _mediator;

        public MarketplaceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("marketplace")]
        [ProducesResponseType(typeof(MarketplaceModel), StatusCodes.Status200OK)]
        public IActionResult GetMarketplaceById([FromQuery] GetMarketplaceByIdQuery query, CancellationToken cancellationToken) 
        {
            var result = _mediator.Send(query, cancellationToken).Result;

            if (result.IsFailed)
            {
                return Problem(detail: result.Errors[0].Message, statusCode: StatusCodes.Status400BadRequest);
            }

            return Ok(result.Value);
        }

    }
}
