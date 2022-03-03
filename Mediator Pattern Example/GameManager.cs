
using System;
using System.Collections.Generic;
using System.Threading;

public class GameManager
{

    static Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

    //Add an entity to the internal dictionary
    public static void AddEntity(Entity entity)
    {
        entities.Add(entity.GetName(), entity);
    }
    //Update Game State
    public static void Update()
    {
        foreach (var entity in entities)
        {
            if (entity.Value.IsDead())
                continue;
            entity.Value.TakeTurn();
            Thread.Sleep(2000);
        }
        Console.WriteLine("Next Round!\n");
    }

    //Mediator pattern meat and potatoes
    //returns true if action was successful
    public static bool AttackEntity(Entity attacker, string target)
    {
        var targetEntity = entities[target];
        if (targetEntity == null)
            return false;

        //try swinging at target
        Console.WriteLine(attacker.GetName() + " swung at " + target + "!");
        if (!targetEntity.TakeDamage(attacker.GetStrength()))
            return true;

        //display attack information
        Console.WriteLine(
            attacker.GetName() + " did " + attacker.GetStrength() + " damage to " +
            targetEntity.GetName() + "! " +
            targetEntity.GetName() + "'s hp: " + targetEntity.GetHP());
        return true;
    }
    //Displays all entity's stats
    public static void DisplayAllStats()
    {
        foreach (var entity in entities)
            if (!entity.Value.IsDead())
                Console.WriteLine(entity.Value.ToString());
    }


    //death checking functions
    public static bool PlayerIsDead()
    {
        return entities["Player"].IsDead();
    }

    public static bool EnemiesAreDead()
    {
        foreach (var entity in entities)
        {
            if (entity.Key == "Player")
                continue;
            if (!entity.Value.IsDead())
                return false;
        }
        return true;
    }

}