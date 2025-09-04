using System;
using static RandLib.CategoricalDist.CategoricalDist;

//tests

string result = flip(0.5) ? "heads" : "tails"; 

Console.WriteLine("flipped and got " + result + ".");