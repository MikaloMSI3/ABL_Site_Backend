using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Contacts.Command.Delete
{
    public record DeleteContactCommand(Guid Id) : IRequest<DeleteContactResponse>;
}
