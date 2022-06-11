using System;

namespace inheritance
{
    class Vehicle
{
    public int NumPassengers;
    public string Color;

    // protected means child class can still access
    protected double Odometer;
    // Say Vechicle has two overloaded constructors
    // We will either need to pass up two values (int, string), from Car ...
    public Vehicle(int numPas, string col)
    {   
        NumPassengers = numPas;
        Color = col;
        Odometer = 0;
    }
    // Or just one string value.  
    public Vehicle(string col)
    {
        NumPassengers = 5;
        Color = col;
        Odometer = 0;
    }
    //All past code for the Car Vehicle should still be present
    // virtual means the function can be overridden by a child class
    public virtual void GetInfo()
    {
        Console.WriteLine($"Num Passengers: {NumPassengers}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Miles: {Odometer}");
    }
    
}
// Defining a child class of Vehicle
class Car : Vehicle
{
    // We can add members that are unique to Cars, things that won't describe ALL vehicles
    public string Make;
    public string Model;
    // but when we define a constructor for Car, we need to satisfy any constructor requirements
    // for at least ONE constructor on the parent Vehicle class
    public Car(string color, string make, string model) : base(color)
    {
        Make = make;
        Model = model;
    }

    // override does a little polymorphism
    //  public override void GetInfo()
    // {
    //     Console.WriteLine($"Num Passengers: {NumPassengers}");
    //     Console.WriteLine($"Color: {Color}");
    //     Console.WriteLine($"Miles: {Odometer}");
    //     Console.WriteLine($"Make: {Make}");
    //     Console.WriteLine($"Model: {Model}");
    // }

    // use base.GetInfo() to copy function of parent, then add additional stuff
       public override void GetInfo()
    {
        //This line will call the parent's version of this method first 
        base.GetInfo();
        //Then add any additional code to it!
        Console.WriteLine($"Make: {Make}");
        Console.WriteLine($"Model: {Model}");
    }
}


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
