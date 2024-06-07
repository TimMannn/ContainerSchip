using System.Security.Cryptography.X509Certificates;
using ContainerSchip;

Container Containers = new Container();
ContainerStapel containerStapel = new ContainerStapel();
Schip Containerschip = new Schip();


// Grote van schip bepalen
int x = 0;
int y = 0;
while (x == 0)
{
    Console.WriteLine("\nWat is de grote van het schip?");
    Console.Write("x: ");
    var xInput = Console.ReadLine();
    bool CorrectParseX = int.TryParse(xInput, out x);
    containerStapel.x = x;
    Console.Clear();

    if (CorrectParseX == false)
    {
        Console.WriteLine("Ongeldige invoer, probeer opnieuw!");
        x = 0;
        continue;
    }

    if (x <= 0)
    {
        Console.WriteLine("Ongeldige invoer, de breedte mag niet 0 zijn!");
        continue;
    }

    if (x > 5)
    {
        Console.WriteLine("Ongeldige invoer, de maximale breedte is 5 containers!");
        x = 0;
        continue;
    }

    Console.WriteLine("\nWat is de grote van het schip?");
    Console.Write("x: ");
    Console.WriteLine($"{x}");
}

while (y == 0)
{
    Console.Write("y: ");
    var yInput = Console.ReadLine();
    bool CorrectParseY = int.TryParse(yInput, out y);
    containerStapel.y = y;
    Console.Clear();

    if (CorrectParseY == false)
    {
        Console.WriteLine("Ongeldige invoer, probeer opnieuw!");
        y = 0;
    }

    if (y <= 0)
    {
        Console.WriteLine("Ongeldige invoer, de lengte mag niet 0 zijn!");
    }

    if (y > 15)
    {
        Console.WriteLine("Ongeldige invoer, de maximale lengte is 15 containers!");
        y = 0;
    }
    Console.WriteLine("\nWat is de grote van het schip?");
    Console.Write("x: ");
    Console.WriteLine($"{x}");
}

Console.Clear();

// Hoeveel containers komen er op het schip
int ContainerAmount = 0;
int ContainerAmountMemory = 0;

ContainersToevoegen();

void ContainersToevoegen()
{
    bool ContainerInputLoop = true;

    while (ContainerInputLoop)
    {
        Console.WriteLine("Hoeveel containers wil je op het schip zetten?");
        var ContainerInput = Console.ReadLine();

        bool CorrectParse = int.TryParse(ContainerInput, out ContainerAmount);
        if (CorrectParse)
        {
            Console.Clear();
            ContainerInputLoop = false;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ongeldige invoer, probeer opnieuw!");
        }
    }

    ContainerAmountMemory = ContainerAmount + ContainerAmountMemory;
}

// Voeg containers toe aan list
List<Container> containers = new List<Container>();
int Gewicht = 0;
int Soort = 0;
int j = 0;
int GewichtOver = Containerschip.MaximumGewicht;
ContainersAanmaak();

void ContainersAanmaak()
{
    for (int i = 0; i < ContainerAmount; i++)
    {
        Console.Clear();
        Console.WriteLine($"Container: {j + 1} / {ContainerAmountMemory}");
        bool GewichtLoop = true;
        bool SchipVol = false;

        while (GewichtLoop == true)
        {
            Console.WriteLine("\nVoer een gewicht in ton:");
            var GewichtInput = Console.ReadLine();
            bool CorrectParse = int.TryParse(GewichtInput, out Gewicht);

            if (CorrectParse == false)
            {
                Console.Clear();
                Console.WriteLine("Ongeldige invoer, probeer opnieuw!");
                continue;
            }

            if (Gewicht < 4)
            {
                Console.Clear();
                Console.WriteLine("Ongeldige invoer, een container weegt minimaal 4 ton!");
                continue;
            }

            if (Gewicht > 30)
            {
                Console.Clear();
                Console.WriteLine("Ongeldige invoer, het gewicht mag niet meer dan 30 ton zijn!");
                continue;
            }

            if (Gewicht > GewichtOver && GewichtOver > 4)
            {
                Console.Clear();
                Console.WriteLine(
                    $"Je zit boven het maximum gewicht van het schip. Het schip kan nog {GewichtOver} dragen");
                continue;
            }

            if (Gewicht > GewichtOver && GewichtOver < 4)
            {
                Console.Clear();
                Console.WriteLine("Het schip zit op zijn maximum gewicht!");
                Console.WriteLine("Druk op 'enter' om door te gaan.");
                Console.ReadLine();
                SchipVol = true;
                break;
            }

            GewichtOver = Containerschip.MaxGewichtSchip(Gewicht);

            GewichtLoop = false;
        }

        if (SchipVol)
        {
            break;
        }

        bool SoortLoop = true;

        while (SoortLoop == true)
        {
            Console.WriteLine("Wat voor soort container is het?");
            Console.WriteLine("0 = Normaal | 1 = Waardevol | 2 = Gekoeld | 3= WaardevolGekoeld");
            var SoortInput = Console.ReadLine().ToLower();

            if (SoortInput == "0" || SoortInput == "normaal")
            {
                Soort = 0;
            }
            else if (SoortInput == "1" || SoortInput == "waardevol")
            {
                Soort = 1;
            }
            else if (SoortInput == "2" || SoortInput == "gekoeld")
            {
                Soort = 2;
            }
            else if (SoortInput == "3" || SoortInput == "waardevolgekoeld")
            {
                Soort = 3;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ongeldige invoer, probeer opnieuw!\n");
                continue;
            }

            var container = new Container(Gewicht, (Container.Soort)Soort);
            containers.Add(container);
            SoortLoop = false;
        }
        j++;
    }
}

bool MinGewicht = Containerschip.MinGewichtSchip();

if (!MinGewicht)
{
    Console.Clear();
    Console.WriteLine("Het schip is nog niet voor 50% van het gewicht gevult! Voeg meer containers toe.");
    ContainersToevoegen();
    ContainersAanmaak();
}

//Sorteer containers
    var GesorteerdeContainers = containers.OrderBy(c =>
    {
        switch (c.ContainerSoort)
        {
            case Container.Soort.Gekoeld:
                return 1;
            case Container.Soort.WaardevolGekoeld:
                return 2;
            case Container.Soort.Normaal:
                return 3;
            case Container.Soort.Waardevol:
                return 4;
            default:
                return 5;
        }
    });

    // Maak grid aan
    Console.WriteLine("");
containerStapel.ContainerStapelsAanmaken();


// Voeg containers toe aan stapels
int MaxRetrys = x * y;
foreach (var container in GesorteerdeContainers)
{
    Retry:
    int yGrid = Containerschip.yPossitie(container, y);
    int xGrid = Containerschip.xPossitie();

    ContainerStapel Stapel = containerStapel.grid[yGrid, xGrid];
    bool VolleStapel = Stapel.VoegContainerToe(container);
    if (VolleStapel)
    {
        MaxRetrys--;
        if (MaxRetrys == 0)
        {
            Console.WriteLine("Het is niet mogelijk om alle containers op het ship te verdelen. Probeer een groter schip!");
            break;
        }
        goto Retry;
    }
}

// Laat alle containers zien die je hebt aangemaakt
Console.Clear();
int ContainerNumber = 1;
foreach (var container in GesorteerdeContainers)
{
    Console.WriteLine(($"{ContainerNumber} / {ContainerAmountMemory} | Gewicht: {container.Gewicht} ton | Soort: {container.ContainerSoort}"));
    ContainerNumber++;
}

// Laat schip zien
containerStapel.ContainerStapelDisplay();
