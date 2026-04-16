using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace PublicSite.Application.Services
{
    public class FileStorageService(IConfiguration _config) : IFileStorageService
    {
        public void DeleteFileAsync(Ressource ressource)
        {
            var storagePath = _config.GetSection("Upload:StoragePath").Get<string>();
            var fullPath = Path.Combine(storagePath!, ressource.Url.Replace("/", "\\"));

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }

        public void DeleteManyFileAsync(List<Ressource> ressources)
        {
            foreach (var item in ressources)
            {
                DeleteFileAsync(item);
            }
        }

        public async Task<Ressource> SaveFileAsync(IFormFile ressource, string folder = "", bool isImage = true)
        {
            if (ressource == null || ressource.Length == 0)
                throw new Exception("Empty ressource");

            var allowedExtensions = isImage ?
                _config.GetSection("Upload:AllowedExtensionsImage").Get<string[]>() :
                _config.GetSection("Upload:AllowedExtensions").Get<string[]>();
            ;

            var maxFileSize = _config.GetValue<long>("Upload:MaxFileSize") * 1024 * 1024;

            if (ressource.Length > maxFileSize)
                throw new Exception("File too large");

            var extension = Path.GetExtension(ressource.FileName).ToLower();

            if (allowedExtensions is not null && !allowedExtensions.Contains(extension))
                throw new Exception("Unsupported file extension");

            var storagePath = _config.GetSection("Upload:StoragePath").Get<string>();

            var uploadFolder = Path.Combine(storagePath!, isImage ? "images" : "files", folder);

            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadFolder, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await ressource.CopyToAsync(stream);

            return new Ressource()
            {
                Url = Path.Combine(isImage ? "images" : "files", folder, fileName).Replace("\\", "/"),
                Name = ressource.FileName,
                Extension = extension,
                ContentType = ressource.ContentType,
                Size = ressource.Length
            };
        }

        public async Task<List<Ressource>> SaveManyFileAsync(IFormFile[] ressources, string folder = "", bool isImage = true)
        {
            List<Ressource> resources = [];
            foreach (var item in ressources)
            {
                resources.Add(await SaveFileAsync(item, folder, isImage));
            }

            return resources;
        }
    }
}
