using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Command
{
    public class ContactRepositoryCommand(DBContext _context, IContactRepositoryQuery _query) : IContactRepositoryCommand
    {
        private readonly DbSet<Contact> _contacts = _context.Contacts;
        public async Task<Contact> AddContactAsync(Contact contact)
        {
            var entity = Contact.Create
                (
                    contact.Lastname,
                    contact.Firstname,
                    contact.Email,
                    contact.Phone,
                    contact.ClubName,
                    contact.OrganisationName,
                    contact.MailSubject,
                    contact.MailBody
                );
            await _contacts.AddAsync(entity);
            return entity;
        }

        public async Task<Contact> SoftDeleteContactAsync(Guid id)
        {
            var entity = await _query.GetByIdContactAsync(id);
            entity.SoftDeleteContact();
            return entity;
        }

        //public async Task<Contact> UpdateContactAsync(Guid id, Contact contact)
        //{
        //    var entity = await _query.GetByIdContactAsync(id);
        //    entity.UpdateContact(contact.Lastname,contact.First)
        //}
    }
}
