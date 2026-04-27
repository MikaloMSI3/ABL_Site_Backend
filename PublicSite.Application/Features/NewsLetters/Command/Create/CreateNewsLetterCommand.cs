using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.NewsLetters.Command.Create
{
    public record CreateNewsLetterCommand(string Email) : IRequest<CreateNewsLetterResponse>;
}
