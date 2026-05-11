using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Galleries.Command.Create;
using PublicSite.Application.Features.Galleries.Command.CreateMany;
using PublicSite.Application.Features.Galleries.Command.Delete;
using PublicSite.Application.Features.Galleries.Command.Update;
using PublicSite.Application.Features.Galleries.Query.GetAll;
using PublicSite.Application.Features.Galleries.Query.GetById;

namespace PublicSite.Api.Controllers.Galleries
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllGalleryQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(new ApiResponse<GetAllGalleryResponse>
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
            var result = await _mediator.Send(new GetByIdGalleryQuery(id));
            return Ok(new ApiResponse<GetByIdGalleryResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateGalleryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiResponse<CreateGalleryResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpPost("{albumId}")]
        public async Task<IActionResult> Create(Guid albumId, [FromForm] CreateManyGalleryRequest request)
        {
            var result = await _mediator.Send(new CreateManyGalleryCommand(albumId, request.Ressources));
            return Ok(new ApiResponse<CreateManyGalleryResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromForm] UpdateGalleryRequest request)
        {
            var command = new UpdateGalleryCommand
                (
                    Id: id,
                    Date: request.Date,
                    Description: request.Description,
                    Ressource: request.Ressource,
                    AlbumId: request.AlbumId
                );

            var result = await _mediator.Send(command);

            return Ok(new ApiResponse<UpdateGalleryResponse>
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
            await _mediator.Send(new DeleteGalleryCommand(id));

            return Ok(new ApiResponse<DeleteGalleryResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
            });
        }
    }
}
