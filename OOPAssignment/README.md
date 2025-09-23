# Lagerhanteringssystem - Rayan Monfared

## Beskrivning
Detta projekt är ett konsolbaserat lagerhanteringssystem utvecklat i C#. 
Programmet hanterar produkter och kundordrar och låter användaren:

- Visa alla produkter i lager
- Lägg till nya produkter
- Fyll på lager för befintliga produkter
- Bearbeta kundordrar
- Spara lagerstatus till fil

Programmet använder CSV-filer (`inventory.csv`, `inventory_updated.csv`, `orders.csv`) för att läsa och spara data. 
Jag har valt alternativet med **automatisk filhantering**, där uppdaterad lagerstatus sparas direkt efter att en produkt
läggs till eller lagret fylls på.

## Skärmbild
![Program i körning](SS.Raymon)  


## Instruktioner för att köra programmet
1. **Kloning av projektet**
  
   git clone https://github.com/Raymon85/assignment-oop-Raymon85.git

 ## Starta programmet
1.	Öppna Lagerhanteringssystem.sln eller projektmappen.

2.	Tryck F5 eller klicka på "Start" (grön triangel).

## Användning
. Programmet visar en meny i konsolen.

. Välj alternativ genom att skriva siffran för önskad funktion och tryck Enter.

	Exempel:

	1 Visa alla produkter
	2 Lägg till produkt
	3 Fyll på lager
	4 Bearbeta ordrar
	5 Spara lager till fil
	6 Avsluta programmet

. Programmet läser och uppdaterar CSV-filer automatiskt.


## Funktioner
Grundfunktioner
Visa alla produkter i lager
Lägg till ny produkt
Fyll på lager för befintliga produkter
Bearbeta kundordrar och uppdatera lagerstatus
Spara lagerstatus till CSV-fil

Extra funktioner 
Automatisk sparning av lager vid ändringar
Smarta uppdateringar: programmet laddar alltid den senaste lagerfilen (inventory_updated.csv)

## Filstruktur
projektmapp/
├── Data/
│   ├── inventory.csv
│   ├── inventory_updated.csv
│   └── orders.csv
├── Program.cs
├── Product.cs
├── Order.cs
├── InventoryManager.cs
├── README.md
├── reflection.md


## Teknisk information
Programmeringsspråk: C#
Framework: .NET 8.0
Utvecklingsmiljö: Visual Studio / VS Code


## Spara projektet för framtida referens
1. Forka projektet till ditt privata GitHub-konto för att skapa en permanent kopia.
2. Uppdatera README med din privata fork-länk.

## Länkar
. GitHub Repository: https://github.com/Raymon85/assignment-oop-Raymon85
. Din privata fork: https://github.com/Raymon85/assignment-oop-Raymon85/fork
