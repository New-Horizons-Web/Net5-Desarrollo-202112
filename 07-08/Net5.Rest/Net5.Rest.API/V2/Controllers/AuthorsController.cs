using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net5.Rest.API.ApplicationServices;
using Net5.Rest.Infrastructure.CrossCutting.Dtos;
using System;

namespace Net5.Rest.API.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILibraryApplicationService _libraryApplicationService;

        public AuthorsController(
            ILibraryApplicationService libraryApplicationService
        )
        {
            _libraryApplicationService = libraryApplicationService;
        }

        [HttpGet]
        public IActionResult GetAuthors([FromQuery] AuthorsResourceParameters authorsResourceParameters)
        {
            return Ok(_libraryApplicationService.GetAuthors(authorsResourceParameters));
        }

        [HttpGet("{id}",Name ="GetAuthor")]
        public IActionResult GetAuthor(Guid id)
        {
            return Ok(_libraryApplicationService.GetAuthor(id));
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            if(author == null)
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.CreateAuthor(author);
            
            return CreatedAtRoute("GetAuthor",new { id = result.AuthorId}, result);
        }

        [HttpPost("/validate")]
        public IActionResult ValidateAuthor([FromBody] AuthorForCreationDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.CreateAuthor(author);

            return CreatedAtRoute("GetAuthor", new { id = result.AuthorId }, result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(Guid id,[FromBody] AuthorForUpdateDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.UpdateAuthor(id, author);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            var result = _libraryApplicationService.DeleteAuthor(id);

            if(result == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
