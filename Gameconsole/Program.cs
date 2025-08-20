using Gameconsole;
using System.Threading;

Random random = new Random();
Player player = new Player();

// Setup inicial do jogo e do jogador
string[] zeusArt = new string[] { @"                      ,--.", @"                      {    }", @"                      K,   }", @"                     /  ~Y`", @"                ,   /   /", @"               {_'-K.__/", @"                 `/-.__L._", @"                 /  ' /`\_}", @"                /  ' /", @"        ____   /  ' /", @" ,-'~~~~    ~~/  ' /_", @",'             ``~~~  ',", @"(                        Y", @"{                         I", @"{      -                    `,", @"|       ',                   )", @"|        |   ,..__      __. Y", @"|    .,_./  Y ' / ^Y   J   )|", @"\           |' /   |   |   ||", @" \          L_/    . _ (_,.'(", @"  \,   ,      ^^""' / |      )", @"    \_  \          /,L]     /", @"      '-_~-,       ` `   ./`", @"         `'{_            )", @"             ^^\..___,.--`     " };
Console.Title = "Forest of Doom - by Pedro Henrique";
Console.ForegroundColor = ConsoleColor.Yellow;
DrawArt(zeusArt);
Console.ResetColor();
Console.WriteLine("\n");
Display("A voice echoes from the heavens...");
Console.Write("\nPress any key to begin your trial...");
Console.ReadKey();

Console.Clear();
Display("First, tell me your name, mortal.");
Console.Write("Enter your character's name: ");
player.Name = Console.ReadLine();
player.Health = 100;
player.MaxHealth = 100;
player.Potions = 3;
player.AttackDamage = 10;
player.Level = 1;
player.XP = 0;
player.XPUntilNextLevel = 100;

Console.Clear();
Display($"Welcome, {player.Name}! Your adventure in the cursed forest begins now.");
Console.Write("\nPress any key to enter the forest...");
Console.ReadKey();

// Loop principal do jogo
while (player.Health > 0)
{
    if (player.Level >= 5)
    {
        Console.Clear();
        Display("A dark presence fills the air... The ground trembles.");
        Display("You've grown strong enough to draw its attention.");
        Enemy boss = Enemy.CreateBoss();
        StartCombat(player, boss, random);
        if (player.Health > 0)
        {
            Console.Clear();
            DrawArt(zeusArt);
            Display("==================================================");
            Display($"With a final blow, you vanquish the {boss.Name}!");
            Display("The corruption fades, and the forest is at peace once more.");
            Display($"\nCongratulations, {player.Name}. You have won the game!");
            Display("==================================================");
        }
        break;
    }

    Console.Clear();
    Display("You wander deeper into the forest...");
    Console.WriteLine($"\nYour current health: {player.Health}/{player.TotalMaxHealth}");
    Console.WriteLine($"XP: {player.XP}/{player.XPUntilNextLevel} (Level: {player.Level})");
    Console.Write("\nPress any key to see what happens next...");
    Console.ReadKey();

    int eventRoll = random.Next(1, 8); // Aumentamos para 7 eventos possíveis

    switch (eventRoll)
    {
        case 1:
        case 2: // Aumentando a chance de batalha
            Console.Clear();
            Display("You are ambushed!");
            Enemy enemy = Enemy.CreateRandomEnemy(random);
            StartCombat(player, enemy, random);
            break;

        case 3:
            Console.Clear();
            int healthFound = random.Next(15, 31);
            Display("You find a hidden spring. The water seems unnaturally clear.");
            Display($"You drink from it and recover {healthFound} health!");
            player.Health += healthFound;
            if (player.Health > player.TotalMaxHealth) player.Health = player.TotalMaxHealth;
            break;

        case 4:
            Console.Clear();
            Display("The path ahead is quiet and uneventful. You take a moment to catch your breath.");
            break;

        case 5:
            Console.Clear();
            Display("You stumble upon an old adventurer's backpack, torn and weathered.");
            Display("Inside, you find a healing potion!");
            player.Potions++;
            break;

        case 6:
            Console.Clear();
            int damageTaken = random.Next(5, 16);
            Display("Misjudging the terrain, you slip and fall down a small ravine!");
            DisplayInColor($"You lose {damageTaken} health.", ConsoleColor.Red);
            player.Health -= damageTaken;
            break;

        case 7:
            Console.Clear();
            Display("Among the roots of an ancient tree, you find a Rusty Sword!");
            DisplayInColor("Your Attack Damage has been permanently increased by 5!", ConsoleColor.Green);
            player.EquippedItem = new Equipment("Rusty Sword", 5, 0);
            break;
    }

    if (player.Health > 0)
    {
        Console.Write("\nPress any key to continue your journey...");
        Console.ReadKey();
    }
}

