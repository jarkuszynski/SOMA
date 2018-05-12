using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMA_DATA
{
    public class Neuron
    {
        public double XWeight { get; set; }
        public double YWeight { get; set; }
        public LearnRate LearnRate { get; set; }
        public Potential Potential { get; set; }

        public Neuron(Random r, double startingLR, double minimalLR, double minimalP)
        {
            XWeight = (r.NextDouble() * 4.0) - 2.0;
            YWeight = (r.NextDouble() * 4.0) - 2.0;
            LearnRate = new LearnRate
            {
                starting = startingLR,
                current = startingLR,
                minimal = minimalLR
            };

            Potential = new Potential
            {
                current = minimalP,
                minimal = minimalP
            };
        }
    }
}
