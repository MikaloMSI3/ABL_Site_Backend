using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Contacts.Query.GetAll
{
    public record GetAllContactCommand(int? Limit = null) : IRequest<GetAllContactResponse>;
}
