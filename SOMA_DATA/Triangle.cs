using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMA_DATA
{
    public class Triangle : IFigureable
    {
        public void generatePoints(out double[] pointsX, out double[] pointsY)
        {
            pointsX = new double[1000];
            pointsY = new double[1000];
            Random r = new Random();

            for (int i = 0; i < pointsX.Length; i++)
            {
                bool isGood = false;
                while (!isGood)
                {
                    pointsX[i] = ((r.NextDouble() * 4.0) - 2.0);
                    pointsY[i] = (r.NextDouble() * 4.0 - 2.0);
                    if (pointsY[i] < pointsX[i] + 2 && pointsY[i] < pointsX[i] * -1.0 + 2 && pointsY[i] > 0)
                        isGood = true;
                }
            }
        }
    }
}
