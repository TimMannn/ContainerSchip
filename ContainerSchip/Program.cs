using ContainerSchip;

// Hoeveel containers komen er op het schip
int ContainerAmount = 0;
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


// Grote van schip bepalen
Console.WriteLine("\nWat is de grote van het schip?");
Console.Write("x: ");
var x = Console.ReadLine();
Console.Write("y: ");
var y = Console.ReadLine();
Console.Clear();


// Voeg containers toe aan list
List<Container> containers = new List<Container>();
int Gewicht = 0;
int Soort = 0;

for (int i = 0; i < ContainerAmount; i++)
{
    Console.Clear();
    Console.WriteLine($"Container: {i + 1} / {ContainerAmount}");
    bool GewichtLoop = true;

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
        GewichtLoop = false;
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


    // Laat alle containers zien die je hebt aangemaakt
    Console.Clear();
    int ContainerNumber = 1;
    foreach (var container in containers)
    {
        Console.WriteLine(($"{ContainerNumber} / {ContainerAmount} | Gewicht: {container.Gewicht} ton | Soort: {container.ContainerSoort}"));
        ContainerNumber++;
    }
}



