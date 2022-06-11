using System;

namespace loops
{
    class Program
    {
        static void Main()
        {
//The execution section does not always have to use ++
for (int i = 1; i < 256; i = i + 1)
{
    Console.WriteLine(i);
}

for (int i = 1; i<101; i=i+1 )
{
    if (i%3==0 || i%5==0){
        Console.WriteLine(i);
    }
}

for (int i = 1; i<101; i=i+1 )
{
    if (i%15==0){
        
        Console.WriteLine("fizzbuzz");}
    else if(i%3==0){
        Console.WriteLine("fizz");
    }
    else if(i%5==0){
        Console.WriteLine("buzz");
    }
    else{
        Console.WriteLine(i);
    }
    }
    int j = 0;
    while (  j<101 )
{
    if (j%15==0){
        
        Console.WriteLine("fizzbuzz");}
    else if(j%3==0){
        Console.WriteLine("fizz");
    }
    else if(j%5==0){
        Console.WriteLine("buzz");
    }
    else{
        Console.WriteLine(j);
    }
    j = j+1;
    }
}


        }
    }

