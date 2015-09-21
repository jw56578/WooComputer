using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer
{
    public static class Functions
    {
        public static bool[] GetBitArrayFromInteger(int x, int width)
        {
            string s = Convert.ToString(x, 2); //Convert to binary in a string

            bool[] bits = s.PadLeft(width, '0') // Add 0's from left
                .Select(c => c.ToString() == "0" ? false : true) // convert each char to int
                         .ToArray(); // Convert IEnumerable from select to Array
            return bits;
        }
        public static bool[] GetBitArrayFromString(string input)
        {
            List<bool> bits = new List<bool>();
            foreach (var c in input.ToCharArray())
            {
                if (c == '0')
                    bits.Add(false);
                else
                    bits.Add(true);
            }
            return bits.ToArray();

        }
        public static string GetStringFromBitArray(bool[] input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in input)
            {
                sb.Append(c.ToString());
            }
            return sb.ToString();

        }
        public static int GetIntegerFromBitArray(bool[] input) {
            var result = new int[1];
            var binary = new BitArray(input.Reverse().ToArray());
            binary.CopyTo(result, 0);
            return result[0];
        }
    }
}
