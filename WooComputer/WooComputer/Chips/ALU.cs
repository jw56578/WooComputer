using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    public class ALU
    {
        int width = 0;
        bool[] falseValue;
        public ALU(int width) {
            this.width = width;
            falseValue = new bool[width];

        }
        /// <summary>
        /// https://github.com/jw56578/Elements-of-Computing-Systems/blob/master/project02/ALU.hdl
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="resetX">Change x back to all false</param>
        /// <param name="negateX">Change x to the opposite of what it is</param>
        /// <param name="resetY">Change y back to all false</param>
        /// <param name="negateY">Changey to the opposite of what it is</param>
        /// <param name="f">
        // if (f==1)  set out = x + y  // integer 2's complement addition
        // if (f==0)  set out = x & y  // bitwise "and"
        //</param>
        /// <param name="negateOutput">Take the final output and reverse it</param>
        /// <returns>Item1 = output, Item2 = Is zero, Item3 = Is negative</returns>
        public Tuple<bool[], bool, bool> Cycle(bool[] x,bool[] y, bool resetX, bool negateX, bool resetY, bool negateY,bool f, bool negateOutput) 
        {
            x = Gates.Mux(x, falseValue, resetX);
            var notX = Gates.Not(x);
            x = Gates.Mux(x, notX, negateX);

            y = Gates.Mux(y, falseValue, resetY);
            var notY = Gates.Not(y);
            y = Gates.Mux(y, notY, negateY);

            var XandY = Gates.And(x, y);

            var XplusY = Operators.Add(x, y);

            var fOut = Gates.Mux(XandY, XplusY, f);

            var notFOut = Gates.Not(fOut);

            var final = Gates.Mux(fOut, notFOut, negateOutput);

   
            final = Gates.Mux(final, new bool[16], false);
            var isZeroOrOutput = Gates.Or16Way(final);
            var zr = Gates.Not(isZeroOrOutput);


            var ng = Gates.IsNegative(final);

            return new Tuple<bool[],bool,bool>(final,zr,ng);
        }
    }
}
