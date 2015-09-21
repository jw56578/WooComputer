using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class ROM
    {   
        [TestMethod]
        public void CanStoreInstructions()
        {
            string code = @"
                @62
                D=A
                @45
                D=D+A
                @R0
                M=D
                //first location in memory should have 107 in it

            ";
            WooComputer.Assembler a = new WooComputer.Assembler(16, code);
            var machineCode = a.GetOutput();
          
            WooComputer.Chips.ROM r = new WooComputer.Chips.ROM(machineCode);

            var output = r.Cycle(new bool[16]);
            Functions.CompareBitArray(output, Functions.GetBitArrayFromString("0000000000111110"));
            output = r.Cycle(Functions.GetBitArrayFromInteger(1,14));
            Functions.CompareBitArray(output, Functions.GetBitArrayFromString("1110110000010000"));
            output = r.Cycle(Functions.GetBitArrayFromInteger(2, 14));
            Functions.CompareBitArray(output, Functions.GetBitArrayFromString("0000000000101101"));
        }
    }
}
