// See https://aka.ms/new-console-template for more information
// Console.Clear();

Console.Clear();

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
        Species = "Lion's Mane Mushroom",
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
    },
    new Plant()
    {
        Species = "Nipplewort",
        LightNeeds = 2,
        AskingPrice = 16.45M,
        City = "Toad Suck",
        ZIP = 57209,
        Sold = false
    }

};
Random random = new Random();
int plantOfTheDay = random.Next(1, plants.Count);
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
    4. Delete A Plant
    5. Plant of the Day
    6. Plant Search");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        string yesOrNo = null;
        while (yesOrNo == null)
        {


            Console.WriteLine(@"Are you sure you want to leaf? You haven't botany plants yet.
        (Select 'yes' or 'no')");
            yesOrNo = Console.ReadLine();
            if (yesOrNo == "yes")
            {
                Console.WriteLine("Begonia with you!");
            }
            else if (yesOrNo == "no")
            {

                Console.WriteLine("Kale Yeah!");
                choice = null;
            }
            else
            {
                yesOrNo = null;
                Console.WriteLine("I beg your garden? That wasn't an option.");
            }
        }

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
    else if (choice == "5")
    {
        PlantOfTheDay();
    }
    else if (choice == "6")
    {
        PlantSearch();
    }
}

void AdoptAPlant()
{



    Plant chosenPlant = null;
    while (chosenPlant == null)
    {
        Console.WriteLine("Please choose a plant from our available options: ");

        List<Plant> availablePlants = plants.Where(plant => !plant.Sold).ToList();
        foreach (int index in Enumerable.Range(0, availablePlants.Count))
        {
            Console.WriteLine($@"{index + 1}. {availablePlants[index].Species} located in {availablePlants[index].City}, {availablePlants[index].ZIP} 
        costs ${availablePlants[index].AskingPrice}");
        }

        if (availablePlants.Count == 0)
        {
            Console.WriteLine("All of our plants have been adopted, try again later.");
        }

        try
        {


            int response = int.Parse(Console.ReadLine().Trim());
            chosenPlant = availablePlants[response - 1];
            chosenPlant.Sold = true;

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
    Console.WriteLine("Enjoy your new plant. We be-leaf in you!");
}




void ListPlants()
{
    Console.WriteLine("Plant options:");
    foreach (Plant plant in plants)
    {

        Console.WriteLine(@$"{plant.Species} located in {plant.City} 
            {(plant.Sold ? "was sold" : " is available")} for ${plant.AskingPrice}");



    }
}

void GivePlantUpForAdoption()
{


    Console.WriteLine(@"Not ready for plant parenthood? That's okay, no shame. 
    What kind of plant are you giving up?");
    Console.Write("Species: ");
    string species = Console.ReadLine();

    Console.Write("Light Needs: ");
    double lightneeds = double.Parse(Console.ReadLine());

    Console.Write("Asking Price: ");
    decimal price = decimal.Parse(Console.ReadLine());

    Console.Write("City: ");
    string city = Console.ReadLine();

    Console.Write("ZIP Code: ");
    int zip = int.Parse(Console.ReadLine());


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
    Console.WriteLine(@"Yay! A plant has found its once and floral home!
    Which plants needs to be removed from availability?");
    Console.WriteLine("Available Plants:");
    ListPlants();
    int adoptedPlant = int.Parse(Console.ReadLine());
    if (adoptedPlant <= plants.Count)
    {
        plants.RemoveAt(adoptedPlant - 1);
    }
    else if (adoptedPlant > plants.Count)
    {
        Console.WriteLine(@"That's a thorny issue. What you've selected isn't an option.
        Please try again.");
    }






    // .RemoveAt method OR .Remove
}

void PlantOfTheDay()
{
    Console.WriteLine(@$"Today's featured plant is:
{plants[plantOfTheDay].Species}! This plant {(plants[plantOfTheDay].Sold ? "was sold" : "is available")} for ${plants[plantOfTheDay].AskingPrice}
in {plants[plantOfTheDay].City}, {plants[plantOfTheDay].ZIP}.");
}

void PlantSearch()
{
    int userLight = 0;


    while (userLight == 0)
    {
        try
        {

            Console.WriteLine("On a scale of 1-5, how much light can you offer a plant?");
            userLight = int.Parse(Console.ReadLine());
            if (userLight >= 1 && userLight <= 5)
            {
                List<Plant> availableLight = plants.Where(plant => plant.LightNeeds <= userLight).ToList();
                foreach (Plant plant in availableLight)
                {
                    Console.WriteLine(@$"The following plant(s) meet your criteria:
                    {plant.Species}. 
                    This plant's light needs are a {plant.LightNeeds} on the scale.
                    This {plant.Species} costs ${plant.AskingPrice} and is located in 
                    {plant.City}, {plant.ZIP}.");
                }
            }
            else
            {
                Console.WriteLine("That option is outside of accepted range. Please select a number between 1 and 5.");
                userLight = 0;
            }


        }
        catch (FormatException)
        {
            Console.WriteLine("That was not a valid input. You are the plant version of period cramps.");
        }


    }
}