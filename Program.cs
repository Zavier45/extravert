// See https://aka.ms/new-console-template for more information
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
        Sold = true,
        AvailableUntil = new DateTime(2024,12,23)
    },
    new Plant()
    {
        Species = "Lion's Mane Mushroom",
        LightNeeds = 1,
        AskingPrice = 25.99M,
        City = "Ocean City",
        ZIP = 21843,
        Sold = false,
        AvailableUntil = new DateTime(2026, 1, 23)
    },
    new Plant()
    {
        Species = "Venus Flytrap",
        LightNeeds = 4,
        AskingPrice = 18.99M,
        City = "Oxnard",
        ZIP = 93030,
        Sold = false,
        AvailableUntil = new DateTime(2024, 6, 21)
    },
    new Plant()
    {
        Species = "Rain Lily",
        LightNeeds = 4,
        AskingPrice = 35.32M,
        City = "Aurora",
        ZIP = 80013,
        Sold = false,
        AvailableUntil = new DateTime(2028, 2, 14)
    },
    new Plant()
    {
        Species = "Angel Eyes",
        LightNeeds = 5,
        AskingPrice = 25.63M,
        City = "Southington",
        ZIP = 06444,
        Sold = false,
        AvailableUntil = new DateTime(2024,8,22)
    },
    new Plant()
    {
        Species = "Nipplewort",
        LightNeeds = 2,
        AskingPrice = 16.45M,
        City = "Toad Suck",
        ZIP = 57209,
        Sold = false,
        AvailableUntil = new DateTime(2024,4,20)
    },
    new Plant()
    {
        Species = "Widow's Thrill",
        LightNeeds= 5,
        AskingPrice = 15.85M,
        City = "Hendersonville",
        ZIP = 37075,
        Sold = true,
        AvailableUntil = new DateTime (2024, 1, 26)
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
    6. Plant Search
    7. View App Statistics");
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
    else if (choice == "7")
    {
        PlantStats();
    }
}

void AdoptAPlant()
{
    Plant chosenPlant = null;
    while (chosenPlant == null)
    {
        Console.WriteLine("Please choose a plant from our available options: ");

        List<Plant> availablePlants = plants.Where(plant => !plant.Sold && plant.AvailableUntil > DateTime.Now).ToList();

        foreach (int index in Enumerable.Range(0, availablePlants.Count))
        {
            Console.WriteLine($@"{index + 1}. {availablePlants[index].Species} located in {availablePlants[index].City}, {availablePlants[index].ZIP} 
        costs ${availablePlants[index].AskingPrice}");
        }

        if (availablePlants.Count == 0)
        {
            Console.WriteLine("All of our plants have been adopted, try again later.");
            return;
        }
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenPlant = availablePlants[response - 1];
            chosenPlant.Sold = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("What in carnation? Do better!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("You're family tree's a trunk, isn't it? Try again.");
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

    string species = null;
    while (species == null)
    {
        try
        {
            Console.Write("Species: ");
            species = Console.ReadLine();
        }
        catch (FormatException)
        {
            Console.WriteLine("You succ-ulent! Try again!");
        }
    }

    double lightneeds = 0;
    while (lightneeds == 0)
    {
        try
        {
            Console.Write("Light Needs: ");
            lightneeds = double.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Be-leaf me when I say this, that was wrong. Try again.");
        }
    }

    decimal price = 0M;
    while (price == 0M)
    {
        try
        {
            Console.Write("Asking Price: ");
            price = decimal.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Your endeavors are fruitless! Try again.");
        }
    }

    string city = null;
    while (city == null)
    {
        try
        {
            Console.Write("City: ");
            city = Console.ReadLine();
        }
        catch (FormatException)
        {
            Console.WriteLine("A plant worked very hard for the oxygen you're wasting. Do better.");
        }
    }

    int zip = 0;
    while (zip == 0)
    {
        try
        {
            Console.Write("ZIP Code: ");
            zip = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Your ideas die on the vine. Try again.");
        }
    }

    int year = 0;
    while (year == 0)
    {
        try
        {
            Console.WriteLine("This plant is available until what date? (Please enter numerical values only)");
            Console.Write("Year: ");
            year = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Your root aren't deep, and your leaves are withered. Do better.");
        }
    }

    int month = 0;
    while (month == 0)
    {
        try
        {
            Console.WriteLine("Month: ");
            month = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Late bloomer, huh? Try again.");
        }
    }

    int day = 0;
    while (day == 0)
    {
        try
        {
            Console.WriteLine("Day: ");
            day = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("You're a lumberjack's tutorial level, you hiking stick. Try again.");
        }
    }

    DateTime dateTime = new DateTime(year, month, day);
    plants.Add(new Plant()
    {
        Species = species,
        LightNeeds = lightneeds,
        AskingPrice = price,
        City = city,
        ZIP = zip,
        Sold = false,
        AvailableUntil = dateTime
    });

    //.Add method. Check the bookmarked page on methods.
}



void PlantWasAdopted()
{
    Console.WriteLine(@"Yay! A plant has found its once and floral home!
    Which plants needs to be removed from availability?");
    Console.WriteLine("Available Plants:");
    ListPlants();
    int adoptedPlant = 0;
    while (adoptedPlant == 0)
    {
        try
        {
            adoptedPlant = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("You'd do more good as mulch! Do better.");
        }
    }

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
                    This {PlantDetails} costs ${plant.AskingPrice} and is located in 
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

void PlantStats()
{
    /*
        plant with the lowest cost
        how many plants are available
            through a Count method?
        plant with highest light needs
        average light needs of ALL plants
        % of plants that have been adopted
        */
    Plant lowestCostPlant = plants.FirstOrDefault(plant => plant.AskingPrice == plants.Min(p => p.AskingPrice));

    Console.WriteLine(@$"The least expensive plant available is the {lowestCostPlant.Species}
    It costs {lowestCostPlant.AskingPrice}.
    ");

    List<Plant> availablePlants = plants.Where(plant => !plant.Sold && plant.AvailableUntil > DateTime.Now).ToList();

    Console.WriteLine($"There are {availablePlants.Count} plants available to adopt.\n");

    double mostLightNeeds = plants.Max(plant => plant.LightNeeds);
    List<Plant> plantsWithMostLightNeeds = plants.Where(p => p.LightNeeds == mostLightNeeds).ToList();
    foreach (Plant plant in plantsWithMostLightNeeds)
    {
        Console.WriteLine(@$"The {plant.Species} needs the most sunlight.
    On a scale of 1 to 5, it needs a {plant.LightNeeds}.
    ");
    }

    double averageLightNeeds = plants.Average(plant => plant.LightNeeds);
    int roundedLightAverage = (int)Math.Round(averageLightNeeds);
    Console.WriteLine(@$"Average Light Needs of All Plants:
{roundedLightAverage}.
");

    //plantsAdopted * 100, / totalPlants
    List<Plant> plantsAdopted = plants.Where(plant => plant.Sold == true).ToList();
    int totalPlants = plants.Count;
    double percentagePlantsAdopted = (double)Math.Round((double)(plantsAdopted.Count * 100) / totalPlants);
    Console.WriteLine($"{percentagePlantsAdopted} percent of our plants have found new homes!");

}

string PlantDetails(Plant plant)
{
    string plantString = plant.Species;
    return plantString;
}