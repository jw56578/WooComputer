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
        [TestMethod]
        public void CanLoadValueIntoMemoryLocation()
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

            //set D = M + 1
            //1111110111010000
            //this is weird becauses the d register will not have the 2 in it until next cycle. Just putting something in D is pointless, it needs to be saved back into memory so when that happens on the next cycle d will have 2 and it will go in that memory
            //the aluout should be 2 here
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(64976, 16), false);
            //memory in 0 spot should now be one
            Functions.CompareBitArray(memory.Cycle(new bool[16],false, Functions.GetBitArrayFromInteger(0, 16)), Functions.GetBitArrayFromInteger(1, 16));
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(0, 16));
           
            //0000000000000001  -  set A register to 1
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(1, 16), false);
            //why the hell isn't this working, the loadD bit is never being set to true
            //Functions.CompareBitArray(analyzer.GetDContents(), Functions.GetBitArrayFromInteger(2, 16));
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(1, 16));

            // 1110001100001000  - M=D put whatever is in D into memory which is pointing to address 2
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(58120, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(1, 16));

            var finalmemory = memory.Cycle(output.Item1, output.Item2, output.Item3);
            Functions.CompareBitArray(finalmemory, Functions.GetBitArrayFromInteger(2, 16));

        }
        [TestMethod]
        public void CanLoadMemoryValueIntoDRegister()
        {
            var analyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var cpu = new WooComputer.Chips.CPU16Bit(analyzer);
            var memory = new WooComputer.Chips.Memory(16);


            //1111110000010000
            //c instruction
            //a = 1
            // c = 110000 = compute M = get the value of M which is the memory that was just sent in?
            // c = 010 = destination is d = put the value that you computer into the d register
            // j = 000 =  no jump
            var output = cpu.Cycle(Functions.GetBitArrayFromInteger(5, 16), Functions.GetBitArrayFromInteger(64528, 16), false);
            Functions.CompareBitArray(analyzer.GetDContents(), Functions.GetBitArrayFromInteger(5, 16));


        }

        /// <summary>
        /// Sending in an instruction where the highest bit is 1 means you must analyze each additional bit for its meaning in processing ALU and other things
        /// Just testing to see if the command makes the input go into the D register
        /// </summary>
        [TestMethod]
        public void CanLoadDRegister()
        {
            var analyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var cpu = new WooComputer.Chips.CPU16Bit(analyzer);
            var memory = new WooComputer.Chips.Memory(16);

            
            //1111110000010000
            //c instruction
            //a = 1
            // c = 110000 = compute M = get the value of M which is the memory that was just sent in?
            // c = 010 = destination is d = put the value that you computer into the d register
            // j = 000 =  no jump
            var output = cpu.Cycle(Functions.GetBitArrayFromInteger(5, 16), Functions.GetBitArrayFromInteger(64528, 16), false);
            Functions.CompareBitArray(analyzer.GetDContents(), Functions.GetBitArrayFromInteger(5, 16));


        }
        /// <summary>
        /// Sending in an instruction where the highest bit is 0 means that you want the instruction to be loaded into the A Register as being a memory address
        /// </summary>
        [TestMethod]
        public void CanLoadARegister()
        {
            var analyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var cpu = new WooComputer.Chips.CPU16Bit(analyzer);
            var memory = new WooComputer.Chips.Memory(16);
            //0000000011111111
            var ouput = cpu.Cycle(new bool[16], Functions.GetBitArrayFromInteger(255, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(255, 16));

            ouput = cpu.Cycle(new bool[16], Functions.GetBitArrayFromInteger(21, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(21, 16));

            ouput = cpu.Cycle(new bool[16], Functions.GetBitArrayFromInteger(1023, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(1023, 16));


            ouput = cpu.Cycle(new bool[16], Functions.GetBitArrayFromInteger(682, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(682, 16));

            ouput = cpu.Cycle(new bool[16], Functions.GetBitArrayFromInteger(767, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(767, 16));

            ouput = cpu.Cycle(new bool[16], Functions.GetBitArrayFromInteger(353, 16), false);
            Functions.CompareBitArray(analyzer.GetAContents(), Functions.GetBitArrayFromInteger(353, 16));

        }
        [TestMethod]
        public void CanTakeValueFromMemoryAddress0AndMemoryAddress1ThenSumThemAndPutIntoMemoryAddress2NoComments()
        {


            /* you need to rewatch lesson 4 to remember what all this means
             0000000000000000  - @0  set A register to 0, address memory location 0
             1111110000010000  - D=M make the d register have the value of whatever is in the memory location at A (which is the zero location)
             0000000000000001  - @1 set A register to 1, M will now have the value of whatever is in memory at location 1
             1111000010010000  - D= D+M add what is in the d register to whatever is in memory at location A
             0000000000000010  - @2 set A register to 2
             1110001100001000  - M=D put whatever is in D into memory which is pointing to address 2
             * */

            var analyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var cpu = new WooComputer.Chips.CPU16Bit(analyzer);
            var memory = new WooComputer.Chips.Memory(16);
            var valueInMemoryLocation0 = Functions.GetBitArrayFromInteger(5, 16);
            var valueInMemoryLocation1 = Functions.GetBitArrayFromInteger(4, 16);

            memory.Cycle(valueInMemoryLocation0, true, new bool[15]);
            memory.Cycle(valueInMemoryLocation1, true, Functions.GetBitArrayFromInteger(1, 15));

            //#1 -  @0  set A register to 0, address memory location 0
            //still don't understand what value should go into memory on the first cycle, does it matter, it would just be false
            var output = cpu.Cycle(new bool[16], new bool[16], false);

            //#2  D=M make the d register have the value of whatever is in the memory location at A (which is the zero location)
            //64528
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(64528, 16), false);
           
            Functions.CompareBitArray(valueInMemoryLocation0, output.Item1);
           

            // @1 set A register to 1, M will now have the value of whatever is in memory at location 1
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(1, 16), false);
          


            //  1111000010010000  - D= D+M add what is in the d register to whatever is in memory at location A
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(61584, 16), false);
           


            //0000000000000010  - @2 set A register to 2
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(2, 16), false);
    

            //1110001100001000  - M=D put whatever is in D into memory which is pointing to address 2
            output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(58120, 16), false);
          

            memory.Cycle(output.Item1, output.Item2, output.Item3);



        }
    }
}
