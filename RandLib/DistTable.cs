namespace RandLib
{
    public class DistTable
    {
        //weights is an array that tracks the CDF of each value multiplied by the total weight in the list 
        // (ex, 1st element is 1k, 2nd is 2k and no others, weights[0] will be (1k/3k) * 3k = 1k and weights[1] will be (1k+2k)/3k * 3k = 3k )
        int[] Weights;
        int TotalWeight;

        public DistTable(int[] ws)
        {
            Weights = [];
            TotalWeight = 0;
            for (int i = 0; i < ws.Length; i++)
            {
                TotalWeight += ws[i];
                Weights[i] = TotalWeight;
            }
        }
    }
}