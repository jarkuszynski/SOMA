using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMA_DATA
{
    public class NeuralNetwork
    {
        public Dictionary<int,Neuron> neurons { get; set; }
        public double[] entriesX { get; set; }
        public double[] entriesY { get; set; }
        public double maxNeighbourhoodRadius { get; set; }
        public double minNeighbourhoodRadius { get; set; }
        Random random = new Random();
        public NeuralNetwork(double[] X, double[] Y, double startLearningRate, double minimalLearningRate, double startPotential, int numberOfNeurons, double maxNeighRadius, double minNeighRadius)
        {
            entriesX = X;
            entriesY = Y;
            maxNeighbourhoodRadius = maxNeighRadius;
            minNeighbourhoodRadius = minNeighRadius;
            neurons = new Dictionary<int, Neuron>();

            for (int i = 0; i < numberOfNeurons; i++)
            {
                neurons.Add(i, new Neuron(random, startLearningRate, minimalLearningRate, startPotential));
            }
        }

        public Dictionary<int,Neuron> KohonenAlgorithm()
        {
            KohonenAlgorithm kohonen = new KohonenAlgorithm(neurons, entriesX, entriesY, maxNeighbourhoodRadius, minNeighbourhoodRadius);
            return kohonen.CalculateNeurons(1000);
        }

        public Dictionary<int, Neuron> NGasAlgorithm()
        {
            NeuronGas nGas = new NeuronGas(neurons, entriesX, entriesY, maxNeighbourhoodRadius, minNeighbourhoodRadius);
            return nGas.CalculateNeurons(1000);
        }
    }
}