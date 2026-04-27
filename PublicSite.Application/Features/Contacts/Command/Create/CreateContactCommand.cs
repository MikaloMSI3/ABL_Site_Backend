using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Contacts.Command.Create
{
    public record CreateContactCommand
    (
        string? Lastname,
        string Firstname,
        string Email,
        string Phone,
        string? ClubName,
        string? OrganisationName,
        string MailSubject,
        string MailBody
    ) : IRequest<CreateContactResponse>;
}
