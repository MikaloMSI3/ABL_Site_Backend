using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Dtos
{
    public record RessourceDto(string Url, string Name, string? Extension, string? ContentType = null, long? Size = null);
}
