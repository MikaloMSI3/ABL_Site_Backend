using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Actualities.Command.Create;
using PublicSite.Domain.Entities.Models;

namespace PublicSite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualityController(IMediator _mediator) : ControllerBase
    {
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
    }
}
