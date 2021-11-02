using System.Collections.Generic;

namespace web_lab2.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Sage> Sages { get; set; }

        public List<Order> Orders { get; set; }

        public List<OrdersBooks> OrdersDetails { get; set; }
    }
}