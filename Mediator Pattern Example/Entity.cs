using System;

public class Entity
{
    protected float _hp = 10.0f;
    protected float _strength = 1.0f;
    protected int _dodgeChance = 2;
    protected string _name = "";
    protected bool _dead = false;

    public Entity(float hp, float strength, int dodgeChance, string name)
    {
        _hp = hp;
        _strength = strength;
        _dodgeChance = dodgeChance;
        _name = name;
    }

    public virtual bool TakeDamage(float damage)
    {
        //calculate dodge chance
        Random random = new Random();
        if (random.Next() % _dodgeChance != 0)
        {
            Console.WriteLine(_name + " dodged!");
            return false;
        }

        //take damage then check if entity died
        _hp -= damage;
        _dead = _hp <= 0.0f;
        if (_dead)
            Console.WriteLine(_name + " was defeated!!!!!\n");
        return true;
    }
    //attack using GameManager mediator
    public void Attack(string target)
    {
        Console.WriteLine(_name + " attacked!");
        GameManager.AttackEntity(this, target);
    }

    //heal entity
    public void Heal()
    {
        _hp += _strength / 2.0f;
        Console.WriteLine(_name + " healed " + _strength / 2.0f + " hp! hp: " + _hp);
    }

    //virtual function, main point of action for child classes
    public virtual void TakeTurn()
    {
        Console.WriteLine(_name + " did nothing...");
    }

    public override string ToString()
    {
        return _name + "\n\t- HP: " + _hp + "\n\t- STR: " + _strength + "\n\t- DODGE: " + _dodgeChance;
    }

    // //Getters and Setters
    public bool IsDead()
    {
        return _dead;
    }

    public float GetStrength()
    {
        return _strength;
    }
    public string GetName()
    {
        return _name;
    }

    public float GetHP()
    {
        return _hp;
    }

}