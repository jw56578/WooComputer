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
        /// Make sure that jumping works. If a jump is valid then it should change the program counter to whatever is in the A register
        /// </summary>
        [TestMethod]
        public void CanJumpEqualsZero()
        {
            var analyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var cpu = new WooComputer.Chips.CPU16Bit(analyzer);
            var memory = new WooComputer.Chips.Memory(16);

            /*
             * load a calculation that results in whatever jump you want
             * JEQ  if computation = 0
             * load A register with the address of where you want to jump to
             */

            //set A = memory location 16
            var output = cpu.Cycle(Functions.GetBitArrayFromInteger(0, 16), Functions.GetBitArrayFromInteger(16, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(16, 16));

            // set D = 0, and jmp if this results in zero, which it will of course
            //1110101010010010
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(60050, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(16, 16));
            Assert.IsFalse(output.Item2);
            //the program counter output should now be 16 which was what was in register A and should be used as the jump should be done
            Functions.CompareBitArray(output.Item4, Functions.GetBitArrayFromInteger(16, 15));

        }
        [TestMethod]
        public void CanJumpGreaterThanZero()
        {
            var analyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var cpu = new WooComputer.Chips.CPU16Bit(analyzer);
            var memory = new WooComputer.Chips.Memory(16);

            /*
             * load a calculation that results in whatever jump you want
             * JEQ  if computation = 0
             * load A register with the address of where you want to jump to
             */

            //set A = memory location 16
            var output = cpu.Cycle(Functions.GetBitArrayFromInteger(0, 16), Functions.GetBitArrayFromInteger(16, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(16, 16));

            // set D = 1, and jmp if this results in greater than zero, 1 > 0 duh
            //1110111111010001
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(61393, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(16, 16));
            Assert.IsFalse(output.Item2);
            //the program counter output should now be 16 which was what was in register A and should be used as the jump should be done
            Functions.CompareBitArray(output.Item4, Functions.GetBitArrayFromInteger(16, 15));

        }
        [TestMethod]
        public void CanJumpLessThanZero()
        {
            var analyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var cpu = new WooComputer.Chips.CPU16Bit(analyzer);
            var memory = new WooComputer.Chips.Memory(16);

            /*
             * load a calculation that results in whatever jump you want
             * JEQ  if computation = 0
             * load A register with the address of where you want to jump to
             */

            //set A = memory location 16
            var output = cpu.Cycle(Functions.GetBitArrayFromInteger(0, 16), Functions.GetBitArrayFromInteger(355, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(355, 16));

            // set D = -1, and jmp if this results in less than zero. -1 < 0 duh
            //1110111010010100
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(61076, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(355, 16));
            Assert.IsFalse(output.Item2);
            //the program counter output should now be 16 which was what was in register A and should be used as the jump should be done
            Functions.CompareBitArray(output.Item4, Functions.GetBitArrayFromInteger(355, 15));

        }
    }
}
