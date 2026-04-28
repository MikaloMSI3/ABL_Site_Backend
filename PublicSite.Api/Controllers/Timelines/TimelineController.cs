using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Timelines.Command.Create;
using PublicSite.Application.Features.Timelines.Command.Delete;
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
    }
}
