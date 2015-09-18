using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    public partial class CPU16Bit
    {
        public class CPUAnalyzer
        {
            public CPU16Bit cpu = null;
            public CPUAnalyzer() {
               
            }

            public bool[] GetDContents() {
                return cpu.d.Cycle(new bool[16], false);
            }
            public bool[] GetAContents()
            {
                return cpu.a.Cycle(new bool[16], false);
            }
            public bool[] GetAluOut()
            {
                return cpu.aluOut;
            }
          
          
        }
    }
    
}
