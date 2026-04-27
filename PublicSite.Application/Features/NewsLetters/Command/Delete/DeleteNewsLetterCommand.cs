using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.NewsLetters.Command.Delete
{
    public record DeleteNewsLetterCommand(Guid Id) : IRequest<DeleteNewsLetterResponse>;
}
