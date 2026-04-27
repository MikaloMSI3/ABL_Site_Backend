using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Contacts.Command.Create;
using PublicSite.Application.Features.Contacts.Command.Delete;
using PublicSite.Application.Features.Contacts.Query.GetAll;

namespace PublicSite.Api.Controllers.Contacts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllContactCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllContactResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateContactResponse>
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
            await _mediator.Send(new DeleteContactCommand(id));

            return Ok(new ApiResponse<DeleteContactResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }
    }
}
