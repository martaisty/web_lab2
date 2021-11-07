﻿using System.Collections.Generic;
using web_lab2.Abstractions;

namespace web_lab2.Models
{
    public class Order: IEntity<int>
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        public List<Book> Books { get; set; }

        public List<OrdersBooks> OrdersDetails { get; set; }
        
        public int CustomerId { get; set; }
        public User Customer { get; set; }
    }
}