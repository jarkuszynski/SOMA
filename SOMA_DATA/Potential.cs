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
        }

        public void UpdateWinnerPotential()
        {
            current = current - minimal;
        }
    }
}
