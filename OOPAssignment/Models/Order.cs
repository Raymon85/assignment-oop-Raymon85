using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssignment.Models
{
    public class Order
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int QuantityOrdered { get; set; }
    }
}