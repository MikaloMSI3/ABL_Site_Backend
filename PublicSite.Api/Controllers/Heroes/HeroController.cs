using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Heros.Command.Create;
using PublicSite.Application.Features.Heros.Command.Delete;
using PublicSite.Application.Features.Heros.Query.GetAll;

namespace PublicSite.Api.Controllers.Heroes
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllHeroQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllHeroResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateHeroCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateHeroResponse>
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
            await _mediator.Send(new DeleteHeroCommand(id));

            return Ok(new ApiResponse<DeleteHeroResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }
    }
}
