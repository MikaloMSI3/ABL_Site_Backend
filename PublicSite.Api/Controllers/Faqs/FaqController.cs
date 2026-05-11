using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Faqs.Command.Create;
using PublicSite.Application.Features.Faqs.Command.Delete;
using PublicSite.Application.Features.Faqs.Command.Update;
using PublicSite.Application.Features.Faqs.Query.GetAll;
using PublicSite.Application.Features.Faqs.Query.GetById;

namespace PublicSite.Api.Controllers.Faqs
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController(IMediator _mediator) : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFaqQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllFaqResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdFaqQuery(id));
            return Ok(new ApiResponse<GetByIdFaqResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFaqCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateFaqResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] UpdateFaqRequest request)
        {
            var command = new UpdateFaqCommand
                (
                    Id: id,
                    Question: request.Question,
                    Answer: request.Answer,
                    FaqCategoryId: request.FaqCategoryId
                );

            var result = await _mediator.Send(command);

            return Ok(new ApiResponse<UpdateFaqResponse>
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
            await _mediator.Send(new DeleteFaqCommand(id));

            return Ok(new ApiResponse<DeleteFaqResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }
    }
}
