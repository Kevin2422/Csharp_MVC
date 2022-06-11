using System;

namespace human
{
    class Human
{
    // Fields for Human
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    protected int health;
     
    // add a public "getter" property to access health
    public int healthget
    {
        get
        {
            return health;
        }
    }

    
    // Add a constructor that takes a value to set Name, and set the remaining fields to default values
    public Human(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        health = 100;
    }
     
    // Add a constructor to assign custom values to all fields
    public Human(string name, int str, int INT, int DEX, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = INT;
        Dexterity = DEX;
        health = hp;
    }
     
    // Build Attack method
    public virtual int Attack(Human target)
    {
        int damage = Strength * 3;
        target.health = target.health - damage;
        Console.WriteLine($"{target.Name} took {damage} points of damage! Health is now {target.health}!" );
        return target.health;
        
    }

    protected virtual void reduceHealth(Human target, int val)
    {
        target.health -= val;
        Console.WriteLine($"{target.Name} was hit for {val} hp! Health is now {target.health}");
    }
    protected virtual void Heal(Human target, int val)
    {
        target.health += val;
        Console.WriteLine($"{target.Name} was healed by {val} hp! Health is now {target.health}");
    }
    protected virtual void instaKill(Human target)
    {
        target.health = 0;
        Console.WriteLine($"{target.Name} was slain!");
    }

}


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Human human1 = new Human("Kevin",10,4,4,400);
            Human human2 = new Human("Bob");
            Wizard joe = new Wizard("Joe");
            Ninja larry = new Ninja("Larry");
            Samurai jack = new Samurai("Jack");
            jack.Attack(joe);
            larry.Attack(joe);
            larry.Steal(joe);
            joe.Attack(human1);
            joe.Heal(human1);
            human1.Attack(joe);
            
            
            
            human1.Attack(human2);
            human2.Attack(human1);
            Console.WriteLine(human1.healthget);
        }
    }
}
