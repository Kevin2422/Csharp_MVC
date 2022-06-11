using System;

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring an array of length 5, initialized by default to all zeroes
int[] numArray = new int[5];
// Declaring an array with pre-populated values
// For Arrays initialized this way, the length is determined by the size of the given data
int[] numArray2 = {1,2,3,4,6};

string[] myCars = new string[] { "Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"}; 
foreach (string car in myCars)
{
    // We no longer need the index, because variable 'car' already represents each indexed value
    Console.WriteLine($"I own a {car}");
}



        }
    }
}
