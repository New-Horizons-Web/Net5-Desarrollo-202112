using System.Collections.Generic;

namespace Net5.AspNetCore.Client.MVC.Models
{
    public class IndexViewModel
    {
        public List<MovieViewModel> Movies { get; set; }
        public string PageTitle { get; set; }
        public string UserName { get; set; }
    }
}
