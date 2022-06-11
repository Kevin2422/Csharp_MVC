using System;
using System.Collections.Generic;

namespace objects
{
    class Program
    {
        static void Main(string[] args)
        {
           List<object> empty = new List<object>();
            empty.Add(7);
            empty.Add(28);
            empty.Add(-1);
            empty.Add(true);
            empty.Add("chair"); 
            int sum = 0;
            foreach (object obj in empty)
            {
                
                if (obj is int)
                {
                    int adnum = (int) obj;
                    sum = sum + adnum;
                }
                    Console.WriteLine(sum);
            }
        }
    }
}
