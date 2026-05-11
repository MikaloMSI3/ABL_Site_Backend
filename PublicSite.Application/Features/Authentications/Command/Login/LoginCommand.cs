using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Authentications.Command.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;
}
