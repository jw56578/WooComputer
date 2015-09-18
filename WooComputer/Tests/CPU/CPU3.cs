using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{

    public partial class CPU
    {
        /// <summary>
        /// Use a loop to cycle through the same instructions of adding one to the register
        /// </summary>
        [TestMethod]
        public void CanAccumulateTo100()
        {
            var analyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var cpu = new WooComputer.Chips.CPU16Bit(analyzer);
            var memory = new WooComputer.Chips.Memory(16);


            //set A = memory location 0
            var output = cpu.Cycle(Functions.GetBitArrayFromInteger(0, 16), Functions.GetBitArrayFromInteger(0, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(0, 16));

            // set M = 1
            //1110111111001000
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(61384, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(0, 16));
            Functions.CompareBitArray(output.Item1, Functions.GetBitArrayFromInteger(1, 16));
            Assert.IsTrue(output.Item2);

            //set D = M + 1
            //1111110111010000
            //the aluout should be 2 here
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(64976, 16), false);
            //memory in 0 spot should now be 1
            Functions.CompareBitArray(memory.Cycle(new bool[16], false, Functions.GetBitArrayFromInteger(0, 16)), Functions.GetBitArrayFromInteger(1, 16));
            Functions.CompareBitArray(analyzer.GetDContents(), Functions.GetBitArrayFromInteger(2, 16));
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(0, 16));


            //set D = D + 1
            //1110011111010000
            for (int i = 3; i < 100; i++)
            {
                output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(59344, 16), false);
                Assert.IsFalse(output.Item2);
                Functions.CompareBitArray(output.Item1, Functions.GetBitArrayFromInteger(i, 16));
                Functions.CompareBitArray(analyzer.GetDContents(), Functions.GetBitArrayFromInteger(i, 16));

            }


        }
        [TestMethod]
        public void CanAccumulateTo1000()
        {
            var analyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var cpu = new WooComputer.Chips.CPU16Bit(analyzer);
            var memory = new WooComputer.Chips.Memory(16);


            //set A = memory location 0
            var output = cpu.Cycle(Functions.GetBitArrayFromInteger(0, 16), Functions.GetBitArrayFromInteger(0, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(0, 16));

            // set M = 1
            //1110111111001000
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(61384, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(0, 16));
            Functions.CompareBitArray(output.Item1, Functions.GetBitArrayFromInteger(1, 16));
            Assert.IsTrue(output.Item2);

            //set D = M + 1
            //1111110111010000
            //the aluout should be 2 here
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(64976, 16), false);
            //memory in 0 spot should now be 1
            Functions.CompareBitArray(memory.Cycle(new bool[16], false, Functions.GetBitArrayFromInteger(0, 16)), Functions.GetBitArrayFromInteger(1, 16));
            Functions.CompareBitArray(analyzer.GetDContents(), Functions.GetBitArrayFromInteger(2, 16));
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(0, 16));


            //set D = D + 1
            //1110011111010000
            for (int i = 3; i < 1000; i++)
            {
                output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(59344, 16), false);
                Functions.CompareBitArray(output.Item1, Functions.GetBitArrayFromInteger(i, 16));
                Functions.CompareBitArray(analyzer.GetDContents(), Functions.GetBitArrayFromInteger(i, 16));

            }


        }
    }
}
