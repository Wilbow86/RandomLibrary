global using RandLib.CategoricalDist;
global using RandLib;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;

class Program()
{
    public static void Main()
    {

        int testSz = 10000000;
        Random rng = new Random();

        int[] counts = new int[4];
        int[] ws = [100, 3000, 600, 300];
        DistTable weights = new DistTable(ws);
        

        for (int i = 0; i < testSz; i++)
        {
            counts[CategoricalDist.rollWeighted(weights)] += 1;
        }

        Console.WriteLine("counts: " + counts[0] + ", "+ counts[1] + ", "+ counts[2] + ", "+ counts[3] );

        Stopwatch sw = Stopwatch.StartNew();

        int count1 = 0;
        int count2 = 0;

        bool res1 = false;
        for (int i = 0; i < testSz; i++)
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

        sw.Stop();
        Console.WriteLine("BAD VERSION:");
        Console.WriteLine("heads: " + count1);
        Console.WriteLine("tails: " + count2);
        Console.WriteLine("ratio: " + ((double)count1 / (double)count2));

        Console.WriteLine($"Elapsed time: {sw.Elapsed.TotalSeconds} s \n \n");

        Stopwatch sw1 = Stopwatch.StartNew();

        bool[] res2;
        int count3 = 0;
        int count4 = 0;
        (res2, rng) = CategoricalDist.flipx(testSz, 0.5, rng);
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
        sw1.Stop();
        Console.WriteLine("GOOD VERSION:");
        Console.WriteLine("heads: " + count3);
        Console.WriteLine("tails: " + count4);
        Console.WriteLine("ratio: " + ((double)count3 / (double)count4));
        Console.WriteLine($"Elapsed time: {sw1.Elapsed.TotalSeconds} s");

    }
}