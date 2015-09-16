using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooComputer.Chips;
namespace Tests
{

    public partial class Memory
    {

        //void TestRAM64Address(Ram64 r,bool[] addresss, bool load, bool[] compare)
        //{
        //    TestRam64(r, addresss, new bool[] { false, false, false, false, false, false, false, false }, false, compare);
        //    TestRam64(r, addresss, new bool[] { true, true, false, false, true, false, true, true }, false, compare);
        //    TestRam64(r, addresss, new bool[] { false, true, false, false, true, false, true, true }, false, compare);
        
        //}
        [TestMethod]
        public void RAM64Works()
        {
            Ram64 r = new Ram64(8);
            var input = new bool[] { false, false, false, false, false, false, false, false };


            //no load, the value should just be the same, all false
            TestRam64(r, new bool[] { false, false, false, false, false, false }, input, false,input);
            TestRam64(r, new bool[] { false, false, false, false, false, false }, new bool[] { true, true, false, false, true, false, true, true }, false, input);
            TestRam64(r, new bool[] { false, false, false, false, false, false }, new bool[] { false, true, false, false, true, false, true, true }, false, input);

            TestRam64(r, new bool[] { false, false, false, false, false, true }, input, false, input);
            TestRam64(r, new bool[] { false, false, false, false, false, true }, new bool[] { true, true, false, false, true, false, true, true }, false, input);
            TestRam64(r, new bool[] { false, false, false, false, false, true }, new bool[] { false, true, false, false, true, false, true, true }, false, input);

            TestRam64(r, new bool[] { false, false, false, false, true, false }, input, false, input);
            TestRam64(r, new bool[] { false, false, false, false, true, false }, new bool[] { true, true, false, false, true, false, true, true }, false, input);
            TestRam64(r, new bool[] { false, false, false, false, true, false }, new bool[] { false, true, false, false, true, false, true, true }, false, input);

            TestRam64(r, new bool[] { true, true, true, true, true, true }, input, false, input);
            TestRam64(r, new bool[] { true, true, true, true, true, true }, new bool[] { true, true, false, false, true, false, true, true }, false, input);
            TestRam64(r, new bool[] { true, true, true, true, true, true }, new bool[] { false, true, false, false, true, false, true, true }, false, input);


            TestRam64(r, new bool[] { true, true, false, true, true, true }, input, false, input);
            TestRam64(r, new bool[] { true, true, false, true, true, true }, new bool[] { true, true, false, false, true, false, true, true }, false, input);
            TestRam64(r, new bool[] { true, true, false, true, true, true }, new bool[] { false, true, false, false, true, false, true, true }, false, input);


           /// TestRAM64Address(r, new bool[] { true, true, false, true, true, true }, false, input);
            //load, the value should be the same as input
            TestRam64(r, new bool[] { false, false, false, false, false, false }, input, true, input);
            TestRam64(r, new bool[] { false, false, false, false, false, false }, new bool[] { true, true, false, false, true, false, true, true }, true, new bool[] { true, true, false, false, true, false, true, true });
            TestRam64(r, new bool[] { false, false, false, false, false, false }, new bool[] { false, true, false, false, true, false, true, true }, true, new bool[] { false, true, false, false, true, false, true, true });

            TestRam64(r, new bool[] { false, false, false, false, false, true }, input, false, input);
            TestRam64(r, new bool[] { false, false, false, false, false, true }, new bool[] { true, true, false, false, true, false, true, true }, true, new bool[] { true, true, false, false, true, false, true, true });
            TestRam64(r, new bool[] { false, false, false, false, false, true }, new bool[] { false, true, false, false, true, false, true, true }, true, new bool[] { false, true, false, false, true, false, true, true });

            TestRam64(r, new bool[] { false, false, false, false, true, false }, input, false, input);
            TestRam64(r, new bool[] { false, false, false, false, true, false }, new bool[] { true, true, false, false, true, false, true, true }, true, new bool[] { true, true, false, false, true, false, true, true });
            TestRam64(r, new bool[] { false, false, false, false, true, false }, new bool[] { false, true, false, false, true, false, true, true }, true, new bool[] { false, true, false, false, true, false, true, true });

            TestRam64(r, new bool[] { true, true, true, true, true, true }, input, false, input);
            TestRam64(r, new bool[] { true, true, true, true, true, true }, new bool[] { true, true, false, false, true, false, true, true }, true, new bool[] { true, true, false, false, true, false, true, true });
            TestRam64(r, new bool[] { true, true, true, true, true, true }, new bool[] { false, true, false, false, true, false, true, true }, true, new bool[] { false, true, false, false, true, false, true, true });


            TestRam64(r, new bool[] { true, true, false, true, true, true }, input, false, input);
            TestRam64(r, new bool[] { true, true, false, true, true, true }, new bool[] { true, true, false, false, true, false, true, true }, true, new bool[] { true, true, false, false, true, false, true, true });
            TestRam64(r, new bool[] { true, true, false, true, true, true }, new bool[] { false, true, false, false, true, false, true, true }, true, new bool[] { false, true, false, false, true, false, true, true });


            //no load, the value should be what it was previously

            TestRam64(r, new bool[] { false, false, false, false, false, false }, new bool[] { false, true, false, false, true, false, true, true }, false, new bool[] { false, true, false, false, true, false, true, true });
            TestRam64(r, new bool[] { false, false, false, false, false, true }, new bool[] { false, true, false, false, true, false, true, true }, false, new bool[] { false, true, false, false, true, false, true, true });
            TestRam64(r, new bool[] { false, false, false, false, true, false }, new bool[] { false, true, false, false, true, false, true, true }, false, new bool[] { false, true, false, false, true, false, true, true });
            TestRam64(r, new bool[] { true, true, true, true, true, true }, new bool[] { false, true, false, false, true, false, true, true }, false, new bool[] { false, true, false, false, true, false, true, true });
            TestRam64(r, new bool[] { true, true, false, true, true, true }, new bool[] { false, true, false, false, true, false, true, true }, false, new bool[] { false, true, false, false, true, false, true, true });


        }

        void TestRam64(Ram64 r, bool[] address, bool[] input, bool load, bool[] compare)
        {
            var output = r.Cycle(input, load, address);
            CompareBitArray(output, compare);
        }
    }
}
