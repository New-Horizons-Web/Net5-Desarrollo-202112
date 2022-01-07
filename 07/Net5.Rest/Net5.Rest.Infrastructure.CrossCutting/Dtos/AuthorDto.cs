using System;

namespace Net5.Rest.Infrastructure.CrossCutting.Dtos
{
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
    }
}
