using System;
namespace human
{
    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
        }
        public override int Attack(Human target)
        {
            base.Attack(target);
            if (target.healthget <50)
            {
                instaKill(target);
            }
            return target.healthget;

        }
        public void Meditate()
        {
            if (health > 200)
            {
                Console.WriteLine("Samurai did nothing");
            }
            if (health < 200)
            {
                health = 200;
                Console.WriteLine("Samurai meditated");
            }
        }
    }
}