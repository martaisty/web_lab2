using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace web_lab2.Models.Admin
{
    public class SageUpsert
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
        
        public IFormFile Photo { get; set; }

        public string City { get; set; }

        public List<SageBook> Books { get; set; }
    }

    public class SageBook
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool Selected { get; set; }
    }
}