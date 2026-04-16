using Microsoft.AspNetCore.Http;
using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Interfaces
{
    public interface IFileStorageService
    {
        public Task<Ressource> SaveFileAsync(IFormFile ressource, string folder = "", bool isImage = true);
        public Task<List<Ressource>> SaveManyFileAsync(IFormFile[] ressource, string folder = "", bool isImage = true);
        public void DeleteFileAsync(Ressource ressource);
        public void DeleteManyFileAsync(List<Ressource> ressources);
    }
}
