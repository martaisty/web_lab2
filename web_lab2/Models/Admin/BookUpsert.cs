using System.Collections.Generic;

namespace web_lab2.Models.Admin
{
    public class BookUpsert
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<BookSage> Sages { get; set; }
    }

    public class BookSage
    {
        public bool Selected { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }
}