
global using RandLib;

using System;
using static RandLib.CategoricalDist.CategoricalDist;

//tests

string result = flip(0.5) ? "heads" : "tails";


Console.WriteLine("ready");
string a = Console.ReadLine();


Console.WriteLine("starting test" + a);


Random seed = new Random();
bool head = false;
for (int i = 0; i < 2000000000; i++)
{
    (head, seed) = flip(0.5, seed);
}


Console.WriteLine("ready");



a = Console.ReadLine();



Console.WriteLine("starting test2" + a);

flipx(2000000000, 0.5);

Console.WriteLine("flipped and got " + result + ".");