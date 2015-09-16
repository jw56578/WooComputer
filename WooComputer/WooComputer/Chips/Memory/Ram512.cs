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
    public class Ram512
    {
        Ram64 r1 = null;
        Ram64 r2 = null;
        Ram64 r3 = null;
        Ram64 r4 = null;
        Ram64 r5 = null;
        Ram64 r6 = null;
        Ram64 r7 = null;
        Ram64 r8 = null;


        public Ram512(int width)
        {
            r1 = new Ram64(width);
            r2 = new Ram64(width);
            r3 = new Ram64(width);
            r4 = new Ram64(width);
            r5 = new Ram64(width);
            r6 = new Ram64(width);
            r7 = new Ram64(width);
            r8 = new Ram64(width);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="load"></param>
        /// <param name="address">9 bits</param>
        /// <returns></returns>
        public bool[] Cycle(bool[] input, bool load, bool[] address)
        {

            var output = Gates.DMux8Way(load, new bool[] { address[0], address[1], address[2] });

            var r1output = r1.Cycle(input, output.Item1, new bool[] { address[3], address[4], address[5], address[6], address[7], address[8] });
            var r2output = r2.Cycle(input, output.Item2, new bool[] { address[3], address[4], address[5], address[6], address[7], address[8] });
            var r3output = r3.Cycle(input, output.Item3, new bool[] { address[3], address[4], address[5], address[6], address[7], address[8] });
            var r4output = r4.Cycle(input, output.Item4, new bool[] { address[3], address[4], address[5], address[6], address[7], address[8] });
            var r5output = r5.Cycle(input, output.Item5, new bool[] { address[3], address[4], address[5], address[6], address[7], address[8] });
            var r6output = r6.Cycle(input, output.Item6, new bool[] { address[3], address[4], address[5], address[6], address[7], address[8] });
            var r7output = r7.Cycle(input, output.Item7, new bool[] { address[3], address[4], address[5], address[6], address[7], address[8] });
            var r8output = r8.Cycle(input, output.Rest.Item1, new bool[] { address[3], address[4], address[5], address[6], address[7], address[8] });


            var muxout = Gates.Mux8Way16(r1output, r2output, r3output, r4output, r5output, r6output, r7output, r8output, new bool[] { address[0], address[1], address[2] });

            return muxout;

        }
    }
}
