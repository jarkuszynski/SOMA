using System;

namespace SOMA_DATA
{
    public class Neuron
    {
        public double XWeight { get; set; }
        public double YWeight { get; set; }
        public LearnRate LearnRate { get; set; }
        public Potential Potential { get; set; }
        public double distanceFromInputVector { get; set; }

        public Neuron(Random r, double startingLR, double minimalLR, double minimalP)
        {
            XWeight = (r.NextDouble() * 20.0) - 10.0;
            YWeight = (r.NextDouble() * 20.0) - 10.0;
            distanceFromInputVector = new double();
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