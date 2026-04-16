using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Entities.ValueObjects
{
    //public record Ressource(string Url, string Name, string? Extension, string? ContentType = null, long? Size = null);
    public record Ressource
    {
        public required string Url { get; set; }
        public required string Name { get; set; }
        public string? Extension { get; set; }
        public string? ContentType { get; set; }
        public long? Size { get; set; }
    }
}
