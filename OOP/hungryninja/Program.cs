using System;
using System.Collections.Generic;
namespace hungryninja
{
    class Food
{
    public string Name;
    public int Calories;
    // Foods can be Spicy and/or Sweet
    public bool IsSpicy; 
    public bool IsSweet;


    // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
    public Food(string name, int cals, bool spice, bool sweet)
    {
        Name = name;
        Calories = cals;
        IsSpicy = spice;
        IsSweet = sweet;
    }
}
class Buffet
{
    public List<Food> Menu;
    
    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Pasta", 1000, false, false),
            new Food("Pizza", 1000, false, false),
            new Food("Cake", 400, false, true),
            new Food("Hamburger", 800, false, false),
            new Food("Chili", 300, true, false),
            new Food("Cookie", 150, false, true),
            new Food("Chips", 300, false, false),
        };
    }
     
    public Food Serve()
    {
        Random rand = new Random();
        Food fooditem = Menu[rand.Next(0,7)];
        Console.WriteLine(fooditem);
    return fooditem;
    }
}
class Ninja
{
    public string Name;
    private int calorieIntake;
    public List<Food> FoodHistory;
     
    // add a constructor
     public Ninja(string name)
    {
        Name = name;
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }
    // add a public "getter" property called "IsFull"
    public bool IsFull
    {
        get
        {
            return calorieIntake >3000;
        }
    }
     
    // build out the Eat method
    public void Eat(Food item)
    {
        if (!IsFull)
        {

        calorieIntake = calorieIntake + item.Calories;
        Console.WriteLine($"{this.Name} eats {item.Name}. Consumed {this.calorieIntake} calories in total." );
        }
        else
        {
            Console.WriteLine("Ninja too full to eat!");
        }
    }
}





    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Buffet eatery = new Buffet();
            
            Ninja bob = new Ninja("bob");
            while(!bob.IsFull)
            {
                bob.Eat(eatery.Serve());
            }
            bob.Eat(eatery.Serve());
            

        }
    }
}
