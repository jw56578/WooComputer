using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    public static class Operators
    {
        public static Tuple<bool, bool> HalfAdd(bool input1, bool input2)
        {
            var sum = Gates.XOr(input1, input2);
            var carry = Gates.And(input1, input2);
            return new Tuple<bool, bool>(sum, carry);
        }
        public static Tuple<bool, bool> FullAdd(bool input1, bool input2, bool carry)
        {
            var add1 = Operators.HalfAdd(input1, input2);
            var add2 = Operators.HalfAdd(add1.Item1, carry);
            var or = Gates.Or(add1.Item2, add2.Item2);
            return new Tuple<bool, bool>(add2.Item1, or);

        }
        public static bool[] Add(bool[] input1, bool[] input2)
        { 
            List<bool> sumAsArray = new List<bool>();
            bool carry = false;
            bool sum = false;
            var result =  Operators.HalfAdd(input1[input1.Length - 1],input2[input2.Length - 1]);
            sum = result.Item1;
            carry = result.Item2;
            sumAsArray.Add(sum);
            for (int i = input1.Length - 2; i >= 0; i--)
            {
                result =  Operators.FullAdd(input1[i],input2[i],carry);
                sum = result.Item1;
                carry = result.Item2;
                sumAsArray.Add(sum);
            }
            sumAsArray.Reverse();
            return sumAsArray.ToArray();
        }
    }
}
