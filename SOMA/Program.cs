using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using AwokeKnowing.GnuplotCSharp;
using SOMA_DATA;

namespace SOMA
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPoints = 1000;
            double[] pointsX = new double[numberOfPoints];
            double[] pointsY = new double[numberOfPoints];
            double maxLR = new double();
            double minLR = new double();
            double maxPotential = new double();
            int numberOfNeurons = new int();
            double maxLambda = new double();
            double minLambda = new double();
            int numberOfEpochs = new int();
            IFigureable figureable;

            Console.WriteLine("Samoorganizujaca sie siec neuronowa");
            Console.WriteLine("Prosze wybrac figure: ");
            Console.WriteLine("1. Kwadrat");
            Console.WriteLine("2. Trojkat");
            Console.WriteLine("3. Kolo");
            Console.WriteLine("4. Plik testowy");
            Console.WriteLine("Wybor: ");
            ConsoleKeyInfo choice = Console.ReadKey();
            switch (choice.KeyChar)
            {
                case '1':
                    figureable = new Square();
                    figureable.generatePoints(out pointsX, out pointsY,numberOfPoints);
                    GnuPlot.Plot(pointsX, pointsY);
                    break;

                case '2':
                    figureable = new Triangle();
                    figureable.generatePoints(out pointsX, out pointsY,numberOfPoints);
                    GnuPlot.Plot(pointsX, pointsY);
                    break;
                case '3':
                    figureable = new Circle();
                    figureable.generatePoints(out pointsX, out pointsY,numberOfPoints);
                    GnuPlot.Plot(pointsX, pointsY);
                    break;

                case '4':
                    string path = "Test.txt";
                    string fullpath = Path.GetFullPath(path);
                    StreamReader streamReader = new StreamReader(fullpath);
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        string sr = streamReader.ReadLine();
                        string[] parts = sr.Split(',');
                        pointsX[i] = Convert.ToDouble(parts[0].Replace('.', ','));
                        pointsY[i] = Convert.ToDouble(parts[1].Replace('.', ','));
                    }
                    GnuPlot.Plot(pointsX, pointsY);
                    break;

                default:
                    Console.WriteLine("Nie wybrano prawidlowej opcji");
                    break;
            }
            Console.WriteLine("Prosze wybrac sposob klasyfikacji danych: ");
            Console.WriteLine("1. Algorytm Kohonena oparty na gaussowskiej funkji sasiedztwa.");
            Console.WriteLine("2. Algorytm gazu neuronowego.");
            ConsoleKeyInfo choice2 = Console.ReadKey();
            switch(choice2.KeyChar)
            {
                case '1':
                    maxLR = 0.7;
                    minLR = 0.005;
                    maxPotential = 0.85;
                    numberOfNeurons = 200;
                    maxLambda = 0.0013;
                    minLambda = 0.001;
                    numberOfEpochs = 5;

                    NeuralNetwork NNKohonenParameters = new NeuralNetwork(pointsX, pointsY, maxLR, minLR, maxPotential, numberOfNeurons, maxLambda, minLambda);      //zalezne od potencjalu oraz shuffle danych Kohonen
                    NNKohonenParameters.KohonenAlgorithm(numberOfPoints, numberOfEpochs);
                    break;

                case '2':
                    maxLR = 0.6;
                    minLR = 0.03;
                    maxPotential = 0.2;
                    numberOfNeurons = 200;
                    maxLambda = 10.0;
                    minLambda = 1.0;
                    numberOfEpochs = 2;

                    NeuralNetwork NNGasParameters = new NeuralNetwork(pointsX, pointsY, maxLR, minLR, maxPotential, numberOfNeurons, maxLambda, minLambda);      //zalezne od potencjalu oraz shuffle danych //NGAS
                    NNGasParameters.NGasAlgorithm(numberOfPoints, numberOfEpochs);
                    break;
            }
            
            //GnuPlot.Plot(pointsXEND, pointsYEND);
            // GnuPlot.HoldOn();
            // int xx = -1;
            // GnuPlot.Plot(x, y, "with linespoints");
            // GnuPlot.Set("parametric");
            // GnuPlot.Set("size square");
            // GnuPlot.Set("trange [0:3]");
            // GnuPlot.Set($"xrange [{xx}:1]");
            // GnuPlot.Set("yrange [-1:1]");
            // GnuPlot.Plot("t + 3,t");
            // //GnuPlot.Plot("t*2,t + 5");
            //// GnuPlot.Plot("t*0,t + 5");
            // GnuPlot.Plot(pointsX, pointsY);


            //kwadrat
            //GnuPlot.Write("const=3\n");
            //GnuPlot.Set("trange [0:3]");        //dlugosc boku
            //GnuPlot.Set("xrange [0:5]");        //wiuelkosc okna
            //GnuPlot.Set("yrange [0:5]");        //wielkosc okna
            //GnuPlot.Plot("const, t");
            //GnuPlot.Write("const=3\n");
            //GnuPlot.Set("trange [0:3]");
            //GnuPlot.Plot("t, const");
            //GnuPlot.Write("const2=0\n");
            //GnuPlot.Plot("t, const2");
            //GnuPlot.Plot("const2, t");
            Console.ReadKey();
        }
    }
}
