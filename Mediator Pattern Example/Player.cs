
using System;

public class Player : Entity
{
    bool _godmode = false;
    public Player(float hp, float damage, int dodgeChance) : base(hp, damage, dodgeChance, "Player")
    {
    }

    public override bool TakeDamage(float damage)
    {
        if (_godmode)
            return false;
        return base.TakeDamage(damage);
    }

    //input interpreter
    public override void TakeTurn()
    {
        Console.WriteLine("Your turn! You can: \n-look \n-heal \n-attack <target name>");
        bool successfulInput = false;

        //anonymous function
        void InvalidCommand()
        {
            Console.WriteLine("Invalid Command!");
            successfulInput = false;
        }

        while (!successfulInput)
        {
            successfulInput = true;
            var input = Console.ReadLine();

            if (input == "look")
            {
                GameManager.DisplayAllStats();
                successfulInput = false;
                continue;
            }
            else if (input == "heal")
                Heal();
            else if (input.Contains("attack"))
            {
                var strings = input.Split(' ');
                if (!GameManager.AttackEntity(this, strings[1]))
                    InvalidCommand();
            }
            else
                InvalidCommand();
        }

    }
}