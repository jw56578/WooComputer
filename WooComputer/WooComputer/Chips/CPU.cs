using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{

    /**
     * The Central Processing unit (CPU).
     * Consists of an ALU and a set of registers, designed to fetch and 
     * execute instructions written in the Hack machine language.
     * In particular, the ALU executes the inputted instruction according
     * to the Hack machine language specification, as follows. 
     * The D and A in the language specification refer to CPU-resident registers,
     * while M refers to the memory register addressed by A, i.e. to Memory[A].
     * The inM input holds the value of this register. If the current instruction 
     * needs to write a value to M, the value is placed in outM, the address 
     * of the target register is placed in the addressM output, and the 
     * writeM control bit is asserted. (When writeM=0, any value may 
     * appear in outM). The outM and writeM outputs are combinational: 
     * they are affected instantaneously by the execution of the current 
     * instruction. The addressM and pc outputs are clocked: although they 
     * are affected by the execution of the current instruction, they commit 
     * to their new values only in the next time unit. If reset == 1, then the 
     * CPU jumps to address 0 (i.e. sets pc = 0 in next time unit) rather 
     * than to the address resulting from executing the current instruction. 
     */


    /*
     A cpu cannot have dynamic width because the logic of the processing is dependdent on how many bits are used in the system
     * so if its a 16 bit system then the logic in the Cycle method will be very dependent on that
     */
    public class CPU16Bit
    {
        ALU alu = null;
        Register d = null;
        Register a = null;
        ProgramCounter pc = null;



        public CPU16Bit()
        {
            alu = new ALU(16);
            d = new Register(16);
            pc = new ProgramCounter(16);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memory"></param>
        /// <param name="instruction"></param>
        /// <param name="reset"></param>
        /// <returns>Item1 = outM, Item2 = writeM, Item3 = addressM, Item4 = pc</returns>
        public Tuple<bool[],bool,bool[],bool[]> Cycle(bool[] memory, bool[] instruction, bool reset) {

            //the first bit of the instruction is what is used to determine if its an A instruction or a C instruction, I think this is what is used as the control bit for the MUX
            var C1 = instruction[0];

            //the lecture clearly explains that the other control bits come from the instruction starting at the 10th bit
            var C2 = instruction[10];
            var C3 = instruction[11];
            var C4 = instruction[12];

            //need a reference to the output of the CPU from the last cycle which right now is null, how do we get this??
            //I am assuming C1 is correct but i'm not sure
            var aRegisterInput = Gates.Mux(instruction, null, C1);


            // i have no idea where the load bit comes from for the A register as the lecture did not specify, is it C1? maybe
            var aRegisterOutput = a.Cycle(aRegisterInput, C2);

            //i have no idea where the load bit for the D register comes from
            //how do we get the output from the last cycle
            var dRegisterOutput = d.Cycle(null, C3);

            var aluInput1 = dRegisterOutput;

            //i have no idea where the selector bit for the Mux comes from????
            var aluInput2 = Gates.Mux(aRegisterOutput, memory, C4);

            

            return null;
        }

    }
}
