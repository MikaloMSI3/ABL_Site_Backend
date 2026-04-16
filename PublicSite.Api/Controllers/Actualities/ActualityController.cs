using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Actualities.Command.Create;
using PublicSite.Application.Features.Actualities.Command.Delete;
using PublicSite.Application.Features.Actualities.Command.Update;
using PublicSite.Application.Features.Actualities.Query.GetAll;
using PublicSite.Application.Features.Actualities.Query.GetById;
using PublicSite.Domain.Entities.Models;

namespace PublicSite.Api.Controllers.Actualities
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualityController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllActualityQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllActualityResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdActualityQuery(id));
            return Ok(new ApiResponse<GetByIdActualityResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateActualityCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateActualityResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromForm] UpdateActualityRequest request)
        {
            var command = new UpdateActualityCommand
                (
                    Id: id,
                    Date: request.Date,
                    Title: request.Title,
                    Description: request.Description,
                    Ressource: request.Ressource,
                    ActualityCategoryId: request.ActualityCategoryId
                );

            var result = await _mediator.Send(command);

            return Ok(new ApiResponse<UpdateActualityResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteActualityCommand(id));

            return Ok(new ApiResponse<DeleteActualityResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }

    }
}
