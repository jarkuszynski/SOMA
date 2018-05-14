using System;

namespace SOMA_DATA
{
    public class Triangle : IFigureable
    {
        public void generatePoints(out double[] pointsX, out double[] pointsY, int numberOfPoints)
        {
            pointsX = new double[numberOfPoints];
            pointsY = new double[numberOfPoints];
            Random r = new Random();

            for (int i = 0; i < pointsX.Length; i++)
            {
                bool isGood = false;
                while (!isGood)
                {
                    pointsX[i] = ((r.NextDouble() * 20.0) - 10.0);
                    pointsY[i] = (r.NextDouble() * 20.0 - 10.0);
                    if (pointsY[i] + 10 < pointsX[i] * 2.0 + 20 && pointsY[i] + 10 < pointsX[i] * -2.0 + 20 && pointsY[i] > -10)
                        isGood = true;
                }
            }
        }
    }
}