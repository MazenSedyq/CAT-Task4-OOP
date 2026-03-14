using SuperheroBattleArena;
using System.Threading;


public static class Screen
{
    public static void MainMenu()
    {
        PrintHeader();

        Console.WriteLine("[1] NEW GAME");
        Console.WriteLine("[2] HOW TO PLAY");

        int choice;
        while (true)
        {
            Console.Write("\nChoose");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out choice) && (choice == 1 || choice == 2))
                break; 
            Console.WriteLine("  Invalid choice. Try again.");
        }

        if (choice == 1)
            StartGame();
        else
            HowToPlay();
    }
  
    static void StartGame()
    {
        bool playAgain = true;

        while (playAgain)
        {
            PrintHeader();

            Console.WriteLine("Create Fighter 1");
            BaseHero fighter1 = CreateHero();

            Console.WriteLine();
            Console.WriteLine("Create Fighter 2");
            BaseHero fighter2 = CreateHero();

            if (fighter1.GetType() == fighter2.GetType() && string.Equals(fighter1.Name, fighter2.Name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine();
                Console.WriteLine("A hero cannot fight themselves (same type and name). Create fighters again.");
                Console.WriteLine("  Press any key to continue...");
                Console.ReadKey(true);
                continue;
            }

            BattleArena.StartBattle(CloneHero(fighter1), CloneHero(fighter2));

            Console.Write("  Play again? (y/n): ");
            playAgain = Console.ReadLine()?.Trim().ToLower() == "y";
        }

        Console.WriteLine();
        Console.WriteLine("  Thanks for playing!");
    }

    static void HowToPlay()
    {

        PrintHeader();
        Console.WriteLine("HOW TO PLAY");
        Console.WriteLine();

        Console.WriteLine("Overview:");
        Console.WriteLine("  - Battles are turn-based. Each fighter takes turns choosing an action.");
        Console.WriteLine("  - Core stats:");
        Console.WriteLine("      Power    (P): Determines the base damage of hits.");
        Console.WriteLine("      Accuracy (A): Chance your attacks hit; low Accuracy increases misses.");
        Console.WriteLine("      Health   (H): How much damage you can take. If this reaches 0 you lose.");
        Console.WriteLine("      Recovery (R): How much you regain health.");
        Console.WriteLine();

        Console.WriteLine("Heros Pros & Cons:");
        Console.WriteLine();

        Console.WriteLine("  Warrior");
        Console.WriteLine("    - Pros : High Power, and Health.");
        Console.WriteLine("    - Cons : Lower Accuracy and Recover.");
        Console.WriteLine();

        Console.WriteLine("  Mage");
        Console.WriteLine("    - Pros : High Recover and good Accuracy.");
        Console.WriteLine("    - Cons :Low Power and Health.");
        Console.WriteLine();

        Console.WriteLine("  Archer");
        Console.WriteLine("    - Pros : High Accuracy and consistent damage.");
        Console.WriteLine("    - Cons : Moderate Power Health and Recover.");
        Console.WriteLine();

        Console.WriteLine("  Press any key to go back to the main menu...");
        Console.ReadKey();
        MainMenu();
    }


    static void PrintHeader()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║          SUPERHERO BATTLE ARENA          ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        Console.WriteLine();
    }
    static BaseHero CreateHero()
    {
        int typeIndex = PickHeroType("Choose your hero type");
        string defaultName = typeIndex switch
        {
            0 => "Warrior",
            1 => "Mage",
            2 => "Archer",
            _ => "Hero"
        };

        string name = PromptForName($"  Enter name for the {GetHeroTypeName(typeIndex)}", defaultName);

        return typeIndex switch
        {
            0 => new Warrior(name),
            1 => new Mage(name),
            2 => new Archer(name),
            _ => throw new InvalidOperationException("Invalid hero type selected")
        };
    }

    static int PickHeroType(string prompt)
    {
        Console.WriteLine($"  {prompt}:");
        Console.WriteLine("    [1] Warrior ");
        Console.WriteLine("    [2] Mage   ");
        Console.WriteLine("    [3] Archer   ");

        int choice;
        while (true)
        {
            Console.Write("  Choose type (1–3): ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 3)
                return choice - 1; // 0: Warrior, 1: Mage, 2: Archer
            Console.WriteLine("  Invalid choice. Try again.");
        }
    }

    static string GetHeroTypeName(int typeIndex) => typeIndex switch
    {
        0 => "Warrior",
        1 => "Mage",
        2 => "Archer",
        _ => "Hero"
    };

    static BaseHero CloneHero(BaseHero h) => h switch
    {
        Warrior w => new Warrior(w.Name),
        Mage m => new Mage(m.Name),
        Archer a => new Archer(a.Name),
        _ => throw new InvalidOperationException("Unknown hero type")
    };

    static string PromptForName(string prompt, string defaultName)
    {
        Console.Write($"{prompt} (default: {defaultName}): ");
        string? input = Console.ReadLine()?.Trim();
        return string.IsNullOrEmpty(input) ? defaultName : input;
    }
}

