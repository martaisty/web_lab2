using System.Collections.Generic;

namespace web_lab2.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        public string Customer { get; set; }

        public List<Book> Books { get; set; }

        public List<OrdersBooks> OrdersDetails { get; set; }
    }
}