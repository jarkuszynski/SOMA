using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using AwokeKnowing.GnuplotCSharp;

namespace SOMA
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = "Test.txt";
            string fullpath = Path.GetFullPath(path1);
            double[] x = { -2, 2, 2, -2 };
            double[] y = { 2, 2, -2, -2 };
            double[] pointsX = new double[1000];
            double[] pointsY = new double[1000];
            Random random = new Random();
            
            //Kwadrat
            /*
            for (int i = 0; i < 200; i++)
            {
                pointsX[i] = ((random.NextDouble() * 3.0));
                pointsY[i] = (random.NextDouble() * 3.0);
                Console.WriteLine(pointsX[i] + " " + pointsY[i]);
            }
            */
           
            // Trojkat
            /*
            for (int i = 0; i < 1000; i++)
            {
                bool isGood = false;
                while (!isGood)
                {
                    pointsX[i] = ((random.NextDouble() * 4.0) - 2.0);
                    pointsY[i] = (random.NextDouble() * 4.0 - 2.0);
                    if (pointsY[i] < pointsX[i] + 2 && pointsY[i] < pointsX[i]* -1.0 + 2 && pointsY[i] > 0)
                        isGood = true;
                }
                Console.WriteLine(pointsX[i] + " " + pointsY[i]);
            }
            */

            GnuPlot.HoldOn();
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
            GnuPlot.Plot(pointsX, pointsY);


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
