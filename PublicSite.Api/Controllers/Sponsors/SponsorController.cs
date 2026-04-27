using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Sponsors.Command.Create;
using PublicSite.Application.Features.Sponsors.Command.Delete;
using PublicSite.Application.Features.Sponsors.Query.GetAll;

namespace PublicSite.Api.Controllers.Sponsors
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSponsorQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllSponsorResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateSponsorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateSponsorResponse>
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
            await _mediator.Send(new DeleteSponsorCommand(id));

            return Ok(new ApiResponse<DeleteSponsorResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }
    }
}
