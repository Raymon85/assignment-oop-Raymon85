using System;
using System.IO;

namespace OOPAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapar en instans av InventoryManager som hanterar produkter och ordrar
            InventoryManager manager = new InventoryManager();

            try
            {
                // Försök att ladda den uppdaterade lagersfilen först
                string inventoryFile = "Data/inventory_updated.csv";

                if (!File.Exists(inventoryFile))
                {
                    // Om den uppdaterade filen inte finns, ladda den ursprungliga inventory-filen
                    inventoryFile = "Data/inventory.csv";
                    Console.WriteLine("Laddar ursprunglig inventory fil...");
                }
                else
                {
                    // Om inventory_updated.csv finns, använd den
                    Console.WriteLine("Laddar uppdaterad inventory fil...");
                }

                // Ladda produkter och ordrar från CSV-filer
                manager.LoadProductsFromCsv(inventoryFile);
                manager.LoadOrdersFromCsv("Data/orders.csv");

                bool running = true;

                // Huvudmenyloop
                while (running)
                {
                    Console.WriteLine("\n=== LAGERMENY ===");
                    Console.WriteLine("1. Visa alla produkter");
                    Console.WriteLine("2. Lägg till produkt");
                    Console.WriteLine("3. Fyll på lager");
                    Console.WriteLine("4. Bearbeta ordrar");
                    Console.WriteLine("5. Spara lager till fil");
                    Console.WriteLine("6. Avsluta");
                    Console.Write("Välj alternativ: ");

                    string? input = Console.ReadLine(); // Läser användarens val

                    // Hantera användarens val med switch
                    switch (input)
                    {
                        case "1":
                            // Visa alla produkter i lagret
                            manager.ShowAllProducts();
                            break;

                        case "2":
                            // Lägg till en ny produkt i lagret (sparas automatiskt)
                            manager.AddProduct();
                            break;

                        case "3":
                            // Fyll på lagret för en produkt (sparas automatiskt)
                            manager.RestockProduct();
                            break;

                        case "4":
                            // Bearbeta alla ordrar
                            manager.ProcessOrders();
                            // Spara uppdaterad produktlista efter orderhantering
                            manager.SaveUpdatedProductsToCsv("Data/inventory_updated.csv");
                            break;

                        case "5":
                            // Spara lager manuellt till fil
                            manager.SaveUpdatedProductsToCsv("Data/inventory_updated.csv");
                            Console.WriteLine("Lagret har sparats!");
                            break;

                        case "6":
                            // Avsluta programmet
                            running = false;
                            Console.WriteLine("Avslutar programmet...");
                            break;

                        default:
                            // Felaktigt val
                            Console.WriteLine("Felaktigt val, försök igen.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Fånga och visa eventuella fel under körning
                Console.WriteLine($"Fel uppstod: {ex.Message}");
            }
        }
    }
}
