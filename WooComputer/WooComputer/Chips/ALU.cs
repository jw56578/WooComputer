using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    public class ALU
    {
        public ALU(int width) { 
        
        }
        public Tuple<bool[], bool, bool> Cycle(bool[] x,bool[] y, bool resetX, bool negateX, bool resetY, bool negateY,bool f, bool negateOutput) 
        {
            x = Gates.Mux(x, new bool[] { false, false, false, false, false, false, false, false }, resetX);
            var notX = Gates.Not(x);
            x = Gates.Mux(x, notX, negateX);

            y = Gates.Mux(y, new bool[] { false, false, false, false, false, false, false, false }, resetY);
            var notY = Gates.Not(y);
            y = Gates.Mux(y, notY, negateY);

            var XandY = Gates.And(x, y);

            var XplusY = Operators.Add(x, y);

            var fOut = Gates.Mux(XandY, XplusY, f);

            var notFOut = Gates.Not(fOut);

            var final = Gates.Mux(fOut, notFOut, negateOutput);

            /* NOT SURE HOW TO DO THIS YET?
             * // Need out final mux so that we can save the final output and run a few
                // tests on it below.
                Mux16(a=final, b=false, sel=false, out=out);

                // ----- Return true if the output is zero (zr)
                // Or over all 16 bits. This will return false if the number is zero,
                // so flip the bit so that zr is true
                Or16Way(in=final, out=zrOut);
                Not(in=zrOut, out=zr);

                // ----- Return true if the output is negative (ng)
                // The most significant bit will be 1 if the number is negative thanks to
                // 2's complement. But I abstracted all of that out into another chip.
                IsNeg(in=final, out=ng);
             * */
            //i have no idea how to do this with just gates
            var zr = false;
            foreach (var b in final) 
            {
                if (b) {
                    zr = true;
                }
            }
            // i have no idea how to do this with just gates
            //the first position is the sign
            var ng = final[final.Length -1];

            return new Tuple<bool[],bool,bool>(final,zr,ng);
        }
    }
}
