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
        public static bool Or(bool input1, bool input2)
        {
            var i1 = Gates.Not(input1);
            var i2 = Gates.Not(input2);
            return Gates.NAnd(i1, i2);
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
        public static Tuple<bool, bool> DMux(bool input, bool select) 
        {
            var notselect = Gates.Not(select);
            var a = Gates.And(input, notselect);
            var b = Gates.And(input, select);
            return new Tuple<bool,bool>(a,b);
        }
    }


}
