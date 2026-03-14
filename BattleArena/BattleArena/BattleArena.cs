using System;

namespace SuperheroBattleArena
{
    public static class BattleArena
    {
        public static string message = "";

        public static void StartBattle(BaseHero heroA, BaseHero heroB)
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine($"║  {heroA.Name,17}  VS  {heroB.Name,-17}║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.WriteLine();


            int round = 1;

            while (heroA.IsAlive() && heroB.IsAlive())
            {
                Console.Clear();
                Console.WriteLine($"── Round {round} ─────────────────────────────────");
                BaseHero.PrintStatus(heroA, heroB);
                Console.WriteLine();

                // Hero A attacks or heals
                Console.WriteLine($"{heroA.Name} Turn");
                Console.WriteLine("[1] ATTACK");
                Console.WriteLine("[2] HEAL");
                Console.Write("Choose : ");

                int tempA = 0;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out tempA) && (tempA == 1 || tempA == 2))
                    {
                        break;
                    }
                    Console.Write("Invalid choice. Please enter [1] or [2] : ");
                }

                if (tempA == 1)
                    heroA.Attack(heroB);
                else if (tempA == 2)
                    heroA.Heal();
                Console.WriteLine(message);
                if (!heroB.IsAlive())
                {
                    AnnounceResult(heroA, heroB);
                    return;
                }
                Console.WriteLine();

                BaseHero.PrintStatus(heroA, heroB);

                // Hero B attacks or heals 
                Console.WriteLine($"{heroB.Name} Turn");
                Console.WriteLine("[1] ATTACK");
                Console.WriteLine("[2] HEAL");
                Console.Write("Choose : ");

                int tempB = 0;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out tempB) && (tempB == 1 || tempB == 2))
                    {
                        break;
                    }
                    Console.Write("Invalid choice. Please enter [1] or [2] : ");
                }

                if (tempB == 1)
                    heroB.Attack(heroA);
                else if (tempB == 2)
                    heroB.Heal();
                Console.WriteLine(message);
                if (!heroA.IsAlive())
                {
                    AnnounceResult(heroB, heroA);
                    return;
                }
                Console.WriteLine();

                round++;

                Console.WriteLine("Press Enter for Next Round");
                Console.ReadKey();
            }
        }


        private static void AnnounceResult(BaseHero winner, BaseHero loser)
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("══════════════════════════════════════════════");
            BaseHero.PrintStatus(winner, loser);
            Console.WriteLine($"   {winner.Name,-15} wins the battle!");
            Console.WriteLine($"   {loser.Name,-15} has been defeated!");
            Console.WriteLine("══════════════════════════════════════════════");
            Console.WriteLine();
        }
    }
}