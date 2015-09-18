//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WooComputer.Chips
//{

//    /**
//     * The Central Processing unit (CPU).
//     * Consists of an ALU and a set of registers, designed to fetch and 
//     * execute instructions written in the Hack machine language.
//     * In particular, the ALU executes the inputted instruction according
//     * to the Hack machine language specification, as follows. 
//     * The D and A in the language specification refer to CPU-resident registers,
//     * while M refers to the memory register addressed by A, i.e. to Memory[A].
//     * The inM input holds the value of this register. If the current instruction 
//     * needs to write a value to M, the value is placed in outM, the address 
//     * of the target register is placed in the addressM output, and the 
//     * writeM control bit is asserted. (When writeM=0, any value may 
//     * appear in outM). The outM and writeM outputs are combinational: 
//     * they are affected instantaneously by the execution of the current 
//     * instruction. The addressM and pc outputs are clocked: although they 
//     * are affected by the execution of the current instruction, they commit 
//     * to their new values only in the next time unit. If reset == 1, then the 
//     * CPU jumps to address 0 (i.e. sets pc = 0 in next time unit) rather 
//     * than to the address resulting from executing the current instruction. 
//     */


//    /*
//     A cpu cannot have dynamic width because the logic of the processing is dependdent on how many bits are used in the system
//     * so if its a 16 bit system then the logic in the Cycle method will be very dependent on that
//     */
//    public partial class CPU16Bit
//    {
//        ALU alu = null;
//        Register d = null;
//        Register a = null;
//        ProgramCounter pc = null;
//        CPUAnalyzer analyzer = null;

//        //these are things that are represnted by the output has to go back into the input of the next cycle
//        //well, how else can this happen unless you maintain state
//        bool[] aluOut = new bool[16];

//        public CPU16Bit(CPUAnalyzer analyzer)
//        {
//            if(analyzer != null)
//                analyzer.cpu = this;
//            alu = new ALU(16);
//            d = new Register(16);
//            pc = new ProgramCounter(16);
//            a = new Register(16);
//        }
//        public CPU16Bit():this(null)
//        {
            
//        }

//        /// <summary>
//        /// https://github.com/jw56578/Nand2Tetris-1/blob/master/05/CPU.hdl
//        /// </summary>
//        /// <param name="memory"></param>
//        /// <param name="instruction"></param>
//        /// <param name="reset"></param>
//        /// <returns>Item1 = outM, Item2 = writeM, Item3 = addressM, Item4 = pc</returns>
//        public Tuple<bool[],bool,bool[],bool[]> Cycle(bool[] memory, bool[] instruction, bool reset) {

//            //the first bit is the A/C instruction. 0 = A, 1 = C
//            var aInstruction = Gates.Not(instruction[0]);
//            var cInstruction = Gates.Not(aInstruction);

//            //first destination bit
//            var aluToA = Gates.And(cInstruction, instruction[10]);
//            //first Mux from schematic
//            var aRegIn = Gates.Mux(instruction, aluOut, aluToA);


//            var loadA = Gates.Or(aInstruction, aluToA);

//            var aRegisterOut = a.Cycle(aRegIn, loadA);

//            var amOut = Gates.Mux(aRegisterOut,memory,instruction[3]);

//            var loadD = Gates.And(cInstruction, instruction[11]);

//            //this is not making sense. the flow doesn't match what is needed
//            //if you add something and assign it to D then it should go in d right away
//            //so the dregister needs to go after the alu calculation
//            var dRegisterOut = d.Cycle(aluOut, loadD);

//            var allAluOut = alu.Cycle(dRegisterOut,amOut,
//                instruction[4],
//                instruction[5],
//                instruction[6],
//                instruction[7],
//                instruction[8],
//                instruction[9]
//                );
//            aluOut = allAluOut.Item1;


//            var addressM = Gates.Or(new bool[16], aRegisterOut);

//            var outM = Gates.Or(new bool[16], aluOut);

//            var writeM = Gates.And(cInstruction, instruction[12]);

//            var jeq = Gates.And(allAluOut.Item2, instruction[14]);

//            var jlt = Gates.And(allAluOut.Item3, instruction[13]);

//            var zeroOrNeg = Gates.Or(allAluOut.Item2, allAluOut.Item3);

//            var positive = Gates.Not(zeroOrNeg);

//            var jgt = Gates.And(positive, instruction[15]);

//            var jle = Gates.Or(jeq, jlt);

//            var jumpToA = Gates.Or(jle, jgt);

//            var pcLoad = Gates.And(cInstruction, jumpToA);

//            var pcInc = Gates.Not(pcLoad);
//            //if pcInc is true and reset is true then pcinc needs to be set to false, NAnd??
//            pcInc = Gates.NAnd(pcInc, reset);
//            //this wasn't part of the code that I copied from the respository, but the lecture specifically states that only 1 load bit on the counter can be true
//            //if reset = true, then the rest of the load bits must be set to false

//            var pcOutput = pc.Cycle(aRegisterOut, pcLoad, pcInc, reset);



//            //how does [0..14] translate to what wee need ??
//            return new Tuple<bool[], bool, bool[], bool[]>(outM, writeM, addressM, pcOutput);



//        }
//        public Tuple<bool[],bool,bool[],bool[]> Cycle2(bool[] memory, bool[] instruction, bool reset) {

//            //the first bit of the instruction is what is used to determine if its an A instruction or a C instruction, I think this is what is used as the control bit for the MUX
//            var C1 = instruction[0];

//            //the lecture clearly explains that the other control bits come from the instruction starting at the 10th bit
//            var C2 = instruction[10];
//            var C3 = instruction[11];
//            var C4 = instruction[12];

//            //need a reference to the output of the CPU from the last cycle which right now is null, how do we get this??
//            //I am assuming C1 is correct but i'm not sure
//            var aRegisterInput = Gates.Mux(instruction, null, C1);



//            var aRegisterOutput = a.Cycle(aRegisterInput, C2);


//            //how do we get the output from the last cycle
//            var dRegisterOutput = d.Cycle(null, C3);

//            var aluInput1 = dRegisterOutput;


//            var aluInput2 = Gates.Mux(aRegisterOutput, memory, C4);

            

//            return null;
//        }

//    }
//}
