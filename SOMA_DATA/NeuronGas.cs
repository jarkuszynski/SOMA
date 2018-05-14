using AwokeKnowing.GnuplotCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMA_DATA
{
    class NeuronGas
    {
        public Dictionary<int, Neuron> neurons { get; set; }
        public double[] pointsX { get; set; }
        public double[] pointsY { get; set; }
        public double maxNeighRadius { get; set; }
        public double minNeighRadius { get; set; }
        public double currentNeighRadius { get; set; }

        public NeuronGas(Dictionary<int, Neuron> keyValuePairs, double[] X, double[] Y, double maxLambda, double minLambda)
        {
            neurons = new Dictionary<int, Neuron>();
            neurons = keyValuePairs;
            pointsX = X;
            pointsY = Y;
            maxNeighRadius = maxLambda;
            minNeighRadius = minLambda;
        }

        public Dictionary<int, Neuron> CalculateNeurons(int numberOfDataSamples, int numberOfEpochs)
        {
            int currEpoch = 0;
            while (currEpoch < numberOfEpochs)
            {
                ShuffleDataSet(pointsX, pointsY, numberOfDataSamples/25);
                for (int currInPoint = 0; currInPoint < numberOfDataSamples; currInPoint++)        //CALY PROCES NAUKI
                {
                    double minDistance = double.MaxValue;       //double max
                    int winnerIndex = new int();
                    Dictionary<int, double> GFunctionValues = new Dictionary<int, double>();
                    UpdateRadius(currInPoint, numberOfDataSamples);
                    for (int K = 0; K < neurons.Count; K++)
                    {
                        neurons[K].LearnRate.UpdateLearningRate(currInPoint, numberOfDataSamples);
                        if (neurons[K].Potential.current >= neurons[K].Potential.minimal)        //sprawdzenie warunku potencjalu
                        {
                            neurons[K].distanceFromInputVector = EuclideanDistance(K, pointsX[currInPoint], pointsY[currInPoint]);
                            if (neurons[K].distanceFromInputVector < minDistance)                                      //sprawdzenie czy obecnie wyliczona odleglosc jest mniejsza obecnej najmniejszej
                            {
                                winnerIndex = K;
                                minDistance = neurons[K].distanceFromInputVector;
                            }
                        }
                    }
                    //NEURON ZWYCIESKI ZNALEZIONY

                    //ZAKTUALIZOWANIE POTENCJALU NEURONOW PRZEGRANYCH
                    for (int K = 0; K < neurons.Count; K++)
                    {
                        if (K != winnerIndex)
                            neurons[K].Potential.UpdateLoserPotential(neurons.Count);
                    }

                    //ZAKTUALIZOWANIE POTENCJALU NEURONU WYGRANEGO
                    neurons[winnerIndex].Potential.UpdateWinnerPotential();

                    //POSORTOWANIE NEURONOW OD NAJMNIEJSZEJ ODLEGLOSCI DO NAJWIEKSZEJ OD WEKTORA WEJSCIOWEGO
                    Dictionary<int, Neuron> sortedNeurons = (neurons.OrderBy(n => n.Value.distanceFromInputVector)).ToDictionary(n => n.Key, n => n.Value);

                    //WYLICZENIE FUNKCJI SASIEDZTWA DLA KAZDEGO NEURONU
                    for (int K = 0; K < sortedNeurons.Count; K++)
                    {
                        GFunctionValues[K] = Math.Exp(-1.0 * (1.0 * K / currentNeighRadius * 1.0));
                    }

                    foreach (var neuron in neurons)
                    {
                        int iterator = 0;
                        foreach (var sortedNeuron in sortedNeurons)
                        {
                            if (neuron.Key == sortedNeuron.Key)
                            {
                                neuron.Value.XWeight += neuron.Value.LearnRate.current * GFunctionValues[iterator] * (pointsX[currInPoint] - neuron.Value.XWeight);
                                neuron.Value.YWeight += neuron.Value.LearnRate.current * GFunctionValues[iterator] * (pointsY[currInPoint] - neuron.Value.YWeight);
                            }
                            iterator++;
                        }

                    }
                    double[] pointsXEND = new double[neurons.Count];
                    double[] pointsYEND = new double[neurons.Count];
                    //ZAPIS EWENTUALNY WAG DO WYKRESU RUCHOMEGO
                    for (int K = 0; K < neurons.Count; K++)
                    {
                        pointsXEND[K] = neurons[K].XWeight;
                        pointsYEND[K] = neurons[K].YWeight;
                    }
                    if (currInPoint % 10 == 0)
                        GnuPlot.Plot(pointsXEND, pointsYEND);
                }
                currEpoch++;
            }
            return neurons;
        }

        public void UpdateRadius(int currK, int maxK)
        {
            currentNeighRadius = 1.0 * maxNeighRadius * Math.Pow((1.0 * minNeighRadius / maxNeighRadius), (1.0 * currK / maxK));
        }

        public double EuclideanDistance(int currK, double pointsX, double pointsY)
        {
            double suma = 0;
            suma = Math.Pow((pointsX - neurons[currK].XWeight), 2) + Math.Pow((pointsY - neurons[currK].YWeight), 2);
            suma = Math.Sqrt(suma);
            return suma;
        }

        public void ShuffleDataSet(double[] setX, double[] setY, int shuffleNumber)
        {
            var randomizer = new Random();
            int setLength = setX.Length;
            for (int i = 0; i < shuffleNumber; i++)
            {
                int firstIndex = randomizer.Next(setLength);
                int secondIndex = randomizer.Next(setLength);
                var tempX = setX[firstIndex];
                var tempY = setY[firstIndex];
                setX[firstIndex] = setX[secondIndex];
                setX[secondIndex] = tempX;
                setY[firstIndex] = setX[secondIndex];
                setX[secondIndex] = tempY;
            }
        }
    }
}
