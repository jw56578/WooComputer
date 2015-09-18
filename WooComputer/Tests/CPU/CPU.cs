using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public partial class CPU
    {
        [TestMethod]
        public void ProgramCounterOutputWorks()
        {
            var cpu = new WooComputer.Chips.CPU16Bit();
            var memory = new WooComputer.Chips.Memory(16);

            for(int i = 0; i < 100 ; i++){
                var output = cpu.Cycle(new bool[16], new bool[16], false);
                 Functions.CompareBitArray(Functions.GetBitArrayFromInteger(i+1, 16), output.Item4);
            }
            var resetOutput = cpu.Cycle(new bool[16], new bool[16], true);
            Functions.CompareBitArray(Functions.GetBitArrayFromInteger(0, 16), resetOutput.Item4);



        }
        [TestMethod]
        public void CanTakeValueFromMemoryAddress0AndMemoryAddress1ThenSumThemAndPutIntoMemoryAddress2() {

            
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

            Functions.CompareBitArray(memory.Cycle(new bool[16], false, new bool[15]), valueInMemoryLocation0);
            Functions.CompareBitArray(memory.Cycle(new bool[16], false, Functions.GetBitArrayFromInteger(1, 15)), valueInMemoryLocation1);






            //I STILL DON'T GET WHERE MEMORY VALUE COMES FROM - WHAT MEMORY ADDRESS ARE YOU SUPPOSE TO PULL THE VALUE FROM AND PUT INTO THE CPU


            //this is the trick, the CPU outputs the memory address which goes into the memory and then the value at that address is pulled out and sent back into the cpu
            //but who controls this, and again what address is used on first cycle











            //#1 -  @0  set A register to 0, address memory location 0
            //this is the first cycle so the Program Counter would be at zero, so you send in the value that exists in memory location zero which in our case is 5 because that is what we specifically put in there from line above
            var output = cpu.Cycle(valueInMemoryLocation0, new bool[16], false);
            //okay well we put the value in from memory but does that affect what comes out from the ALU ???
            //at this point it is not coming out from the ALU/cpu output, is that bad???
            //it is coming out on the next cycle - is that okay?
           Functions.CompareBitArray(new bool[16], output.Item1);
            //write memory should be false as this is a instruction to get memory not write to it
           Assert.IsFalse(output.Item2);
            //the program counter should now be 1 since it cycled once so 1 +0 = 1;
           Functions.CompareBitArray(Functions.GetBitArrayFromInteger(1,16), output.Item4);


           //#2  D=M make the d register have the value of whatever is in the memory location at A (which is the zero location)
           //64528
           output = cpu.Cycle(memory.Cycle(output.Item1,output.Item2,output.Item3), Functions.GetBitArrayFromInteger(64528, 16), false);
            //the value that was input from the previous cycle is now being outputted, is that how it should be?????
           Functions.CompareBitArray(valueInMemoryLocation0, output.Item1);
           Assert.IsFalse(output.Item2);
           
            //the program counter should now be at 2 since it has been run twice
           Functions.CompareBitArray(Functions.GetBitArrayFromInteger(2, 16), output.Item4);



            // @1 set A register to 1, M will now have the value of whatever is in memory at location 1
           output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(1, 16), false);
           //the program counter should now be at 3
           Functions.CompareBitArray(Functions.GetBitArrayFromInteger(3, 16), output.Item4);


           //  1111000010010000  - D= D+M add what is in the d register to whatever is in memory at location A
           output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(61584, 16), false);
           Functions.CompareBitArray(Functions.GetBitArrayFromInteger(4, 16), output.Item4);


            //0000000000000010  - @2 set A register to 2
           output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(2, 16), false);
           Functions.CompareBitArray(Functions.GetBitArrayFromInteger(5, 16), output.Item4);

            //1110001100001000  - M=D put whatever is in D into memory which is pointing to address 2
           output = cpu.Cycle(memory.Cycle(output.Item1, output.Item2, output.Item3), Functions.GetBitArrayFromInteger(58120, 16), false);
           Functions.CompareBitArray(Functions.GetBitArrayFromInteger(6, 16), output.Item4);

           memory.Cycle(output.Item1, output.Item2, output.Item3);

            //something should be 0000000000001001

            //fuck the output never has a value, its always ZERO
            //Functions.CompareBitArray(analyzer.GetDContents(), valueInMemoryLocation1);

        
        }
     
    }
}
