using System;
using System.Collections.Generic;
namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] onenine = {1,2,3,4,5,6,7,8,9};
            string[] name = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] tfalse = {true,false,true,false,true,false,true,false,true,false};
            foreach (bool num in tfalse){

            Console.WriteLine(num);
            }
        List<string> icecream = new List<string>();
        icecream.Add("Chocolate");
        icecream.Add("Vanilla");
        icecream.Add("Strawberry");
        icecream.Add("Mint");
        icecream.Add("Rocky Road");
        Console.WriteLine(icecream.Count);
        Console.WriteLine(icecream[2]);
        icecream.RemoveAt(2);
        Console.WriteLine(icecream[2]);
        Console.WriteLine(icecream.Count);

        Dictionary<string,string> namesicecream = new Dictionary<string, string>();
        namesicecream.Add("Tim", "Chocolate");
        namesicecream.Add("Martin", "Vanilla");
        namesicecream.Add("Nikki", "Mint");
        namesicecream.Add("Sara", "Rocky Road");
        
        foreach (var entry in namesicecream){
            Console.WriteLine(entry.Key + " - " + entry.Value);
        }
        }
    }
}
