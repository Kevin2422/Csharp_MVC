using System;
namespace human
{

class Wizard : Human
{
    public Wizard(string name) : base(name)
    {
        health = 50;
        Intelligence = 25;



    }
    public override int Attack(Human target)
    {
        target.Intelligence = target.Intelligence - Intelligence*5;
        health = health + Strength*3;
        return base.Attack(target);
    }
    public void Heal(Human target)
    {
        int val = 10* Intelligence;
        base.Heal(target, val);
    }
}
}
