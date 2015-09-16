using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    /// <summary>
    /// As adhering to the theme of this project. Only the NAnd gate can use built in C# operators, every other gate must use other gates
    /// gates do not maintain state so they can just be a series of static methods
    /// </summary>
    public static class Gates
    {
        public static bool NAnd(bool input1, bool input2) {
            return !(input1 && input2);
        }
        public static bool Not(bool input1)
        {
            return Gates.NAnd(input1, input1);
        }
        public static bool And(bool input1, bool input2)
        {
            return Gates.Not(Gates.NAnd(input1, input2));
        }
        public static bool[] And(bool[] input1, bool[] input2)
        {
            List<bool> bits = new List<bool>();
            for (int i = 0; i < input1.Length; i++)
            {
                bits.Add(Gates.And(input1[i], input2[i]));
            }
            return bits.ToArray();
        }
        public static bool Or(bool input1, bool input2)
        {
            var i1 = Gates.Not(input1);
            var i2 = Gates.Not(input2);
            return Gates.NAnd(i1, i2);
        }
        public static bool[] Or(bool[] input1, bool[] input2)
        {
            List<bool> bits = new List<bool>();
            for (int i = 0; i < input1.Length; i++)
            {
                bits.Add(Gates.Or(input1[i], input2[i]));
            }
            return bits.ToArray();
        }
        public static bool XOr(bool input1, bool input2) {
            var i1 = Gates.Not(input1);
            i1 = Gates.And(i1, input2);
            var i2 = Gates.Not(input2);
            i2 = Gates.And(input1, i2);
            return Gates.Or(i1, i2);
        
        }
        public static bool Mux(bool input1, bool input2, bool select){
            var i1 = Gates.And(input2, select);
            var notSelect = Gates.Not(select);
            var i2 = Gates.And(input1, notSelect);
            return Gates.Or(i1, i2);
        }
        public static bool[] Mux(bool[] input1, bool[] input2, bool select)
        {
            List<bool> bits = new List<bool>();
            for (int i = 0; i < input1.Length; i++)
            {
                bits.Add(Gates.Mux(input1[i], input2[i], select));
            }
            return bits.ToArray();
        }
 
        public static bool[] Mux4Way16(bool[] input1, bool[] input2,  bool[] input3,bool[] input4, bool[] sel)
        {
            if (sel.Length < 2)
                throw new Exception("Select address must be 2 bits.");
            var outpu1 = Gates.Mux(input1, input2, sel[1]);
            var output2 = Gates.Mux(input3, input4, sel[1]);
            var output3 = Gates.Mux(outpu1, output2, sel[0]);
            return output3;
        }

        public static bool[] Mux8Way16(bool[] input1, bool[] input2, bool[] input3, bool[] input4, bool[] input5, bool[] input6, bool[] input7, bool[] input8, bool[] sel)
        {
            if (sel.Length < 3)
                throw new Exception("Select address must be 3 bits.");

            var outpu1 = Gates.Mux4Way16(input1, input2,input3,input4, new bool[]{sel[1],sel[2]});
            var output2 = Gates.Mux4Way16(input5, input6, input7, input8, new bool[] { sel[1], sel[2] });
            var output3 = Gates.Mux(outpu1, output2, sel[0]);
            return output3;
        }



        public static Tuple<bool, bool> DMux(bool input, bool select) 
        {
            var notselect = Gates.Not(select);
            var a = Gates.And(input, notselect);
            var b = Gates.And(input, select);
            return new Tuple<bool,bool>(a,b);
        }
        public static Tuple<bool, bool, bool, bool> DMux4Way(bool input, bool[] sel) 
        {
            /*
             * 4-way demultiplexor.
             * {a,b,c,d} = {in,0,0,0} if sel==00
             *             {0,in,0,0} if sel==01
             *             {0,0,in,0} if sel==10
             *             {0,0,0,in} if sel==11
             */
            //why is this only working if i reverse the bit used in the select as what was used from the HDL answers
            var out1 = Gates.DMux(input, sel[0]);
            var out2 = Gates.DMux(out1.Item1, sel[1]);
            var out3 = Gates.DMux(out1.Item2, sel[1]);
            return new Tuple<bool, bool, bool, bool>(out2.Item1,out2.Item2,out3.Item1,out3.Item2);
        }
        public static Tuple<bool, bool, bool, bool, bool, bool, bool, Tuple<bool>> DMux8Way(bool input, bool[] sel)
        {
            // Just like Mux or DMux4Way, break apart the problem by
            //// looking at part of sel
            //DMux4Way(in=in, sel=sel[1..2], a=t1, b=t2, c=t3, d=t4);

            //// Then slam out your value, expecting that
            //// only one of these 4 DMux will actualy contain in.
            //DMux(in=t1, sel=sel[0], a=a, b=b);
            //DMux(in=t2, sel=sel[0], a=c, b=d);
            //DMux(in=t3, sel=sel[0], a=e, b=f);
            //DMux(in=t4, sel=sel[0], a=g, b=h);
            var output1 = Gates.DMux4Way(input, new bool[] { sel[0], sel[1] });

            var output2 = Gates.DMux(output1.Item1,sel[2]);
            var output3 = Gates.DMux(output1.Item2,sel[2]);
            var output4 = Gates.DMux(output1.Item3, sel[2]);
            var output5 = Gates.DMux(output1.Item4,sel[2]);

            return new Tuple<bool, bool, bool, bool, bool, bool, bool, Tuple<bool>>(output2.Item1, output2.Item2,
                output3.Item1, output3.Item2,
                output4.Item1, output4.Item2,
                output5.Item1, new Tuple<bool>(output5.Item2) );



            //this is not working, may be affected by the fact that dmux4way is no working unles i reverse the select bits
            var out1 = Gates.DMux(input, sel[2]); 
            var out2 = Gates.DMux4Way(out1.Item1, new bool[]{sel[0],sel[1]});
            var out3 = Gates.DMux4Way(out1.Item2, new bool[] { sel[0], sel[1] });
           // return new Tuple<bool, bool, bool, bool, bool, bool, bool, bool>(out2.Item1,out2.Item2,out2.Item3,out2.Item4,out3.Item1,out3.Item2,out3.Item3,out3.Item4);
        }

        public static bool[] Not(bool[] input) 
        {
            List<bool> bits = new List<bool>();
            for (int i = 0; i < input.Length; i++)
            {
                bits.Add(Gates.Not(input[i]));
            }
            return bits.ToArray();
        }
 
    }


}
