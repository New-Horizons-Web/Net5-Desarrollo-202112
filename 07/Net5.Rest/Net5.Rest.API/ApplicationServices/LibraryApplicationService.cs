using AutoMapper;
using Net5.Rest.Infrastructure.CrossCutting.Dtos;
using Net5.Rest.Infrastructure.Data.Contexts;
using Net5.Rest.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Net5.Rest.API.ApplicationServices
{
    public class LibraryApplicationService : ILibraryApplicationService
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;
        public LibraryApplicationService(
            LibraryContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDto CreateAuthor(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _context.Authors.Add(authorEntity);
            _context.SaveChanges();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

            return authorToReturn;
        }

        public AuthorDto GetAuthor(Guid authorId)
        {
            AuthorDto author = _mapper.Map<AuthorDto>(_context.Authors.FirstOrDefault(a=>a.AuthorId == authorId));
            return author;
        }

        public List<AuthorDto> GetAuthors()
        {
            List<AuthorDto> authors = _mapper.Map<List<AuthorDto>>(_context.Authors.ToList());
            return authors;
        }
    }
}
