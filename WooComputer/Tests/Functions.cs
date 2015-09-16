using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class Functions
    {
        public static void CompareBitArray(bool[] source, bool[] compareTo)
        {
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], compareTo[i]);
            }
        }
        public static bool[] GetBitArray(int x) {
            BitArray b = new BitArray(new int[] { x });
            var bools = b.Cast<bool>();
            //the visual representation is the opposite of how they bits actually go in the array so reverse things
            return bools.Reverse().ToArray();
            
           // bool[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
        }
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
