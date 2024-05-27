using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;

namespace ConsoleArenaGame
{
    class Program
    {
        static void ConsoleNotification(GameEngine.NotificationArgs args)
        {
            Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack,2)} and caused {Math.Round(args.Damage,2)} damage.");
            Console.WriteLine($"Attacker: {args.Attacker}");
            Console.WriteLine($"Defender: {args.Defender}");
        }
        static void Main(string[] args)
        {
            // Add all heroes to a list
            List<Hero> heroes = new List<Hero>
    {
        new Knight("Knight", 10, 20, new Sword("Sword")),
        new Assassin("Assassin", 10, 5, new Dagger("Dagger")),
        new Mage("Mage", 8, 15, new Staff("Staff")),
        new Barbarian("Barbarian", 12, 18, new Axe("Axe"))
    };

            // Randomly choose two heroes for the fight
            Random random = new Random();
            Hero heroA = heroes[random.Next(heroes.Count)];
            Hero heroB;
            do
            {
                heroB = heroes[random.Next(heroes.Count)];
            } while (heroB == heroA);

            GameEngine gameEngine = new GameEngine()
            {
                HeroA = heroA,
                HeroB = heroB,
                NotificationsCallBack = ConsoleNotification
            };

            gameEngine.Fight();

            Console.WriteLine();
            Console.WriteLine($"And the winner is {gameEngine.Winner}");
        }

    }
}