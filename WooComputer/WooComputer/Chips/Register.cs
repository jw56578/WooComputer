using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    /// <summary>
    /// should load be a property or a method parameter
    /// </summary>
    public class Register
    {
        Bit[] bits = null;
        public Register(int width) {
            bits = new Bit[width];
        }
        public void SetLoad( bool load) {
            foreach (var b in bits) {
                b.Load = load;
            }
        }
        public Bit[] GetOutput()
        {
            return bits;
        }
    }
}
