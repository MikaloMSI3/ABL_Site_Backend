using MediatR;
using PublicSite.Application.Features.Albums.Query.GetAll;
using PublicSite.Application.Mappers;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Contacts.Query.GetAll
{
    public class GetAllContactCommandHandler(IContactRepositoryQuery _repository) : IRequestHandler<GetAllContactCommand, GetAllContactResponse>
    {
        public async Task<GetAllContactResponse> Handle(GetAllContactCommand request, CancellationToken cancellationToken)
        {
            var (Result, TotalCount) = await _repository.GetAllContactAsync(request.Limit);

            return new GetAllContactResponse
            {
                Results = Result.ToList(),
                TotalCount = TotalCount
            };
        }
    }
}
