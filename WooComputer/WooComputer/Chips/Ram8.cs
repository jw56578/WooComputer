using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    public class Ram8
    {
        Register r1 = null;
        Register r2 = null;
        Register r3 = null;
        Register r4 = null;
        Register r5 = null;
        Register r6 = null;
        Register r7 = null;
        Register r8 = null;


        public Ram8(int width)
        {
            r1 = new Register(width);
            r2 = new Register(width);
            r3 = new Register(width);
            r4 = new Register(width);
            r5 = new Register(width);
            r6 = new Register(width);
            r7 = new Register(width);
            r8 = new Register(width);
        }
        public bool[] Cycle(bool[] input, bool load, bool[] address)
        {

            var output = Gates.DMux8Way(load, address);

            var r1output = r1.Cycle(input, output.Item1);
            var r2output = r2.Cycle(input, output.Item2);
            var r3output = r3.Cycle(input, output.Item3);
            var r4output = r4.Cycle(input, output.Item4);
            var r5output = r5.Cycle(input, output.Item5);
            var r6output = r6.Cycle(input, output.Item6);
            var r7output = r7.Cycle(input, output.Item7);
            var r8output = r8.Cycle(input, output.Rest.Item1);


            var muxout = Gates.Mux8Way16(r1output, r2output, r3output, r4output, r5output, r6output, r7output, r8output, address);

            return muxout;

        }
    }
}
