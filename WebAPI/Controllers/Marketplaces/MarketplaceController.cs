using Application.Marketplaces.Models;
using Application.Marketplaces.Queries;
using Application.MarketplacesAgregate.Commands;
using Domain.Marketplaces.Entites;
using Domain.Marketplaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebAPI.Controllers.Marketplaces
{
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class MarketplaceController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMarketplaceRepository _marketplaceRepository;

        public MarketplaceController(IMediator mediator, IMarketplaceRepository marketplaceRepository)
        {
            _mediator = mediator;
            _marketplaceRepository = marketplaceRepository;
        }


        [HttpGet("GetMarketplaceById")]
        [ProducesResponseType(typeof(MarketplaceEntity), StatusCodes.Status200OK)]
        public IActionResult GetMarketplaceById([FromQuery] GetMarketplaceByIdQuery query, CancellationToken cancellationToken) 
        {
            var result = _mediator.Send(query, cancellationToken).Result;

            if (result.IsFailed)
            {
                return Problem(detail: result.Errors[0].Message, statusCode: StatusCodes.Status400BadRequest);
            }else if (result.Value == null)
            {
                return Ok("Not Found");
            }

            return Ok(result.Value);
        }


        [HttpGet("GetMarketplaces")]
        [ProducesResponseType(typeof(MarketplaceEntity), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMarketplaces([FromQuery] PaginationParams @params, CancellationToken cancellationToken)
        {
            IEnumerable<MarketplaceEntity> data = await _mediator.Send(new GetMarketplacesQuery(), cancellationToken);

            var dataList = data.ToList();

            var markets = dataList.Skip((@params.page - 1) * @params.ItemsPerPage).Take(@params.ItemsPerPage);

            var paginationMetadata = new PaginationMetadata(dataList.Count(), @params.page, @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            if (!markets.Any())
            {
                return Ok("No Marketplaces Left");

            }
            else
            {
                return Ok(markets);
            }

            //return Ok(markets);
        }

        [HttpPut("SetFavorites")]
        public async Task<IActionResult> SetFavorites([FromQuery] UpdateMarketplaceFavoritesCommand command, CancellationToken cancellationToken)
        {

            /*var Id = command.Id;
            var isFavorite = command.isFavorite;
            var status = command.status;

            var result = await _marketplaceRepository.UpdateMarketplaceAsync(Id, isFavorite, status);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok("Updated Successfully");
            }*/
            var result = _mediator.Send(command, cancellationToken).Result;
            return Ok(result);


        }


        [HttpPut("SetStatus")]
        public async Task<IActionResult> SetStatus([FromQuery] UpdateMarketplaceStatusCommand command, CancellationToken cancellationToken)
        {

            /*var Id = command.Id;
            var isFavorite = command.isFavorite;
            var status = command.status;

            var result = await _marketplaceRepository.UpdateMarketplaceAsync(Id, isFavorite, status);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok("Updated Successfully");
            }*/
            var result = _mediator.Send(command, cancellationToken).Result;
            return Ok(result);


        }
    }
}
