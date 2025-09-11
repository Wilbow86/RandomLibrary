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

        //rolls a fair die with sides amount of sides and returns a 0-indexed result
        public static int rollFair(int sides)
        {
            Random rng = new Random();
            return (int)Math.Floor(rng.NextDouble() * sides);
        }
        public static (int, Random) rollFair(int sides, Random seed)
        {
            return ((int)Math.Floor(seed.NextDouble() * sides), seed);
        }

        //produces
        public static int rollWeighted(DistTable outcomes)
        {
            Random rng = new Random();
            double observation = rng.NextDouble() * outcomes.TotalWeight;

            int bot = 0;
            int top = outcomes.Weights.Length - 1;

            int ind = outcomes.Weights.Length / 2;
            bool found = false;
            while (ind != 0 && !found)
            {
                if (observation >= outcomes.Weights[ind])
                {
                    bot = ind;
                    ind = bot + (int)Math.Ceiling((top - bot) / 2.0);
                }
                else if (observation >= outcomes.Weights[ind - 1])
                {
                    found = true;
                }
                else
                {
                    top = ind;
                    ind = bot + (int)Math.Floor((top - bot) / 2.0);
                }
            }
            return ind;
        }
        public static (int, Random) rollWeighted(DistTable outcomes, Random seed)
        {
            double observation = seed.NextDouble() * outcomes.TotalWeight;

            int bot = 0;
            int top = outcomes.Weights.Length - 1;

            int ind = outcomes.Weights.Length / 2;
            bool found = false;
            while (ind != 0 && !found)
            {
                if (observation >= outcomes.Weights[ind])
                {
                    bot = ind;
                    ind = bot + (int)Math.Ceiling((top - bot) / 2.0);
                }
                else if (observation >= outcomes.Weights[ind - 1])
                {
                    found = true;
                }
                else
                {
                    top = ind;
                    ind = bot + (int)Math.Floor((top - bot) / 2.0);
                }
            }
            return (ind, seed);
        }

        


        //performs x flips and returns an array of the outcomes, heads = true.  pHeads precision is downgraded to 7 bits, so do not use for precise or small chances
        public static bool[] flipx(int numFlips, double pHeads)
        {
            Random rng = new Random();
            long bigRando = rng.NextInt64();
            long smallRando = 0; //7-high to mask only last 7 bits range 0-127

            bool[] outcomes = new bool[numFlips];
            int scaledProb = (int)(pHeads * 127.0); //scale given probability to equivalent in [0: 127]
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

                outcomes[flipsDone] = scaledProb >= smallRando;

                flipsDone++;
            }
            return outcomes;
        }

        public static (bool[], Random) flipx(int numFlips, double pHeads, Random seed)
        {

            long bigRando = seed.NextInt64();
            long smallRando = 0;

            bool[] outcomes = new bool[numFlips];
            int scaledProb = (int)(pHeads * 127.0); //scale given probability to equivalent in [0: 127]
            int segmentsUsed = 0;
            int flipsDone = 0;
            while (flipsDone < numFlips)
            {
                if (segmentsUsed > 8)
                {
                    segmentsUsed = 0;
                    bigRando = seed.NextInt64();

                }
                smallRando = bigRando & 0x7F;
                bigRando >>= 7;
                segmentsUsed++;

                outcomes[flipsDone] = scaledProb >= smallRando;

                flipsDone++;
            }
            return (outcomes, seed);
        }
        
        //batch flips where each flip is weighted individually.  weights array must be of length equal to numFlips or greater
        public static (bool[], Random) flipxDiffWeights(int numFlips, double[] weights, Random seed)
        {

            long bigRando = seed.NextInt64();
            long smallRando = 0;

            bool[] outcomes = new bool[numFlips];
            int segmentsUsed = 0;
            int flipsDone = 0;
            while (flipsDone < numFlips)
            {
                if (segmentsUsed > 8)
                {
                    segmentsUsed = 0;
                    bigRando = seed.NextInt64();

                }
                smallRando = bigRando & 0x7F;
                bigRando >>= 7;
                segmentsUsed++;

                outcomes[flipsDone] = (int)(weights[flipsDone] * 127.0) >= smallRando;

                flipsDone++;
            }
            return (outcomes, seed);
        }





    }

}
