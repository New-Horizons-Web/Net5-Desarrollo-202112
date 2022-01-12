using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Rest.Infrastructure.CrossCutting.Dtos
{
    public abstract class BookForManipulationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
