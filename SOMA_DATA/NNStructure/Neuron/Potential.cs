using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMA_DATA
{
    public class Potential
    {
        public double current { get; set; }
        public double minimal { get; set; }

        public void UpdateLoserPotential(int numbersOfNeurons)
        {
            current = current + (1.0/numbersOfNeurons);
            if (current > 1)
                current = 1;
        }

        public void UpdateWinnerPotential()
        {
            current = current - minimal;
            if (current < 0)
                current = 0;
        }
    }
}
