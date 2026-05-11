using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Actualities.Command.Update;
using PublicSite.Application.Features.Sponsors.Command.Create;
using PublicSite.Application.Features.Sponsors.Command.Delete;
using PublicSite.Application.Features.Sponsors.Command.Update;
using PublicSite.Application.Features.Sponsors.Query.GetAll;

namespace PublicSite.Api.Controllers.Sponsors
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController(IMediator _mediator) : ControllerBase
    {
        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromForm] UpdateSponsorRequest request)
        {
            var command = new UpdateSponsorCommand
                (
                    Id: id,
                    Name : request.Name,
                    Ressource : request.Logo,
                    SiteUrl : request.SiteUrl
                );

            var result = await _mediator.Send(command);

            return Ok(new ApiResponse<UpdateSponsorResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }
    }
}
