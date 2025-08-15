// See https://aka.ms/new-console-template for more information

using Gameconsole;
Random random = new Random();

Player player = new Player();

Console.WriteLine("Welcome to Text RPG!");

Console.Write("Enter your character's name: ");
player.Name = Console.ReadLine();
player.Health = 100;
player.AttackDamage = 10;

Console.WriteLine($"\nWelcome, {player.Name}! Your adventure begins now.");
Console.WriteLine($"Your stats: Health {player.Health}, Attack {player.AttackDamage}");
Console.WriteLine("\n-------------------------------------\n");
Console.ReadKey();
Console.WriteLine("As you wander through the forest.............");
Console.ReadKey();


Enemy enemy = new Enemy("Goblin", 50, 5);
Console.WriteLine($"A wild {enemy.Name} appears!");
Console.ReadKey();

// O loop de batalha começa aqui
while (player.Health > 0 && enemy.Health > 0)
{
    // ====================================================================
    // PARTE 1: RENDERIZAÇÃO (Resolve o Problema 1)
    // A tela inteira é redesenhada a cada turno com todas as informações.
    // ====================================================================
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine($" PLAYER: {player.Name.ToUpper()} | HEALTH: {player.Health}");
    Console.WriteLine("--------------------------------");
    Console.WriteLine($" ENEMY: {enemy.Name.ToUpper()} | HEALTH: {enemy.Health}");
    Console.WriteLine("================================");
    Console.WriteLine(); // Adiciona um espaço para respirar

    // ====================================================================
    // PARTE 2: INPUT DO JOGADOR
    // ====================================================================
    Console.Write("Choose your action: (1 - Attack): ");
    string choice = Console.ReadLine();
    Console.WriteLine(); // Adiciona outro espaço

    // ====================================================================
    // PARTE 3: AÇÃO DO JOGADOR
    // ====================================================================
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

    // ====================================================================
    // PARTE 4: AÇÃO DO INIMIGO (Resolve o Problema 2)
    // O inimigo ataca DEPOIS do turno do jogador, se ainda estiver vivo.
    // ====================================================================
    if (enemy.Health > 0)
        // PARTE 4: AÇÃO DO INIMIGO
        if (enemy.Health > 0)
        {
            int enemyDamageDealt = CalculateDamage(enemy.AttackDamage, random);
            player.Health -= enemyDamageDealt;
            Console.WriteLine($"The {enemy.Name} fights back, dealing {enemyDamageDealt} damage.");
        }

    // ====================================================================
    // PARTE 5: PAUSA PARA LEITURA
    // A pausa acontece no final, garantindo que TODAS as mensagens
    // do turno (inclusive "Invalid action") sejam lidas.
    // ====================================================================
    Console.Write("\nPress any key to continue...");
    Console.ReadKey();
}
Console.WriteLine("\n-------------------------------------\n");
if (player.Health > 0)
{
    Console.WriteLine($"Congratulations! You have defeated the {enemy.Name}!");
}
else
{
    Console.WriteLine($"You have been defeated by the {enemy.Name}. \n====================Game Over.====================");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();

int CalculateDamage(int basedamage, Random rand)
    {
    int roll = rand.Next(1, 21);
    Console.WriteLine($"\n-> Dice roll (d20): {roll}");

    if (roll == 1)
    {
        Console.WriteLine("-> Critical Fail! The attack misses completely.");
        return 0; // 0 de dano
    }
    if (roll > 1 && roll <= 10)
    {
        Console.WriteLine("-> A glancing blow...");
        return (int)(baseDamage * 0.5); // 50% do dano
    }
    if (roll > 10 && roll < 20)
    {
        Console.WriteLine("-> A solid hit!");
        return baseDamage; // 100% do dano
    }
    // Se não for nenhum dos acima, só pode ser 20
    else // (roll == 20)
    {
        Console.WriteLine("-> CRITICAL HIT! Double damage!");
        return baseDamage * 2; // Dano em dobro
    }
}
