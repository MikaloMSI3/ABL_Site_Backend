using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.ActualityCategories.Command.Create;
using PublicSite.Application.Features.ActualityCategories.Command.Delete;
using PublicSite.Application.Features.ActualityCategories.Query.GetAll;

namespace PublicSite.Api.Controllers.Actualities
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualityCategoryController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllActualityCatQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllActualityCatResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateActualityCatCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateActualityCatResponse>
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
            await _mediator.Send(new DeleteActualityCatCommand(id));

            return Ok(new ApiResponse<DeleteActualityCatResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }
    }
}
