using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
            static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TossCoin();
            RandomArray();
            Names();
        }
        static int[] RandomArray()
        {
            int[] RandArr = new int[10];
            for(int i = 0; i < RandArr.Length; i++)
            {
                Random rand = new Random();
                RandArr[i] = rand.Next(5,25);
            }
            foreach (int num in RandArr)
            {
                Console.WriteLine(num);
            }
            return RandArr;
        }

        static string TossCoin()
        {
            Console.WriteLine("Tossing a coin");
            Random rand = new Random();
            string result = "";
            int flip = rand.Next(1,3);
            if (flip == 1)
            {
                result = "Heads";
                Console.WriteLine(result);
                
            }
            else
            {
                result = "Tails";
                Console.WriteLine(result);
                
            }
            return result;
            
        }
        
        static List<string> Names()
        {
            Random rand = new Random();
            List<string> names = new List<string>();
            names.Add("Todd");
            names.Add("Tiffany");
            names.Add("Charlie");
            names.Add("Geneva");
            names.Add("Sydney");

            int n = names.Count;
            while (n>1)
            {
                n--;
                int k = rand.Next(n+1);
                string value = names[k];
                names[k] = names[n];
                names[n] = value;

            }
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            List<string> longnames = new List<string>();
            foreach (string name in names)
            {
                if (name.Length>5)
                {
                    longnames.Add(name);
                }
                
            }
            foreach (string name in longnames)
            {
                Console.WriteLine("l"+ name);
            }
            return longnames;
        }

    }
}
