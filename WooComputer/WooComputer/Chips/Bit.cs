using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    /// <summary>
    /// should it be like this or should the GetOutput method have a load argument that determines whether the input should be returned or the flip flop value?
    /// </summary>
    public class Bit
    {
        DFlipFlop flipFlop;
        public bool Load { get; set; }
        public bool Input { get; set; }
        public Bit(DFlipFlop dff)
        {
            flipFlop = dff;
        }
        public bool GetOutput() {
            var output =  Gates.Mux(flipFlop.Value, Input, Load);
            flipFlop.Value = output;
            return output;
        }
    }
}
