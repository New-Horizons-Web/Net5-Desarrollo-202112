using Net5.Rest.Infrastructure.CrossCutting.Dtos;
using System;
using System.Collections.Generic;

namespace Net5.Rest.API.ApplicationServices
{
    public interface ILibraryApplicationService
    {
        List<AuthorDto> GetAuthors();
        AuthorDto GetAuthor(Guid authorId);
        AuthorDto CreateAuthor(AuthorForCreationDto author);
    }
}