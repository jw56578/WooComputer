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
        public ROM(List<bool[]> instructions)
        {
            this.instructions = instructions;
        }
        public bool[] Cycle(int address)
        {
            return instructions[address];
        }
    }
}
