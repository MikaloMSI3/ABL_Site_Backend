using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Albums.Command.Create;
using PublicSite.Application.Features.Albums.Command.Delete;
using PublicSite.Application.Features.Albums.Command.Update;
using PublicSite.Application.Features.Albums.Query.GetAll;


namespace PublicSite.Api.Controllers.Galleries
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController(IMediator _mediator) : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAlbumQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllAlbumResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAlbumCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateAlbumResponse>
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
            await _mediator.Send(new DeleteAlbumCommand(id));

            return Ok(new ApiResponse<DeleteAlbumResponse>
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
            var command = new UpdateAlbumCommand
                (
                    Id: id,
                    Name : name
                );

            var result = await _mediator.Send(command);

            return Ok(new ApiResponse<UpdateAlbumResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }
    }
}
