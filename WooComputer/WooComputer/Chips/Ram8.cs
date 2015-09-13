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
    /// </summary>
    public class Ram
    {
        Register[] registers;
        public bool Load { get; set; }
        public int Address { get; set; }
        public Ram(int width)
        {
            registers = new Register[width];
        }
        public Register GetOutput()
        {
            registers[Address].SetLoad(Load);
            return registers[Address];
            
        }
    }
}
