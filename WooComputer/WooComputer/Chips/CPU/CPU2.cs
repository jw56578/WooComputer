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

        bool[] storedD = new bool[16];

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
            var aInstructionP = Gates.Not(instruction[0]);
            //this is simply the bit as described in the instructions that says that destination is M
            var writeM  = Gates.And(instruction[0],instruction[12]);

            var newA = Gates.Mux(aluOut, instruction, aInstructionP);
            var storeAp1 = Gates.And(instruction[10], instruction[0]);
            var storeAp = Gates.Or(storeAp1, aInstructionP);

            var storedA = a.Cycle(newA, storeAp);//also needs to go out to memory address

            var ALUInAM = Gates.Mux(storedA,memory,instruction[3]);



            var allAluOut = alu.Cycle(storedD, ALUInAM,
                instruction[4],
                instruction[5],
                instruction[6],
                instruction[7],
                instruction[8],
                instruction[9]
                );
            aluOut = allAluOut.Item1; // also needs to go to out memory

            var storeDP = Gates.And(instruction[11], instruction[0]);
            storedD = d.Cycle(aluOut, storeDP);

            var zrinv = Gates.Not(allAluOut.Item2);
            var nginv = Gates.Not(allAluOut.Item3);

            var JGT1 = Gates.And(zrinv, nginv);
            var JGT = Gates.And(instruction[15], JGT1);

            var JEQ = Gates.And(allAluOut.Item2, instruction[14]);
            var Load1 = Gates.Or(JEQ, JGT);

            var JLT = Gates.And(allAluOut.Item3, instruction[13]);
            var Load2 = Gates.Or(JLT, Load1);
            var Load3 = Gates.And(Load2, instruction[0]);


            //this wasn't part of the code that I copied from the respository, but the lecture specifically states that only 1 load bit on the counter can be true
            // //if reset = true, then the rest of the load bits must be set to false

            //  var pcOutput = pc.Cycle(aRegisterOut, pcLoad, pcInc, reset);
            var pcInc = Gates.NAnd(true, reset);


            var pcOutput = pc.Cycle(storedA, Load3, pcInc, reset);

    //PC(in=storedA, load=Load3, inc=true, reset=reset, out[0..14]=pc);

            //how does [0..14] translate to what wee need ??
            return new Tuple<bool[], bool, bool[], bool[]>(aluOut, writeM,
                new bool[] { storedA[1], storedA[2], storedA[3], storedA[4], storedA[5], storedA[6], storedA[7], storedA[8], storedA[9], storedA[10], 
                storedA[11], storedA[12], storedA[13], storedA[14],storedA[15] },
                new bool[] { pcOutput[1], pcOutput[2], pcOutput[3], pcOutput[4], pcOutput[5], pcOutput[6], pcOutput[7], pcOutput[8], pcOutput[9], pcOutput[10], pcOutput[11], pcOutput[12], pcOutput[13], pcOutput[14],pcOutput[15] });



        }
     

    }
}
