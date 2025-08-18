using Gameconsole;
Random random = new Random();

Player player = new Player();

Console.WriteLine("Welcome to Text RPG!");

Console.Write("Enter your character's name: ");
player.Name = Console.ReadLine();
player.Health = 100;
player.AttackDamage = 10;

Console.Clear();
Console.WriteLine($"Welcome, {player.Name}! Your adventure begins now.");
Console.WriteLine($"Your stats: Health {player.Health}, Attack {player.AttackDamage}");
Console.Write("\nPress any key to enter the forest...");
Console.ReadKey();

while (player.Health > 0)
{
    Console.Clear();
    Console.WriteLine("As you wander through the forest...");
    Console.WriteLine($"Your current health: {player.Health}");
    Console.Write("\nPress any key to see what happens next...");
    Console.ReadKey();

    int eventRoll = random.Next(1, 4);

    switch (eventRoll)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("You are ambushed!");
            Enemy enemy = Enemy.CreateRandomEnemy(random);
            StartCombat(player, enemy, random);
            break;

        case 2:
            Console.Clear();
            int healthFound = random.Next(10, 26);
            Console.WriteLine("You find a hidden spring and drink from its waters.");
            Console.WriteLine($"You recovered {healthFound} health!");
            player.Health += healthFound;
            break;

        case 3:
            Console.Clear();
            Console.WriteLine("The path ahead is quiet and uneventful.");
            break;
    }

    if (player.Health > 0)
    {
        Console.Write("\nPress any key to continue your journey...");
        Console.ReadKey();
    }
}

Console.Clear();
Console.WriteLine($"You have been defeated... \n\n==================== GAME OVER ====================");
Console.Write("\nPress any key to exit...");
Console.ReadKey();


void StartCombat(Player player, Enemy enemy, Random random)
{
    Console.WriteLine($"A wild {enemy.Name.ToUpper()} appears!");
    Console.Write("\nPress any key to start the battle...");
    Console.ReadKey();

    while (player.Health > 0 && enemy.Health > 0)
    {
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine($" PLAYER: {player.Name.ToUpper()} | HEALTH: {player.Health}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine($" ENEMY: {enemy.Name.ToUpper()} | HEALTH: {enemy.Health}");
        Console.WriteLine("================================");
        Console.WriteLine();

        Console.Write("Choose your action: (1 - Attack): ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        if (choice == "1")
        {
            int playerDamageDealt = CalculateDamage(player.AttackDamage, random);
            enemy.Health -= playerDamageDealt;
            Console.WriteLine($"You attack the {enemy.Name}, dealing {playerDamageDealt} damage.");
        }
        else
        {
            Console.WriteLine("Invalid action! You hesitate and lose your turn.");
        }

        if (enemy.Health > 0)
        {
            int enemyDamageDealt = CalculateDamage(enemy.AttackDamage, random);
            player.Health -= enemyDamageDealt;
            Console.WriteLine($"The {enemy.Name} fights back, dealing {enemyDamageDealt} damage.");
        }

        Console.Write("\nPress any key to continue...");
        Console.ReadKey();
    }

    Console.Clear();
    if (player.Health > 0)
    {
        Console.WriteLine($"Congratulations! You have defeated the {enemy.Name}!");
    }
}

int CalculateDamage(int baseDamage, Random rand)
{
    int roll = rand.Next(1, 21);
    Console.WriteLine($"\n-> Dice roll (d20): {roll}");

    if (roll == 1)
    {
        Console.WriteLine("-> Critical Fail! The attack misses completely.");
        return 0;
    }
    if (roll > 1 && roll <= 10)
    {
        Console.WriteLine("-> A glancing blow...");
        return (int)(baseDamage * 0.5);
    }
    if (roll > 10 && roll < 20)
    {
        Console.WriteLine("-> A solid hit!");
        return baseDamage;
    }
    else
    {
        Console.WriteLine("-> CRITICAL HIT! Double damage!");
        return baseDamage * 2;
    }
}