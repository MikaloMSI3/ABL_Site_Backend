using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IContactRepositoryCommand
    {
        Task<Contact> AddContactAsync(Contact contact);
        //Task<Contact> UpdateContactAsync(Guid id, Contact contact);
        Task<Contact> SoftDeleteContactAsync(Guid id);
    }
}
