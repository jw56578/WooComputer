using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooComputer.Chips;
using System.Diagnostics;
namespace Tests
{
    [TestClass]
    public partial class MainMemory
    {
        [TestMethod]
        public void CanStoreAndRetrieve()
        {
            var memory = new WooComputer.Chips.Memory(16);


            //don't load, everything should start at false's
            var output = memory.Cycle(Functions.GetBitArrayFromInteger(1, 16), false, Functions.GetBitArrayFromInteger(1, 15));
            Functions.CompareBitArray(output, new bool[16]);

            output = memory.Cycle(Functions.GetBitArrayFromInteger(1, 16), true, Functions.GetBitArrayFromInteger(0, 15));
            Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(1, 16));



            //how is this soo messed up, loading 2 different locations and then retreiving the seperate locations
            //somehow all output is of the last value added to the memory
            var valueInMemoryLocation0 = Functions.GetBitArrayFromInteger(5, 16);
            var valueInMemoryLocation1 = Functions.GetBitArrayFromInteger(4, 16);


            var location0 = new bool[15];
            var location1 = Functions.GetBitArrayFromInteger(1, 15);



            //load memory location 0
            var memory0Ouput = memory.Cycle(valueInMemoryLocation0, true, location0);
            //load memory location 1
            var memory1Output = memory.Cycle(valueInMemoryLocation1, true, location1);
            //THE OUTPUTS ABOVE NOW HAVE THE CORRECT VALUE, BUT WHEN I CYCLE AGAIN WITH LOAD FALSE - I SHOULD GET THE SAME OUTPUT BUT I DO NOT!!!!
            //THEY BOTH HAVE 4 IN THEM

            memory0Ouput = memory.Cycle(new bool[16], false, location0);
            memory1Output = memory.Cycle(new bool[16], false, location1);

            Functions.CompareBitArray(memory0Ouput, valueInMemoryLocation0);
            Functions.CompareBitArray(memory1Output, valueInMemoryLocation1);









       


            for (int i = 4995; i < 5000; i++) 
            {
                var sw = new Stopwatch();
                sw.Start();
                output = memory.Cycle(Functions.GetBitArrayFromInteger(i, 16), true, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i+ 2, 16), false, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 2, 16), true, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i+ 2, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 10, 16), false, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i + 2, 16));

                sw.Stop();
                Debug.WriteLine(sw.Elapsed.Milliseconds);

            }
            for (int i = 5995; i < 6000; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                output = memory.Cycle(Functions.GetBitArrayFromInteger(i, 16), true, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 2, 16), false, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 2, 16), true, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i + 2, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 10, 16), false, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i + 2, 16));
                sw.Stop();
                Debug.WriteLine(sw.Elapsed.Milliseconds);

            }
            for (int i = 6995; i < 7000; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                output = memory.Cycle(Functions.GetBitArrayFromInteger(i, 16), true, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 2, 16), false, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 2, 16), true, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i + 2, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 10, 16), false, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i + 2, 16));
                sw.Stop();
                Debug.WriteLine(sw.Elapsed.Milliseconds);

            }
            for (int i = 9995; i < 10000; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                output = memory.Cycle(Functions.GetBitArrayFromInteger(i, 16), true, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 2, 16), false, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 2, 16), true, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i + 2, 16));

                output = memory.Cycle(Functions.GetBitArrayFromInteger(i + 10, 16), false, Functions.GetBitArrayFromInteger(i, 15));
                Functions.CompareBitArray(output, Functions.GetBitArrayFromInteger(i + 2, 16));
                sw.Stop();
                Debug.WriteLine(sw.Elapsed.Milliseconds);

            }



        }
    }
}
