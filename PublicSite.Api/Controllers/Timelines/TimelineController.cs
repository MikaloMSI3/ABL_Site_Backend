using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.NewsLetters.Command.Create;
using PublicSite.Application.Features.NewsLetters.Command.Delete;
using PublicSite.Application.Features.NewsLetters.Query;

namespace PublicSite.Api.Controllers.Timelines
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimelineController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllNewsLetterQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllNewsLetterResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNewsLetterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateNewsLetterResponse>
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
            await _mediator.Send(new DeleteNewsLetterCommand(id));

            return Ok(new ApiResponse<DeleteNewsLetterResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }
    }
}
