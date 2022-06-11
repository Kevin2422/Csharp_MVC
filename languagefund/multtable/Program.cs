using System;

namespace multtable
{
    class Program
    {
        static void Main(string[] args)
        {
           int[,] multTable = new int[10,10]; 
for (int j = 0; j< 10; j++){

    string row = "[";
for (int i = 0; i < 10; i++){
    multTable[j,i] = (j+1)*(i + 1);
    if (multTable[j,i]<10){

    row = row + " " + multTable[j,i] + ", ";
    }
    else
    {
        row = row + " " + multTable[j,i] +",";
    }
    

}
row = row + "]";
    Console.WriteLine(row);
    }



    
}
    }
}

