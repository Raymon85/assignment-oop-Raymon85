using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment
{
    // Klassen representerar en kundorder
    public class Order
    {
        // Unikt ID för kunden som gjort beställningen
        public string CustomerId { get; set; }

        // Kundens namn
        public string CustomerName { get; set; }

        // Namnet på produkten som beställts
        public string ProductName { get; set; }

        // Antal av produkten som kunden beställt
        public int QuantityOrdered { get; set; }
    }
}
