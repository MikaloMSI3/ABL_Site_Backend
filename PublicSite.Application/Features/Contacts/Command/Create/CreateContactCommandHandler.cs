using MediatR;
using Microsoft.Extensions.Configuration;
using PublicSite.Application.Features.Albums.Command.Create;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Contacts.Command.Create
{
    public class CreateContactCommandHandler(IContactRepositoryCommand _repository, IUnitOfWork _unitOfWork, IMailService _mailService, IConfiguration _configuration) : IRequestHandler<CreateContactCommand, CreateContactResponse>
    {
        public async Task<CreateContactResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.AddContactAsync(Contact.Create
                (
                    request.Lastname,
                    request.Firstname,
                    request.Email,
                    request.Phone,
                    request.ClubName,
                    request.OrganisationName,
                    request.MailSubject,
                    request.MailBody
                ));

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var mailTo = _configuration.GetSection("MailTo").Get<string>();
            if (!String.IsNullOrEmpty(mailTo))
                await _mailService.SendMailAsync(mailTo, entity);

            return new CreateContactResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.Lastname,
                entity.Firstname,
                entity.Email,
                entity.Phone,
                entity.ClubName,
                entity.OrganisationName,
                entity.MailSubject,
                entity.MailBody
            );
        }
    }
}
