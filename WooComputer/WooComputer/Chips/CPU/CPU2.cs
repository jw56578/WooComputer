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
    public partial class CPU16Bit
    {
        ALU alu = null;
        Register d = null;
        Register a = null;
        ProgramCounter pc = null;
        CPUAnalyzer analyzer = null;

        //these are things that are represnted by the output has to go back into the input of the next cycle
        //well, how else can this happen unless you maintain state
        bool[] aluOut = new bool[16];

        public CPU16Bit(CPUAnalyzer analyzer)
        {
            if (analyzer != null)
                analyzer.cpu = this;
            alu = new ALU(16);
            d = new Register(16);
            pc = new ProgramCounter(16);
            a = new Register(16);
        }
        public CPU16Bit()
            : this(null)
        {

        }

        /// <summary>
        /// https://github.com/Sean-Der/nand2tetris/blob/master/05/CPU.hdl
        /// </summary>
        /// <param name="memory"></param>
        /// <param name="instruction"></param>
        /// <param name="reset"></param>
        /// <returns>Item1 = outM, Item2 = writeM, Item3 = addressM, Item4 = pc</returns>
        public Tuple<bool[], bool, bool[], bool[]> Cycle(bool[] memory, bool[] instruction, bool reset)
        {

            

            var allAluOut = alu.Cycle(dRegisterOut, amOut,
                instruction[4],
                instruction[5],
                instruction[6],
                instruction[7],
                instruction[8],
                instruction[9]
                );
            aluOut = allAluOut.Item1;



            var pcOutput = pc.Cycle(aRegisterOut, pcLoad, pcInc, reset);



            //how does [0..14] translate to what wee need ??
            return new Tuple<bool[], bool, bool[], bool[]>(outM, writeM, addressM, pcOutput);



        }
     

    }
}
