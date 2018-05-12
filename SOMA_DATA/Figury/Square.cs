using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMA_DATA
{
    public class Square : IFigureable
    {
        public void generatePoints(out double[] pointsX, out double[] pointsY)
        {
            pointsX = new double[1000];
            pointsY = new double[1000];
            Random r = new Random();

            for (int i = 0; i < pointsX.Length; i++)
            {
                pointsX[i] = ((r.NextDouble() * 4.0) - 2.0);
                pointsY[i] = ((r.NextDouble() * 4.0) - 2.0);
            }
        }
    }
}
