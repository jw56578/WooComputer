using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    /// <summary>
    /// 6 bit address
    /// </summary>
    public class Ram32K
    {
        Ram16K r1 = null;
        Ram16K r2 = null;
        Ram16K r3 = null;
        Ram16K r4 = null;
        public Ram32K(int width)
        {
            r1 = new Ram16K(width);
            r2 = new Ram16K(width);
            r3 = new Ram16K(width);
            r4 = new Ram16K(width);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="load"></param>
        /// <param name="address">16 bits</param>
        /// <returns></returns>
        public bool[] Cycle(bool[] input, bool load, bool[] address)
        {
            var output = Gates.DMux4Way(load, new bool[] { address[0], address[1] });

            var r1output = r1.Cycle(input, output.Item1, new bool[] { address[2], address[3], address[4], address[5], address[6], address[7], address[8], address[9], address[10], address[11], address[12], address[13] });
            var r2output = r2.Cycle(input, output.Item2, new bool[] { address[2], address[3], address[4], address[5], address[6], address[7], address[8], address[9], address[10], address[11], address[12], address[13] });
            var r3output = r3.Cycle(input, output.Item3, new bool[] { address[2], address[3], address[4], address[5], address[6], address[7], address[8], address[9], address[10], address[11], address[12], address[13] });
            var r4output = r4.Cycle(input, output.Item4, new bool[] { address[2], address[3], address[4], address[5], address[6], address[7], address[8], address[9], address[10], address[11], address[12], address[13] });

            var muxout = Gates.Mux4Way16(r1output, r2output, r3output, r4output, new bool[] { address[0], address[1] });

            return muxout;

        }
    }
}
