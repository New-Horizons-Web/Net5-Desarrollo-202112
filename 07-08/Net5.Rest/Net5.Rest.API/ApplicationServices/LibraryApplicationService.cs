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
        
        public List<AuthorDto> GetAuthors(AuthorsResourceParameters authorsResourceParameters)
        {

            var query = from a in _context.Authors
                        select a;

            if (!string.IsNullOrEmpty(authorsResourceParameters.SearchBy)) {
                query = from a in query
                        where
                        a.FirstName.ToLower().Contains(authorsResourceParameters.SearchBy)
                        || a.LastName.ToLower().Contains(authorsResourceParameters.SearchBy)
                        || a.Genre.ToLower().Contains(authorsResourceParameters.SearchBy)
                        select a;
            }
                        
            bool isDesc = true;

            if (authorsResourceParameters.OrderBy.ToLower().Contains("asc"))
            {
                isDesc = false;
            }

            if (authorsResourceParameters.OrderBy.ToLower().Contains("name"))
            {
                if (isDesc)
                {
                    query = query.OrderByDescending(o => o.FirstName);
                }
                else
                {
                    query = query.OrderBy(o => o.FirstName);
                }
            }

            if (authorsResourceParameters.OrderBy.ToLower().Contains("age"))
            {
                if (isDesc)
                {
                    query = query.OrderByDescending(o => o.DateOfBirth);
                }
                else
                {
                    query = query.OrderBy(o => o.DateOfBirth);
                }
            }

            if (authorsResourceParameters.OrderBy.ToLower().Contains("genre"))
            {
                if (isDesc)
                {
                    query = query.OrderByDescending(o => o.Genre);
                }
                else
                {
                    query = query.OrderBy(o => o.Genre);
                }
            }


            int beginRecord = (authorsResourceParameters.PageNumber - 1) * authorsResourceParameters.PageSize;

            query = query.Skip(beginRecord).Take(authorsResourceParameters.PageSize);

            List<AuthorDto> authors = _mapper.Map<List<AuthorDto>>(query.ToList());

            return authors;
        }

        public AuthorDto GetAuthor(Guid authorId)
        {
            AuthorDto author = _mapper.Map<AuthorDto>(_context.Authors.FirstOrDefault(a=>a.AuthorId == authorId));
            return author;
        }

        public AuthorDto CreateAuthor(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _context.Authors.Add(authorEntity);
            _context.SaveChanges();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

            return authorToReturn;
        }

        public AuthorDto UpdateAuthor(Guid authorId,AuthorForUpdateDto author)
        {            
            Author authorFromRepository = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            _mapper.Map(author, authorFromRepository);
            _context.Authors.Update(authorFromRepository);
            _context.SaveChanges();

            var authorToReturn = _mapper.Map<AuthorDto>(authorFromRepository);
            return authorToReturn;
        }

        public AuthorDto DeleteAuthor(Guid authorId)
        {
            Author authorFromRepository = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            _context.Authors.Remove(authorFromRepository);
            _context.SaveChanges();

            var authorToReturn = _mapper.Map<AuthorDto>(authorFromRepository);
            return authorToReturn;
        }
    }
}
