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
            double[] pointsX;
            double[] pointsY;
            IFigureable figureable;

            Console.WriteLine("Samoorganizujaca sie siec neuronowa");
            Console.WriteLine("Prosze wybrac figure: ");
            Console.WriteLine("1. Kwadrat");
            Console.WriteLine("2. Trojkat");
            Console.WriteLine("3. Kolo");
            Console.WriteLine("Wybor: ");
            ConsoleKeyInfo choice = Console.ReadKey();
            switch (choice.KeyChar)
            {
                case '1':
                    figureable = new Square();
                    figureable.generatePoints(out pointsX, out pointsY);
                    GnuPlot.Plot(pointsX, pointsY);
                    break;

                case '2':
                    figureable = new Triangle();
                    figureable.generatePoints(out pointsX, out pointsY);
                    GnuPlot.Plot(pointsX, pointsY);
                    break;
                case '3':
                    figureable = new Circle();
                    figureable.generatePoints(out pointsX, out pointsY);
                    GnuPlot.Plot(pointsX, pointsY);
                    break;
                default:
                    Console.WriteLine("Nie wybrano prawidlowej opcji");
                    break;
            }



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