// Fim de Jogo
if (player.Health <= 0)
{
    Console.Clear();
    Display($"You have been defeated... \n\n==================== GAME OVER ====================");
}
Console.Write("\nPress any key to exit...");
Console.ReadKey();


// ==========================================================
// FUNÇÕES AUXILIARES
// ==========================================================

void StartCombat(Player player, Enemy enemy, Random random)
{
    Display($"A wild {enemy.Name.ToUpper()} appears!");
    Console.Write("\nPress any key to start the battle...");
    Console.ReadKey();

    while (player.Health > 0 && enemy.Health > 0)
    {
        DrawCombatScreen(player, enemy);

        Console.Write("Choose your action: (1 - Attack, 2 - Use Potion): ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        if (choice == "1")
        {
            int playerDamageDealt = CalculateDamage(player.TotalAttackDamage, random);
            enemy.Health -= playerDamageDealt;
            Display($"You attack the {enemy.Name}, dealing {playerDamageDealt} damage.");
        }
        else if (choice == "2")
        {
            if (player.Potions > 0)
            {
                player.Potions--;
                int healthRestored = random.Next(20, 31);
                player.Health += healthRestored;

                if (player.Health > player.TotalMaxHealth) player.Health = player.TotalMaxHealth;
                DisplayInColor($"You drink a potion and restore {healthRestored} health!", ConsoleColor.Green);
            }
            else
            {
                Display("You reach for a potion, but find none!");
            }
        }
        else
        {
            Display("Invalid action! You hesitate and lose your turn.");
        }

        if (enemy.Health > 0)
        {
            int enemyDamageDealt = CalculateDamage(enemy.AttackDamage, random);
            player.Health -= enemyDamageDealt;
            DisplayInColor($"The {enemy.Name} fights back, dealing {enemyDamageDealt} damage.", ConsoleColor.Red);
        }

        Console.Write("\nPress any key to continue...");
        Console.ReadKey();
    }

    Console.Clear();
    if (player.Health > 0)
    {
        Display($"Congratulations! You have defeated the {enemy.Name}!");
        int xpGained = enemy.XPReward;
        player.XP += xpGained;
        DisplayInColor($"You gained {xpGained} XP!", ConsoleColor.Cyan);
        CheckForLevelUp(player);
    }
}

void CheckForLevelUp(Player player)
{
    if (player.XP >= player.XPUntilNextLevel)
    {
        player.Level++;
        player.XP = 0;
        player.MaxHealth += 20;
        player.AttackDamage += 5;
        player.XPUntilNextLevel = (int)(player.XPUntilNextLevel * 1.5);
        player.Health = player.TotalMaxHealth;

        Display("================================");
        DisplayInColor($"LEVEL UP! You are now Level {player.Level}!", ConsoleColor.Magenta);
        DisplayInColor($"Max Health increased to {player.TotalMaxHealth}.", ConsoleColor.Green);
        DisplayInColor($"Base Attack increased to {player.AttackDamage}.", ConsoleColor.Yellow);
        Display($"You need {player.XPUntilNextLevel} XP for the next level.");
        Display("================================");
    }
}

int CalculateDamage(int baseDamage, Random rand)
{
    int roll = rand.Next(1, 21);
    Console.WriteLine($"\n-> Dice roll (d20): {roll}");

    if (roll == 1)
    {
        DisplayInColor("-> Critical Fail! The attack misses completely.", ConsoleColor.DarkGray);
        return 0;
    }
    if (roll > 1 && roll <= 10)
    {
        Display("-> A glancing blow...");
        return (int)(baseDamage * 0.5);
    }
    if (roll > 10 && roll < 20)
    {
        Display("-> A solid hit!");
        return baseDamage;
    }
    else // (roll == 20)
    {
        DisplayInColor("-> CRITICAL HIT! Double damage!", ConsoleColor.Yellow);
        return baseDamage * 2;
    }
}

void DrawCombatScreen(Player player, Enemy enemy)
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine($" PLAYER: {player.Name.ToUpper()} | LVL: {player.Level} | HEALTH: {player.Health}/{player.TotalMaxHealth} | POTIONS: {player.Potions}");
    Console.WriteLine($" EQUIPPED: {player.EquippedItem?.Name ?? "Nothing"}");
    Console.WriteLine("--------------------------------");
    Console.WriteLine($" ENEMY: {enemy.Name.ToUpper()} | HEALTH: {enemy.Health}");
    Console.WriteLine("================================");
    Console.WriteLine();
}

void Display(string message, int delay = 25)
{
    foreach (char letter in message)
    {
        Console.Write(letter);
        Thread.Sleep(delay);
    }
    Console.WriteLine();
}

void DisplayInColor(string message, ConsoleColor color, int delay = 25)
{
    Console.ForegroundColor = color;
    Display(message, delay);
    Console.ResetColor();
}

void DrawArt(string[] art)
{
    Console.Clear();
    foreach (string line in art)
    {
        Console.WriteLine(line);
    }
}