namespace RandLib.BinomialDist
{
    public class BinomialDist
    {
        public static int[] rollWithoutReplacement(DistTable outcomes, int numRolls)
        {
            Random rng = new Random();
            int[] results = new int[numRolls];

            DistTable tableCopy = outcomes.Copy();

            for (int i = 0; i < numRolls; i++)
            {
                int roll;
                (roll, rng) = CategoricalDist.CategoricalDist.rollWeighted(tableCopy, rng);

                results[i] = tableCopy.IndexMap[roll];
                tableCopy.RemoveWeightAtInPlace(roll);
            }


            return results;
        }

        public static (int[], Random) rollWithoutReplacement(DistTable outcomes, int numRolls, Random seed)
        {
            int[] results = new int[numRolls];

            DistTable tableCopy = outcomes.Copy();

            for (int i = 0; i < numRolls; i++)
            {
                int roll;
                (roll, seed) = CategoricalDist.CategoricalDist.rollWeighted(tableCopy, seed);

                results[i] = tableCopy.IndexMap[roll];
                tableCopy.RemoveWeightAtInPlace(roll);
            }


            return (results, seed);
        }
    }
}