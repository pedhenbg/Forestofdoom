// See https://aka.ms/new-console-template for more information

using Gameconsole;

Player player = new Player();

Console.WriteLine("Welcome to Text RPG!");

Console.Write("Enter your character's name: ");
player.Name = Console.ReadLine();
player.Health = 100;
player.AttackDamage = 10;

Console.WriteLine($"\nWelcome, {player.Name}! Your adventure begins now.");
Console.WriteLine($"Your stats: Health {player.Health}, Attack {player.AttackDamage}");
Console.WriteLine("\n-------------------------------------\n");

Enemy enemy = new Enemy("Goblin", 50, 5);
Console.WriteLine($"A wild {enemy.Name} appears!");

while (player.Health > 0 && enemy.Health > 0)
{
    Console.Clear();


    Console.WriteLine($"\nYour Health: {player.Health} | {enemy.Name}'s Health: {enemy.Health}");
    Console.WriteLine("Choose your action: (1 - Attack): ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine("\nPress any key to continue to the next turn...");
        Console.ReadKey();
        enemy.Health -= player.AttackDamage;
        Console.WriteLine($"You attack the {enemy.Name}, dealing {player.AttackDamage} damage");
    
    if (enemy.Health <= 0) break;

    player.Health -= enemy.AttackDamage;
    Console.WriteLine($"The {enemy.Name} attacks you, dealing {enemy.AttackDamage} damage ");
    }
    else
        {
            Console.WriteLine("Invalid action. You lose your turn!");
        }
}
Console.WriteLine("\n-------------------------------------\n");
if (player.Health > 0)
{
    Console.WriteLine($"Congratulations! You have defeated the {enemy.Name}!");
}
else
{
    Console.WriteLine($"You have been defeated by the {enemy.Name}. \nGame Over.");
}


    Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
