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
    }
}
