using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    /// <summary>
    /// Should the address desired be a property or should the GetOutput method take it as an argument?
    /// Should the Load bit be a property or an argument to the method
    /// in reality the number of registers in a piece of ram is hard coded as there is no way to loop
    /// </summary>
    public class RAM
    {
        Register[] registers;
        public RAM(int width, int registerWidth)
        {
            registers = new Register[width];
            for (int i = 0; i < registers.Length; i++) {
                registers[i] = new Register(registerWidth);
            }
        }
        //address is really suppose to be an array of bits
        public bool[] Cycle(bool[] input, bool load,int address)
        {
            return registers[address].Cycle(input, load);

        }

    }
}
