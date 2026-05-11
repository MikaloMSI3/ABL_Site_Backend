using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Users.Command.Create;
using PublicSite.Application.Features.Users.Command.Delete;
using PublicSite.Application.Features.Users.Command.Update;
using PublicSite.Application.Features.Users.Query.GetAll;
using PublicSite.Application.Features.Users.Query.GetById;

namespace PublicSite.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllUserResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdUserQuery(id));
            return Ok(new ApiResponse<GetByIdUserResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateUserResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromForm] UpdateUserRequest request)
        {
            var command = new UpdateUserCommand
                (
                    Id: id,
                    Email : request.Email,
                    Password : request.Password
                );

            var result = await _mediator.Send(command);

            return Ok(new ApiResponse<UpdateUserResponse>
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
            await _mediator.Send(new DeleteUserCommand(id));

            return Ok(new ApiResponse<DeleteUserResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }

    }
}
