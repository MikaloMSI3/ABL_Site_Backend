using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.NewsLetters.Command.Create;
using PublicSite.Application.Features.NewsLetters.Command.Delete;
using PublicSite.Application.Features.NewsLetters.Query;

namespace PublicSite.Api.Controllers.Contacts
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLetterController(IMediator _mediator) : ControllerBase
    {
        [Authorize]
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

        [Authorize]
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

        [Authorize]
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
