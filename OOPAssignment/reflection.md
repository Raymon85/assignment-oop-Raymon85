# Reflektion över Lagerhanteringssystem



## Planering
Jag började med att planera projektet genom att definiera de klasser som behövdes: `Product`, `Order` och `InventoryManager`.
Jag beslutade att använda CSV-filer för lagring av produkter och kundordrar. Sedan skapade jag en meny i konsolen för att 
användaren enkelt ska kunna hantera lager och bearbeta ordrar. Jag ritade även en enkel flödesskiss över hur orderbearbetning
och lageruppdatering skulle ske.

---

## Problem
Den svåraste delen var att säkerställa att produktnamn i `orders.csv` exakt matchade produktnamn i lagerfilen. 
Om stavningen inte stämde kunde programmet inte bearbeta ordern. Jag löste detta genom att noggrant kontrollera 
CSV-filerna och använda `FirstOrDefault` i koden för att hantera fall där produkten inte fanns i lager.  

Ett annat problem var att automatiskt spara uppdaterad lagerstatus efter att en produkt lagts till eller lagret fyllts på.
Jag löste detta genom att anropa `SaveUpdatedProductsToCsv` direkt efter dessa operationer.

---

## Stolthet
Jag är mest stolt över att programmet fungerar med automatisk filhantering. När ordrar bearbetas uppdateras lagret direkt
och sparas till fil, vilket gör programmet användarvänligt och robust. Jag är också nöjd med att alla funktioner kan 
användas från en enkel meny i konsolen.

---

## Reflektion för Väl Godkänt (VG)

### Datastrukturer
Jag använde `List<Product>` och `List<Order>` för att lagra produkter respektive kundordrar. Listor var lämpliga eftersom 
de har dynamisk storlek, vilket gör att man enkelt kan lägga till och ta bort element. Dessutom är det lätt att iterera 
igenom listor med foreach-loopar, vilket passar bra för att visa produkter och bearbeta ordrar.

Alternativ hade kunnat vara:
- **Array**: Snabbare åtkomst, men fast storlek, vilket skulle göra det svårare att lägga till nya produkter dynamiskt.  
- **Dictionary**: Kunde ha använts för snabbare uppslagning av produkter baserat på namn, men det hade ökat komplexiteten
- eftersom vi inte behövde nyckelbaserad åtkomst i detta projekt.

---

### Clean Code och Struktur
Jag har arbetat med att hålla koden modulär och läsbar:

- **Namngivning:** Klasser och metoder har tydliga namn (`InventoryManager`, `LoadProductsFromCsv`, `ProcessOrders`) som 
  beskriver exakt vad de gör.  
- **Tydligt ansvar:** `Product` hanterar endast produktinformation och lagerstatus, `Order` innehåller endast orderdata,
  medan `InventoryManager` ansvarar för logiken kring lager och ordrar.  
- **Metoder för att undvika upprepning:** Metoder som `SaveUpdatedProductsToCsv` och `CanFulfillOrder` används flera gånger
  för att undvika duplicerad kod.  
- **Kommentarer:** Jag har kommenterat viktiga delar av koden, t.ex. CSV-läsning, orderbearbetning och filhantering, 
  så att det är tydligt för andra som läser koden.

**Konkreta exempel:**
- Exempel på tydligt ansvar: `Product`-klassen ansvarar endast för att hålla reda på en produkts tillstånd (namn, kategori,
  pris, antal), medan `InventoryManager` ansvarar för att hantera lagerlogik och ordrar.  
- Exempel på undvikande av upprepning: Jag skapade metoden `CanFulfillOrder` som används både vid bearbetning av order och
  vid validering av lagersaldo.  
- Exempel på tydliga namn: Jag använde namn som `QuantityOrdered` och `ProductName` istället för generiska namn som `x` 
  eller `y` för att göra koden mer läsbar.

---

### Framtida utveckling
Projektet är designat för att vara lätt att bygga vidare på. Det är enkelt att:

- Lägga till fler funktioner som rapporter över lagerstatus eller filtrering av produkter.  
- Implementera grafiskt användargränssnitt utan att behöva ändra befintlig logik.  
- Byta CSV-filer mot databaser för mer avancerad lagring.

Svårare att ändra skulle vara grundläggande datastrukturer (om man t.ex. vill byta `List` till `Dictionary`), men logiken 
är separerad till `InventoryManager` vilket gör större ändringar hanterbara. Ansvarsområdena är tydligt separerade mellan
klasserna, vilket underlättar framtida underhåll.




