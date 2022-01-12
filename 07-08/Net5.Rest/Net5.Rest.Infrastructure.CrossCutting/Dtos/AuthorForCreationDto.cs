using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Rest.Infrastructure.CrossCutting.Dtos
{
    public class AuthorForCreationDto
    {
        public AuthorForCreationDto()
        {
            Books = new List<BookForCreationDto>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<BookForCreationDto> Books { get; set; }
    }
}
