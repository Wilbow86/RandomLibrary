namespace RandLib.CategoricalDist
{
	public class CategoricalDist
	{
		//gets a random number between 0 and 1 then subtracts it from pHeads. True if nonnegative
		public static bool flip(double pHeads)
		{
			Random rng = new Random();
			double num = rng.NextDouble();
			return (pHeads - num) >= 0;
		}
		//seeded version of above, returns modified seed
		public static (bool, int) flip(double pHeads, int seed)
		{
			Random rng = new Random(seed);
			double num = rng.NextDouble();
			return ( pHeads >= num, rng.Next());
		}
	}
}
