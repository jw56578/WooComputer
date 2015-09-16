using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    /// <summary>
    /// 
    /// the load and input should not be maintained as properties becauses a Bit does not maintain state, only the flip flop does
    /// maintaining the flip flop as a property denotes that the flip flop is part of the hardware of the Bit chip
    /// </summary>
    public class Bit
    {
        DFlipFlop flipFlop;
        public Bit(DFlipFlop dff)
        {
            flipFlop = dff;
        }
        public Bit() : this(new DFlipFlop()) { 
        
        }
        public bool Cycle(bool input, bool load) {
            var output = Gates.Mux(flipFlop.Value, input, load);
            flipFlop.Value = output;
            return output;
        }
    }
}
