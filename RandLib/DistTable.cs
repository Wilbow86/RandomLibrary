namespace RandLib
{
    public class DistTable
    {
        //weights is an array that tracks the CDF of each value multiplied by the total weight in the list 
        // (ex, 1st element is 1k, 2nd is 2k and no others, weights[0] will be (1k/3k) * 3k = 1k and weights[1] will be (1k+2k)/3k * 3k = 3k )
        public int[] Weights;
        public int TotalWeight;

        public DistTable(int[] ws)
        {
            Weights = new int[ws.Length];
            TotalWeight = 0;

            for (int i = 0; i < ws.Length; i++)
            {
                TotalWeight += ws[i];
                Weights[i] = TotalWeight;
            }
        }

        public DistTable RemoveWeightAt(int index)
        {

            int[] newWeights = new int[Weights.Length - 1];

            int amntRemoved = Weights[index];

            for (int i = 0; i < newWeights.Length; i++)
            {
                if (i >= index)
                {
                    newWeights[i] = Weights[i + 1] - amntRemoved;
                }
                else
                {
                    newWeights[i] = Weights[i];
                }
            }

            DistTable smallerTable = new DistTable(newWeights);

            return smallerTable;
        }

        public bool isEmpty()
        {
            return Weights.Length == 0;
        } 
    }
}