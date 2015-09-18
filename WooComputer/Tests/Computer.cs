using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public  class Computer
    {
        [TestMethod]
        public void CanCycleInstructionsToAdd()
        {


            List<string> instructions = new List<string>()
            { 
                "0000000000000000",
                "1111110000010000",
                "0000000000000001",
                "1111000010010000",
                "0000000000000010",
                "1110001100001000"
            };
            //0000000000000000  - @0  set A register to 0, address memory location 0
            //1111110000010000  - D=M make the d register have the value of whatever is in the memory location at A (which is the zero location)
            //0000000000000001  - @1 set A register to 1, M will now have the value of whatever is in memory at location 1
            //1111000010010000  - D= D+M add what is in the d register to whatever is in memory at location A
            //0000000000000010  - @2 set A register to 2
            //1110001100001000  - M=D put whatever is in D into memory which is pointing to address 2
            CycleAddInstructions(instructions,5,4);

        }
        public void CycleAddInstructions(List<string> instructions, int input1,int  input2)
        {
            var memory = new WooComputer.Chips.Memory(16);

            var valueInMemoryLocation0 = Functions.GetBitArrayFromInteger(input1, 16);
            var valueInMemoryLocation1 = Functions.GetBitArrayFromInteger(input2, 16);

            memory.Cycle(valueInMemoryLocation0, true, new bool[15]);
            memory.Cycle(valueInMemoryLocation1, true, Functions.GetBitArrayFromInteger(1, 15));

            Functions.CompareBitArray(memory.Cycle(new bool[16], false, new bool[15]), valueInMemoryLocation0);
            Functions.CompareBitArray(memory.Cycle(new bool[16], false, Functions.GetBitArrayFromInteger(1, 15)), valueInMemoryLocation1);
            var value = CycleInstructions(memory,instructions);
            var sum = input1 + input2;
            Functions.CompareBitArray(value, Functions.GetBitArrayFromInteger(sum, 16));
        }
        public bool[] CycleInstructions(WooComputer.Chips.Memory memory, List<string> instructions)
        {
            var analyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var cpu = new WooComputer.Chips.CPU16Bit(analyzer);
          
            Tuple<bool[],bool,bool[],bool[]> output = null;
            bool[] memoryValue = new bool[16];
            for (int i = 0; i < instructions.Count; i++) {
                if (output != null)
                    memoryValue = memory.Cycle(output.Item1, output.Item2, output.Item3);
                output = cpu.Cycle(memoryValue, Functions.GetBitArrayFromString(instructions[i]), false);
            }
            //is this necessary?
            memoryValue = memory.Cycle(output.Item1, output.Item2, output.Item3);
            return memoryValue;
            

        }
    }
}
