using AwokeKnowing.GnuplotCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMA_DATA
{
    public class KohonenAlgorithm
    {
        public Dictionary<int,Neuron> neurons { get; set; }
        public double[] pointsX { get; set; }
        public double[] pointsY { get; set; }
        public double maxNeighRadius { get; set; }
        public double minNeighRadius { get; set; }
        public double currentNeighRadius { get; set; }

        public KohonenAlgorithm(Dictionary<int,Neuron> keyValuePairs, double[] X, double[] Y, double maxLambda, double minLambda)
        {
            neurons = new Dictionary<int, Neuron>();
            neurons = keyValuePairs;
            pointsX = X;
            pointsY = Y;
            maxNeighRadius = maxLambda;
            minNeighRadius = minLambda;
        }

        public Dictionary<int,Neuron> CalculateNeurons(int numberOfDataSamples, int numberOfEpochs)
        {
            int currEpoch = 0;
            while (currEpoch < numberOfEpochs)
            {
                //ShuffleDataSet(pointsX, pointsY, numberOfDataSamples/25);
                for (int currInPoint = 0; currInPoint < numberOfDataSamples; currInPoint++)        //WHOLE LEARNING PROCESS
                {
                    double minDistance = 10000000000;
                    double currDistance = 0;
                    int winnerIndex = new int();
                    List<int> neighboursOfWinnerNeuron = new List<int>();
                    Dictionary<int, double> GFunctionValues = new Dictionary<int, double>();
                    UpdateRadius(currInPoint, numberOfDataSamples);            //ZAKTUALIZOWANIE LAMBDY
                    for (int K = 0; K < neurons.Count; K++)         //FIND WINNER NEURON
                    {
                        neurons[K].LearnRate.UpdateLearningRate(currInPoint, numberOfDataSamples);
                        if (neurons[K].Potential.current >= neurons[K].Potential.minimal)        //sprawdzenie warunku potencjalu
                        {
                            currDistance = EuclideanDistance(K, pointsX[currInPoint], pointsY[currInPoint]);
                            if (currDistance < minDistance)                                      //sprawdzenie czy obecnie wyliczona odleglosc jest mniejsza obecnej najmniejszej
                            {
                                winnerIndex = K;
                                minDistance = currDistance;
                            }
                        }
                    }
                    //ZNALEZIONO ZWYCIESKI NEURON

                    //ZAKTUALIZOWANIE POTENCJALU NEURONOW PRZEGRANYCH
                    for (int K = 0; K < neurons.Count; K++)
                    {
                        if (K != winnerIndex)
                            neurons[K].Potential.UpdateLoserPotential(neurons.Count);
                    }

                    //ZAKTUALIZOWANIE POTENCJALU NEURONU WYGRANEGO
                    neurons[winnerIndex].Potential.UpdateWinnerPotential();

                    double result = 0;
                    double nominator = 0;
                    double denominator = 0;
                    for (int K = 0; K < neurons.Count; K++)         //WYLICZENIE FUNKCJI G DLA KAZDEGO NEURONU
                    {
                        nominator = EuclideanDistance(winnerIndex, neurons[K].XWeight, neurons[K].YWeight) * EuclideanDistance(winnerIndex, neurons[K].XWeight, neurons[K].YWeight) * 1.0;
                        denominator = 2 * currentNeighRadius * currentNeighRadius * 1.0;
                        result = Math.Exp(-1.0 * nominator / denominator * 1.0);
                        GFunctionValues[K] = result;
                    }
                    //FUNKCJA G WYLICZONA
                    for (int K = 0; K < neurons.Count; K++)
                    {
                        neurons[K].XWeight += neurons[K].LearnRate.current * GFunctionValues[K] * (pointsX[currInPoint] - neurons[K].XWeight);
                        neurons[K].YWeight += neurons[K].LearnRate.current * GFunctionValues[K] * (pointsY[currInPoint] - neurons[K].YWeight);
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
            currentNeighRadius = 1.0 * maxNeighRadius * Math.Pow( (1.0 * minNeighRadius / maxNeighRadius), (1.0 * currK / maxK));
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
