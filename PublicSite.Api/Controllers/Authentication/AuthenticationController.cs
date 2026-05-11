using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Albums.Command.Create;
using PublicSite.Application.Features.Authentications.Command.Login;

namespace PublicSite.Api.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IMediator _mediat) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var result = await _mediat.Send(request);

            return Ok(new ApiResponse<LoginResponse>
            {
                Success = true,
                Code = 200,
                Message = "Opération réussie",
                Data = result
            });
        }
    }
}
