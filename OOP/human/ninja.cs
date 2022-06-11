using System;
namespace human
{
    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }
        public override int Attack(Human target)
        {
            Random rand = new Random();
            int damage = 5*Dexterity;
            reduceHealth(target, damage);
            if (rand.Next(0,5) == 0)
            {
                reduceHealth(target, 10);

            }
            
            return target.healthget;
        }
        public void Steal(Human target)
        {
            reduceHealth(target,5);
            Heal(this,5);
        }
    }
}