using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Rest.Infrastructure.CrossCutting.Dtos
{
    public class AuthorsResourceParameters
    {
        const int maxPageSize = 20;

        public string OrderBy { get; set; } = "Name";
        public string SearchBy { get; set; }

        private int _pageSize = 10;
        public int PageSize { get { return _pageSize; } set { _pageSize = (value > maxPageSize) ? maxPageSize : value; } }
        public int PageNumber { get; set; } = 1;
    }
}
