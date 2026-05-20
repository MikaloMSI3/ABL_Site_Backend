using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSite.Api.Models;
using PublicSite.Application.Features.Authentications.Command.Login;
using PublicSite.Application.Features.Authentications.Command.RefreshToken;

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

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenCommand request)
        {
            var result = await _mediat.Send(request);
            return Ok(new ApiResponse<RefreshTokenResponse>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = ""
            });
        }
    }
}
