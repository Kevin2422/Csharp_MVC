using System;

namespace objectconstruction
{
        //Make sure to include the Vehicle class separate from the Program class
public class Vehicle
{
    // provides a backing field that you don't see, property that gets auto initialized
    string Name {get;set;}
    //Accessibility of class members is defaulted to private
    //so we must add the public keyword to anything we
    //want to allow outside access to.
 
    // this unassigned integer will default to 0
    public int NumPassengers;
    public string Color;
    public double Maxspeed;
    void MakeNoise(string noise)
    {
        Console.WriteLine(noise);
    }
    // these functions have the same name, called function overloading (difference is one has a parameter the other doesnt)
    void MakeNoise()
    {
        Console.WriteLine("BEEP");
    }
    // property
    string ColorProp
    {
        get
        {
            // referencing property gives the get function which returns something
            return Color;
        }
        set
        {
            // vehicleobject.ColorProp = "Blue" will access the set keyword, will set the value of color to blue
            Color = value;
        }
    }
    public Vehicle(int val)
     {
          NumPassengers = val;
     }
}
    class Program
    {


    public static void Main(string[] args)
    {
        // Notice the type for the new object reference
        // is the same as the class name
        Vehicle myVehicle = new Vehicle(7);
        Console.WriteLine($"My vehicle is holding {myVehicle.NumPassengers} people");
    }
    }
}
