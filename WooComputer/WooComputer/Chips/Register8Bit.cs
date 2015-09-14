using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    /// <summary>
    /// trying the attempt of hard coding the bit width of the register like it is done in reality
    /// </summary>
    public class Register8Bit
    {
        public Bit Bit1 = new Bit();
        public Bit Bit2 = new Bit();
        public Bit Bit3 = new Bit();
        public Bit Bit4 = new Bit();
        public Bit Bit5 = new Bit();
        public Bit Bit6 = new Bit();
        public Bit Bit7 = new Bit();
        public Bit Bit8 = new Bit();

        public bool[] GetOutput() {
            return null;// return new bool[] { Bit1.Input, Bit2.Input, Bit3.Input };//...
        }
    }
}
