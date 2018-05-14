using System;

namespace SOMA_DATA
{
    public class Square : IFigureable
    {
        public void generatePoints(out double[] pointsX, out double[] pointsY, int numberOfPoints)
        {
            pointsX = new double[numberOfPoints];
            pointsY = new double[numberOfPoints];
            Random r = new Random();

            for (int i = 0; i < pointsX.Length; i++)
            {
                pointsX[i] = ((r.NextDouble() * 20.0) - 10.0);
                pointsY[i] = ((r.NextDouble() * 20.0) - 10.0);
            }
        }
    }
}