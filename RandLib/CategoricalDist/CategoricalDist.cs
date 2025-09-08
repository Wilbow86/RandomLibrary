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
        public static (bool, Random) flip(double pHeads, Random seed)
        {
            
            double num = seed.NextDouble();
            return (pHeads >= num, seed);
        }

        public static int rollFair(int sides)
        {
            Random rng = new Random();
            return (int)Math.Floor(rng.NextDouble() * sides);
        }
        public static (int, int) rollFair(int sides, int seed)
        {
            Random rng = new Random(seed);
            return ( (int)Math.Floor(rng.NextDouble() * sides), rng.Next() );
        }

        //performs x flips and returns an array of the outcomes, heads = true.  pHeads precision is downgraded to 7 bits, so do not use for precise or small chances
        public static bool[] flipx(int numFlips, double pHeads)
        {
            Random rng = new Random();
            long bigRando = rng.NextInt64();
            long smallRando = bigRando & 0x7F; //7-high to mask only last 7 bits range 0-127
            bigRando >>= 7; 

            bool[] outcomes = new bool[numFlips];
            int scaledProb = (int)(pHeads * 128.0); //scale given probability to equivalent in [0: 127]
            int segmentsUsed = 0;
            int flipsDone = 0;
            while (flipsDone < numFlips)
            {
                if (segmentsUsed > 8)
                {
                    segmentsUsed = 0;
                    bigRando = rng.NextInt64();
                    
                }
                smallRando = bigRando & 0x7F;
                bigRando >>= 7;
                segmentsUsed++;

                outcomes[flipsDone] = pHeads > smallRando;

                flipsDone++;
            }
            return outcomes;
        }

    }

}
