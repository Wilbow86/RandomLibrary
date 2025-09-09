global using RandLib.CategoricalDist;
global using RandLib;
using System;
using System.Net.Http.Headers;

class Program()
{
    public static void Main()
    {
        Console.WriteLine("working"); /*
        Console.ReadLine();
        Random rng = new Random();

        int count1 = 0;
        int count2 = 0;

        bool res1 = false;
        for (int i = 0; i < 2000000000; i++)
        {
            (res1, rng) = CategoricalDist.flip(0.5, rng);
            if (res1)
            {

                count1++;
            }
            else
            {
                count2++;
            }

        }
        Console.WriteLine("heads: " + count1);
        Console.WriteLine("tails: " + count2);
        Console.WriteLine("ratio: " + ((double)count1 / (double)count2));
            */
        Console.ReadLine();

        bool[] res2;

        int count3 = 0;
        int count4 = 0;

        res2 = CategoricalDist.flipx(2000000000, 0.24);
        foreach (bool b in res2)
        {
            if (b)
            {
                count3++;
            }
            else
            {
                count4++;
            }
        }
        Console.WriteLine("heads: " + count3);
        Console.WriteLine("tails: " + count4);
        Console.WriteLine("ratio: " + ((double)count3 / (double)count4 ));
        
    }
}