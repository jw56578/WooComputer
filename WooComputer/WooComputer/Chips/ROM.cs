using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    public class ROM
    {
        List<bool[]> instructions;
        Ram16K memory = new Ram16K(16);
        public ROM(List<bool[]> instructions)
        {
            for (int i = 0; i < instructions.Count; i++) 
            {
                memory.Cycle(instructions[i],true,Functions.GetBitArrayFromInteger(i, 14));
            }
                
        }
        public bool[] Cycle(bool[] address)
        {
            return memory.Cycle(new bool[16], false, address);
        }
    }
}
