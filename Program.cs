// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

List<Plant> plants = new List<Plant>
{
    new Plant()
    {
        Species = "Peace Lily",
        LightNeeds = 3,
        AskingPrice = 15.98M,
        City = "Rockford",
        ZIP = 61106,
        Sold = false
    },
    new Plant()
    {
        Species = "Zombie-Ant Fungus",
        LightNeeds = 1,
        AskingPrice = 45.99M,
        City = "Ocean City",
        ZIP = 21843,
        Sold = false
    },
    new Plant()
    {
        Species = "Venus Flytrap",
        LightNeeds = 5,
        AskingPrice = 18.99M,
        City = "Oxnard",
        ZIP = 93030,
        Sold = true
    },
    new Plant()
    {
        Species = "Rain Lily",
        LightNeeds = 4,
        AskingPrice = 35.32M,
        City = "Aurora",
        ZIP = 80013,
        Sold = false
    },
    new Plant()
    {
        Species = "Angel Eyes",
        LightNeeds = 5,
        AskingPrice = 25.63M,
        City = "Southington",
        ZIP = 06444,
        Sold = false
    }

};

string greeting = @"Welcome to ExtraVert! 
We've got the plant baddies for your plant daddy needs!";
Console.WriteLine(greeting);
string choice = null;

while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
    0. Exit
    1. View All Plants
    2. Give Up For Adoption
    3. Adopt A Plant
    4. Delete A Plant");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListPlants();
    }
    else if (choice == "2")
    {
        GivePlantUpForAdoption();
    }
    else if (choice == "3")
    {
        AdoptAPlant();
    }
    else if (choice == "4")
    {
        PlantWasAdopted();
    }
}

void AdoptAPlant()
{
    ListPlants();
    Plant chosenPlant = null;
    while (chosenPlant == null)
    {
        Console.WriteLine("Please choose a plant: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenPlant = plants[response - 1];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("What in carnation? Do better!");
        }

    }
    Console.WriteLine(@$"You chose:
        {chosenPlant.Species}. It is located in {chosenPlant.City}, {chosenPlant.ZIP}. 
        This {chosenPlant.Species} costs ${chosenPlant.AskingPrice}.");
}


void ListPlants()
{
    Console.WriteLine("Plant options:");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }
}

void GivePlantUpForAdoption()
{


    Console.WriteLine("Not ready for plant parenthood? That's okay, no shame. What kind of plant are you giving up?");
    Console.Write("Species: ");
    string species = Console.ReadLine();

    Console.Write("Light Needs: ");
    double lightneeds = Console.ReadLine();

    Console.Write("Asking Price: ");
    decimal price = Console.ReadLine();

    Console.Write("City: ");
    string city = Console.ReadLine();

    Console.Write("ZIP Code: ");
    int zip = Console.ReadLine();//fix this line





    plants.Add(new Plant()
    {
        Species = species,
        LightNeeds = lightneeds,
        AskingPrice = price,
        City = city,
        ZIP = zip,
        Sold = false
    });

    //.Add method. Check the bookmarked page on methods.
}


void PlantWasAdopted()
{
    // .RemoveAt method OR .Remove
}