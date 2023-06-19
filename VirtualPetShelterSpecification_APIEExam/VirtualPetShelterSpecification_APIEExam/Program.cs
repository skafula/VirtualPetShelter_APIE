using VirtualPetShelterSpecification_APIEExam;

public class Program
{
    public static VirtualPetHostel shelter;
    // Display pets on Console
    public static void DisplayAllPetsInShelter()
    {
        shelter.ListAllPetsInShelter();
    }
    // Just test if i can make a "round" simulation
    public static void SimulateRoundSolo(VirtualPet pet)
    {
        List<VirtualPet> pets = new List<VirtualPet>();    
        foreach (VirtualPet p in shelter.allPetsInShelter) 
        {
            if (p == pet)
            {
                continue;
            }
            pets.Add(p);
        }
        foreach (VirtualPet p in pets) 
        {
            p.SimulateRound();
        }
    }
    // MenuBar for user interaction
    public static int AskUserForPetInteraction()
    {
        var menuBuilder = new System.Text.StringBuilder();
        menuBuilder.AppendLine("Mit szeretnél csinálni: ");
        menuBuilder.AppendLine(string.Empty);
        menuBuilder.AppendLine("1) Összes bioállat megetetése.");
        menuBuilder.AppendLine("2) Összes bioállat megitatása.");
        menuBuilder.AppendLine("3) Szükségletek elvégzésére kísérés.");
        menuBuilder.AppendLine("4) Összes kutya sétáltatása.");
        menuBuilder.AppendLine("5) Biokutyaketrecek takarítása.");
        menuBuilder.AppendLine("6) Robotállatok beolajozása.");
        menuBuilder.AppendLine("7) Játszani az egyik házikedvenccel.");
        menuBuilder.AppendLine("8) Új állat befogadása.");
        menuBuilder.AppendLine("9) Kisállat felajánlása örökbefogadásra.");
        menuBuilder.AppendLine("10) Kisállat állapota.");
        menuBuilder.AppendLine("11) Kisállat etetése.");
        menuBuilder.AppendLine("0) Kilépés a játékból.");

        Console.WriteLine(menuBuilder.ToString());

        int x;
        string userInput = Console.ReadLine();

        while (!Int32.TryParse(userInput, out x) && ((x > 9) || (x < 0)))
        {
            Console.WriteLine("Nem megfelelő érték.");
            userInput = Console.ReadLine();
        }
        return x;
    }
    // Program makes the selected action
    public static void PerformActionOnPet(int userSelect)
    {
        switch (userSelect)
        {
            case 0:
                Console.WriteLine("A kilépést választottad. Minden jót!");
                System.Environment.Exit(0);
                break;
            case 1:
                shelter.FeedAllOrganicPets();
                break;
            case 2:
                shelter.WaterAllOrganicPets();
                break;
            case 3:
                shelter.BathroomBreakAllOrganicPets();
                break;
            case 4:
                shelter.WalkAllDogs();
                break;
            case 5:
                shelter.CleanCagesForAllOrganicDogs();
                break;
            case 6:
                shelter.OilAllRoboticPets();
                break;
            case 7:
                var pet = AskUserWhichPetToInteractWith();
                pet.PlayWithPet();
                SimulateRoundSolo(pet);
                break;
            case 8:
                var newPet = AskUserForNewPetInfo();
                shelter.AddHomelessPetToShelter(newPet);
                SimulateRoundSolo(newPet);
                break;
            case 9:
                AdoptPet();
                break;
            case 10:
                var petStatus = AskUserWhichPetToInteractWith();
                Console.WriteLine(petStatus.ToString());
                break;
            case 11:
                var petFeed = AskUserWhichPetToInteractWith();
                //DecideKindOfPet(petFeed).FeedPet();
                petFeed.FeedPet();
                SimulateRoundSolo(petFeed);
                break;
        }
    }
    // Method for get a solo pet
    public static VirtualPet AskUserWhichPetToInteractWith()
    {
        Console.Write("Add meg a kiválasztott állat nevét: ");
        string userInput = Console.ReadLine();
        var pet = shelter.CheckIfPetNameMatch(userInput);
        
        return pet;
    }
    // Optionally made an extra method to select adopted pet by User
    public static void AdoptPet()
    {
        Console.WriteLine("Add meg az örökbefogadandó nevét: ");
        string name = Console.ReadLine();
        shelter.GiveUpPetForAdoption(name);
    }
    // Add new pet by User
    public static VirtualPet AskUserForNewPetInfo()
    {
        Console.WriteLine("Add meg az állat nevét: ");
        string name = Console.ReadLine();
        Console.WriteLine("Robot (1), vagy Organic (2): ");

        int type;
        string userInput = Console.ReadLine();

        while (!Int32.TryParse(userInput, out type) && ((type > 2) || (type < 0)))
        {
            Console.WriteLine("Nem megfelelő érték.");
            userInput = Console.ReadLine();
        }

        Console.WriteLine("Kutya (1), vagy Macska (2): ");
        int catOrDog;
        userInput = Console.ReadLine();

        while (!Int32.TryParse(userInput, out catOrDog) && ((catOrDog > 2) || (catOrDog < 0)))
        {
            Console.WriteLine("Nem megfelelő érték.");
            userInput = Console.ReadLine();
        }
        switch (type)
        {
            case 1:
                if (catOrDog == 1)
                {
                    RobotDog robotDog = new RobotDog(name);
                    return robotDog;
                }
                else
                {
                    RobotCat robotCat = new RobotCat(name);
                    return robotCat;
                }
            case 2:
                if (catOrDog == 1)
                {
                    OrganicDog organicDog = new OrganicDog(name);
                    return organicDog;
                }
                else
                {
                    OrganicCat organicCat = new OrganicCat(name);
                    return organicCat;
                }
        }
        return null;
    }
    public static void Main(string[] args)
    {
        // Instance shelter to build up VirtualPetHostel
        shelter = new VirtualPetHostel();

        // Welcome message
        Console.WriteLine("Üdvözöllek a játékban!\n\nEz a játék egy virtuális állatmenhelyet szimulál. Lehetőséged van az állatokkal interaktálni és a menhelyen különböző tevékenységeket végezni." +
                            "\nA játék akkor ér véget, ha legalább az egyik állat kedve 0-ra csökken, vagy ha a kilépés parancsot választod." +
                            "\n\nJó szórakozást!");

        // Cycle to do something by User untel any pet's happiness goes "< 1"
        do
        {
            DisplayAllPetsInShelter();
            PerformActionOnPet(AskUserForPetInteraction());

            Console.WriteLine("__________________________________________________");
            //if (shelter.IsAnyPetHappinessZero())
            //{
            //    Console.WriteLine("Sajnáljuk, a játék véget ért!");
            //    System.Environment.Exit(0);
            //}
        }
        while (!shelter.IsAnyPetHappinessZero());

        Console.WriteLine("A játék véget ért.");
    }
}