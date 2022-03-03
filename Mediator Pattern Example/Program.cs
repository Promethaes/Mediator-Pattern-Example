using System;

namespace Mediator_Pattern_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skeleton and Goblin appear!");
            GameManager.AddEntity(new Enemy(5.0f,2.0f,2,"Skeleton"));
            GameManager.AddEntity(new Enemy(5.0f,3.0f,3,"Goblin"));
            GameManager.AddEntity(new Player(10.0f,5.0f,2));

            while (!GameManager.PlayerIsDead() && !GameManager.EnemiesAreDead())
                GameManager.Update();

            Console.WriteLine("Game over!");
            Console.ReadLine();
        }
    }
}
