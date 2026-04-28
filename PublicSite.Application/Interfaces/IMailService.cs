using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Interfaces
{
    public interface IMailService
    {
        Task SendMailAsync(string toEmail, Contact contact);
    }
}
