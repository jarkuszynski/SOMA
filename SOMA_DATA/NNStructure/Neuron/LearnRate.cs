using System;

namespace SOMA_DATA
{
    public class LearnRate
    {
        public double current { get; set; }            //n(k)
        public double starting { get; set; }            //n0
        public double minimal { get; set; }             // n min

        public void UpdateLearningRate(int currK, int maxK)
        {
            current = starting * Math.Pow((1.0 * minimal / starting), (1.0 * currK / maxK));
        }
    }
}