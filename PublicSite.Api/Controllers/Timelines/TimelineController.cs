using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Timelines.Command.Create;
using PublicSite.Application.Features.Timelines.Command.Delete;
using PublicSite.Application.Features.Timelines.Command.Update;
using PublicSite.Application.Features.Timelines.Query.GetAll;

namespace PublicSite.Api.Controllers.Timelines
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimelineController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTimelineQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllTimelineResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTimelineCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateTimelineResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTimelineCommand(id));

            return Ok(new ApiResponse<DeleteTimelineResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] UpdateTimelineRequest request)
        {
            var command = new UpdateTimelineCommand
                (
                    Id: id,
                    Title: request.Title,
                    Description: request.Description,
                    Year : request.Year
                );

            var result = await _mediator.Send(command);

            return Ok(new ApiResponse<UpdateTimelineResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }
    }
}
