using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    /// <summary>
    /// should this thing implement an interface in order to be a Time Dependent Chip? like the traingle indicates?
    /// should this thing take function delegates to call when the program counter is cycled
    /// i'm kind of confused on this, if return the input then you are returning an array of bits, but if you reset then you are returning zero
    /// so in this case i must maintain the reality of binary and return a array of false to indicate zero
    /// 
    /// </summary>
    public class ProgramCounter
    {
        Register r;
        int width;
        public ProgramCounter(int width)
        {
            //register is used to maintain the state of the counter
            r = new Register(width);
            this.width = width;
        }
        public bool[] Cycle(bool[] instruction, bool load, bool increment, bool reset)
        {
            //use C# operators here because this is not normal in a chip
            if (load && increment && reset || (increment && reset) || (load && increment) || (reset && load) || (load && reset)) {
                throw new Exception("Only one control bit can be set at a time.");
            }

            //need to make this work with only once register cycle
            //if nothing is true then you just output the current value
           
            //reset everything back to 
            var inputOrReset = Gates.Mux(instruction, new bool[width] , reset);
            // if load = true then output will be instruction from the previous statement and it shoudl be loaded, if reset is true then output will be false and should be loaded
            var output = r.Cycle(inputOrReset, Gates.Or(load, reset));

            var add = Operators.Add(output, Functions.GetBitArrayFromInteger(1,width));
            output = Gates.Mux(output, add, increment);
            output = r.Cycle(output, increment);

            return output;
        }


    }
}
