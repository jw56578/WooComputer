using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooComputer.Chips;
namespace Tests
{

    public partial class Memory
    {


        [TestMethod]
        public void RAM16kWorks()
        {
            Ram16K r = new Ram16K(16);
            var input = new bool[] { false, false, false, false, false, false, false, false };


            //no load, the value should just be the same, all false
            TestRam16K(r, Functions.GetBitArrayFromInteger(0, 16), Functions.GetBitArrayFromInteger(0, 16), false, Functions.GetBitArrayFromInteger(0, 16));
            TestRam16K(r, Functions.GetBitArrayFromInteger(0, 16), Functions.GetBitArrayFromInteger(33, 16), false, Functions.GetBitArrayFromInteger(0, 16));
            TestRam16K(r, Functions.GetBitArrayFromInteger(0, 16), Functions.GetBitArrayFromInteger(55, 16), false, Functions.GetBitArrayFromInteger(0, 16));

            for (int i = 0; i < 50; i++) 
            {
                TestRam16K(r, Functions.GetBitArrayFromInteger(i, 16), Functions.GetBitArrayFromInteger(i, 16), false, Functions.GetBitArrayFromInteger(0, 16));
            }
            for (int i = 0; i < 50; i++)
            {
                TestRam16K(r, Functions.GetBitArrayFromInteger(i, 16), Functions.GetBitArrayFromInteger(i, 16), true, Functions.GetBitArrayFromInteger(i, 16));
                TestRam16K(r, Functions.GetBitArrayFromInteger(i, 16), Functions.GetBitArrayFromInteger(i + 3, 16), false, Functions.GetBitArrayFromInteger(i, 16));
            }

        }

        void TestRam16K(Ram16K r, bool[] address, bool[] input, bool load, bool[] compare)
        {
            var output = r.Cycle(input, load, address);
            CompareBitArray(output, compare);
        }
    }
}
