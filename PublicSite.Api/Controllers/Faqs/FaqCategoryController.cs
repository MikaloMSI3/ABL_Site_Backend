using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.FaqCategories.Command.Create;
using PublicSite.Application.Features.FaqCategories.Command.Delete;
using PublicSite.Application.Features.FaqCategories.Command.Update;
using PublicSite.Application.Features.FaqCategories.Query.GetAll;

namespace PublicSite.Api.Controllers.Faqs
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqCategoryController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFaqCatQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllFaqCatResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFaqCatCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateFaqCatResponse>
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
            await _mediator.Send(new DeleteFaqCatCommand(id));

            return Ok(new ApiResponse<DeleteFaqCatResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] string name)
        {
            var command = new UpdateFaqCatCommand
                (
                    Id: id,
                    Name: name
                );

            var result = await _mediator.Send(command);

            return Ok(new ApiResponse<UpdateFaqCatResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }
    }
}
