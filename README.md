# Garage 2.0

En konsolapplikation utvecklad i C# som simulerar ett garagesystem. Projektet är en del av **C# Övning 6** och fokuserar på objektorienterad programmering, arv, samlingar och menyhantering.

## Funktioner

- Skapa ett garage med valfri kapacitet.
- Parkera och hämta ut fordon.
- Lista alla parkerade fordon och deras egenskaper.
- Visa antal fordon av varje typ.
- Söka efter fordon via registreringsnummer, oberoende av versaler och gemener.
- Söka efter fordon med ett eller flera kriterier, exempelvis färg, antal hjul och fordonstyp.
- Hantera felaktig inmatning med tydlig återkoppling till användaren.
- Navigera genom huvudmeny och undermenyer.

## Fordonstyper

Fordon implementeras med basklassen `Vehicle` och följande subklasser:

- `Car`
- `Motorcycle`
- `Airplane`
- `Bus`
- `Boat`

Varje fordon har gemensamma egenskaper, exempelvis registreringsnummer, färg och antal hjul, samt fordonsspecifika egenskaper.

Registreringsnummer ska vara unika.

## Teknik och koncept

- C#
- Objektorienterad programmering (OOP)
- Arv och polymorfism
- Inkapsling
- `List<Vehicle>` för hantering av fordon
- Konsolbaserat användargränssnitt
- Menyer och undermenyer
- Validering och felhantering

## Begränsningar

Projektets grundkrav innebär att:

- Fordonen ska lagras i en privat `List<Vehicle>` i klassen `Garage`.
- Garagets kapacitet ska anges vid instansiering.
- Arrayer, generiska garageklasser och LINQ ska inte användas.
- Enhetstester ingår inte i uppgiften.

## Syfte

Syftet är att tillämpa tidigare kunskaper i C# genom att bygga en sammanhängande applikation med tydlig klassindelning, hantering av objekt och samlingar samt ett användarvänligt konsolgränssnitt.