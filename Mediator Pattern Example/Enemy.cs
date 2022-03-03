
using System;

public class Enemy : Entity
{
    public Enemy(float hp, float strength, int dodgeChance, string name) : base(hp, strength, dodgeChance, name)
    {
    }
    public override void TakeTurn()
    {
        Random random = new Random();
        if (random.Next() % 2 == 0)
            GameManager.AttackEntity(this, "Player");
        else
            Heal();
    }
}