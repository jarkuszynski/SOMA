using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMA_DATA
{
    public class NeuralNetwork
    {
        public List<Neuron> neurons { get; set; }
        public double[] entriesX { get; set; }
        public double[] entriesY { get; set; }
        public double neighbourhoodRadius { get; set; }
        Random random = new Random();
        public NeuralNetwork(double[] X, double[] Y, double startLearningRate, double minimalLearningRate, double startPotential, int numberOfNeurons, double neighRadius)
        {
            entriesX = X;
            entriesY = Y;
            neighbourhoodRadius = neighRadius;
            neurons = new List<Neuron>();

            for (int i = 0; i < numberOfNeurons; i++)
            {
                neurons.Add(new Neuron(random, startLearningRate, minimalLearningRate, startPotential));
            }
        }
    }
}
