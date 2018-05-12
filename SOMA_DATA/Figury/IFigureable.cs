using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMA_DATA
{
    public interface IFigureable
    {
        void generatePoints(out double[] pointsX, out double[] pointsY);
    }
}
