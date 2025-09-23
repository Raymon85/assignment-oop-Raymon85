using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOPAssignment
{
    // Klassen InventoryManager hanterar produkter och kundordrar
    public class InventoryManager
    {
        // Lista med alla produkter i lagret
        private List<Product> products = new List<Product>();

        // Lista med alla kundordrar
        private List<Order> orders = new List<Order>();

        // Metod för att läsa produkter från en CSV-fil
        public void LoadProductsFromCsv(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Filen {filePath} finns inte.");

            var lines = File.ReadAllLines(filePath);

            // Hoppa över rubrikraden (index 0)
            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length != 4) continue; // Kontrollera att raden är korrekt formaterad

                // Skapa produktobjekt och lägg till i listan
                products.Add(new Product
                {
                    Name = parts[0],
                    Category = parts[1],
                    Price = decimal.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture),
                    Quantity = int.Parse(parts[3])
                });
            }

            Console.WriteLine($"{products.Count} produkter inlästa från {filePath}.");
        }

        // Metod för att läsa ordrar från en CSV-fil
        public void LoadOrdersFromCsv(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Filen {filePath} finns inte.");

            var lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length != 4) continue;

                // Skapa orderobjekt och lägg till i listan
                orders.Add(new Order
                {
                    CustomerId = parts[0],
                    CustomerName = parts[1],
                    ProductName = parts[2],
                    QuantityOrdered = int.Parse(parts[3])
                });
            }

            Console.WriteLine($"{orders.Count} ordrar inlästa.");
        }

        // Metod för att bearbeta alla ordrar
        public void ProcessOrders()
        {
            int successful = 0, failed = 0;

            foreach (var order in orders)
            {
                // Hitta produkten som beställts
                var product = products.FirstOrDefault(p => p.Name == order.ProductName);

                if (product == null)
                {
                    Console.WriteLine($"✗ Order från {order.CustomerName} kunde inte skickas: Produkten finns ej.");
                    failed++;
                    continue;
                }

                // Kontrollera om lagret räcker
                if (product.CanFulfillOrder(order.QuantityOrdered))
                {
                    product.ReduceQuantity(order.QuantityOrdered); // Minska lagret
                    Console.WriteLine($"✓ Order från {order.CustomerName} skickad: {order.QuantityOrdered}x {product.Name}");
                    successful++;
                }
                else
                {
                    Console.WriteLine($"✗ Order från {order.CustomerName} kunde inte skickas: Otillräckligt lager (begärt: {order.QuantityOrdered}, finns: {product.Quantity})");
                    failed++;
                }
            }

            // Sammanfattning efter orderbearbetning
            Console.WriteLine($"\nOrderbearbetning slutförd!");
            Console.WriteLine($"- {successful} ordrar skickade");
            Console.WriteLine($"- {failed} order kunde inte skickas");
        }

        // Metod för att spara uppdaterad produktlista till CSV
        public void SaveUpdatedProductsToCsv(string filePath)
        {
            try
            {
                // Skapa katalogen om den inte finns
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // Skriv rubrikrad
                    writer.WriteLine("Name,Category,Price,Quantity");

                    // Skriv varje produkt
                    foreach (var product in products)
                    {
                        string line = $"{product.Name},{product.Category},{product.Price.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)},{product.Quantity}";
                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine($"Lagret har sparats till {filePath}");
                Console.WriteLine($"Totalt {products.Count} produkter sparade.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid sparande: {ex.Message}");
            }
        }

        // Visa alla produkter i lagret
        public void ShowAllProducts()
        {
            Console.WriteLine("\n--- Alla produkter ---");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} | Kategori: {p.Category} | Pris: {p.Price} | Antal i lager: {p.Quantity}");
            }
        }

        // Lägg till ny produkt, sparas automatiskt till fil
        public void AddProduct()
        {
            Console.Write("Produktnamn: ");
            string name = Console.ReadLine();
            Console.Write("Kategori: ");
            string category = Console.ReadLine();
            Console.Write("Pris: ");
            decimal price = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
            Console.Write("Antal i lager: ");
            int quantity = int.Parse(Console.ReadLine());

            products.Add(new Product
            {
                Name = name,
                Category = category,
                Price = price,
                Quantity = quantity
            });

            Console.WriteLine($"Produkten {name} har lagts till.");

            // Spara direkt till fil
            SaveUpdatedProductsToCsv("Data/inventory_updated.csv");
            Console.WriteLine("Produkten har sparats till filen.");
        }

        // Fyll på lager för en befintlig produkt, sparas automatiskt till fil
        public void RestockProduct()
        {
            Console.Write("Vilken produkt vill du fylla på? ");
            string name = Console.ReadLine();
            var product = products.FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                Console.WriteLine("Produkten finns inte.");
                return;
            }

            Console.Write("Hur många vill du lägga till? ");
            int amount = int.Parse(Console.ReadLine());

            product.Quantity += amount;
            Console.WriteLine($"{amount} enheter har lagts till på {product.Name}. Nu finns {product.Quantity} i lager.");

            // Spara direkt till fil
            SaveUpdatedProductsToCsv("Data/inventory_updated.csv");
            Console.WriteLine("Lagret har sparats till filen.");
        }
    }
}
