using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMA_DATA
{
    public class LearnRate
    {
        public double current { get; set; }            //n(k)
        public double starting { get; set; }            //n0
        public double minimal { get; set; }             // n min

        public void UpdateLearningRate(int currK, int maxK)
        {
            current = starting * Math.Pow((minimal / starting), (currK / maxK));
        }

    }
}
