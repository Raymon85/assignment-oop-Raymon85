using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment
{
    public class Product
    {
        // Egenskaper (properties) för produktinformation

        // Namnet på produkten
        public string Name { get; set; }

        // Kategorin produkten tillhör (t.ex. "Elektronik", "Livsmedel")
        public string Category { get; set; }

        // Priset för produkten
        public decimal Price { get; set; }

        // Antal produkter i lager
        public int Quantity { get; set; }

        // Metod för att kontrollera om en order kan uppfyllas
        // Returnerar true om det finns tillräckligt med produkter i lager
        public bool CanFulfillOrder(int requestedQuantity)
        {
            return Quantity >= requestedQuantity;
        }

        // Metod för att minska lagersaldot efter att en order har bearbetats
        public void ReduceQuantity(int amount)
        {
            // Dra av det angivna antalet från Quantity
            Quantity -= amount;
        }
    }
}
