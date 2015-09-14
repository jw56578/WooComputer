using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    /// <summary>
    /// should load be a property or a method parameter
    /// Deviating from normal way of doing things at lowest leve. This should just be hard coded to 16,32 or 64 bits because that is a hardware thing
    /// there are no loops in hardware
    /// I'll see how this works out
    /// how should input be set? property, method? should it take in just the actual real bits(true/false) or Bit objects?
    /// </summary>
    public class Register
    {
        Bit[] bits = null;
        public Register(int width) {
            bits = new Bit[width];
            for (int i = 0; i < bits.Length; i++) {
                bits[i] = new Bit();
            }
        }

        public bool[] Cycle(bool[] input, bool load)
        {
            List<bool> currentBits = new List<bool>();
            for (int i = 0; i < input.Length; i++)
            {
                currentBits.Add(bits[i].Cycle(input[i], load));
            }
            return currentBits.ToArray();
        }
    }
}
