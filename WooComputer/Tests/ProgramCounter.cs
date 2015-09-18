using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooComputer.Chips;
using System.Collections;
using WooComputer;

namespace Tests
{
    [TestClass]
    public class ProgramCounter
    {
        [TestMethod]
        public void CanIncrementThenResetToZero()
        {

            WooComputer.Chips.ProgramCounter pc = new WooComputer.Chips.ProgramCounter(16);

            for (int i = 0; i < 100; i++)
            {
                var output = pc.Cycle(new bool[16],false,true,false);
                Functions.CompareBitArray(Functions.GetBitArrayFromInteger(i + 1, 16), output);
            }
            var resetOutput = pc.Cycle(new bool[16],false,false,true);
            Functions.CompareBitArray(Functions.GetBitArrayFromInteger(0, 16), resetOutput);


        }

        [TestMethod]
        public void ResetWorks()
        {
            WooComputer.Chips.ProgramCounter pc = new WooComputer.Chips.ProgramCounter(8);
            //start at zero
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, false, false), new bool[] { false, false, false, false, false, false, false, false });
            
            //increment 1
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, false, false, true });
            //increment 1
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, false, true, false });
            //increment 1
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, false, true, true });
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, true, false, false });
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, true, false, true });
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, true, true, false });
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, true, true, true });

            //should output the last output
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
               false, false, false), new bool[] { false, false, false, false, false, true, true, true });
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
             false, false, false), new bool[] { false, false, false, false, false, true, true, true });
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
             false, false, false), new bool[] { false, false, false, false, false, true, true, true });





            //set specific instruction
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, true, true, true, true, true },
               true, false, false), new bool[] { false, false, false, true, true, true, true, true });

            //increment should be one more thatn the previous input instruction
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, true, true, true, true, true },
               false, true, false), new bool[] { false, false, true, false, false, false, false, false });

            //increment 
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, true, true, true, true, true },
               false, true, false), new bool[] { false, false, true, false, false, false, false, true });

            //reset
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, true, true, true, true, true },
               false, false,true), new bool[] { false, false, false, false, false, false, false, false });


            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
               false, true, false), new bool[] { false, false, false, false, false, false, false, true });
            //increment 1
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, false, true, false });
            //increment 1
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, false, true, true });
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, true, false, false });
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, true, false, true });
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, true, true, false });
            CompareBitArray(pc.Cycle(new bool[] { false, false, false, false, false, false, false, false },
                false, true, false), new bool[] { false, false, false, false, false, true, true, true });


        }

        void CompareBitArray(bool[] source, bool[] compareTo)
        {
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], compareTo[i]);
            }
        }

    }
}
