using System;
namespace dojodachi.Models
{
    public class Dojodachi
    {
        public int? happiness;
        public int? fullness;
        public int? energy;
        public int? meals;

        public Dojodachi()
        {
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }
        public Dojodachi(int? h, int? f, int? e, int? m)
        {
            happiness = h;
            fullness = f;
            energy = e;
            meals = m;
        }

        public string [] Feed()
        {
            Random rand = new Random();
            if (meals <=0)
            {
                string [] messages = {"No meals!", "confused.jpg" };
                return messages;
            }
            else if (rand.Next(0,4) == 0)
            {
                meals -=1;
                string [] messages = {$"Your dachi didn't like the meal :( !  ", "sad.jpg" };
                return messages;
            }
            else 
            {
                meals -=1;
                int increase = rand.Next(5,11);
                fullness += increase;
            return new string [] {$"You fed your dachi, fullness increased by {increase}", "yum.jpg"} ;
            }
            
        }
        public string [] Play()
        {
            Random rand = new Random();
            if (energy<5)
            {
                return new string[] {"Not enough energy", "tired.jpg"};
            }
            else if(rand.Next(0,4) == 0)
            {
                energy -= 5;
                return new string[]{"Dachi wasn't in the mood. :(", "sad.jpg"};
            }
            else
            {

            energy -= 5;
            int increase = rand.Next(5,11);
            happiness += increase;
            return new string [] {$"You played with your dachi, happiness increased by {increase}!", "happy.jpg"};
            }

        }
        public string [] Work()
        {
            if (energy<5)
            {
                return new string [] {"Not enough energy!", "tired.jpg"};
            }
            energy -= 5;
            Random rand = new Random();
            int increase = rand.Next(1,4);
            meals += increase;
            return new string [] {$"Your work gave you {increase} meals!", "happy.jpg"};
        }

        public string [] Sleep()
        {
            energy += 15;
            fullness -= 5;
            happiness -= 5;
            return new string [] {"You went to sleep, energy + 15, fullness - 5, happiness - 5", "sleep.jpg"};
        }

        public bool DidWin()
        {
            if(energy>=100 && fullness>=100 && happiness>=100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DidLose()
        {
            if (happiness<=0 || fullness<=0)
            {
                return true;
            }
            return false;
        }

    }
}