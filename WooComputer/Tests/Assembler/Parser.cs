using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Assembler
{
    [TestClass]
    public partial class Parser
    {
        [TestMethod]
        public void CanParseRegister()
        {
            WooComputer.Assembler a = new WooComputer.Assembler(16,
                @"
                    R4

                ");

            var output = a.GetOutput();
            Assert.IsTrue(output.Count() == 1);
            Functions.CompareBitArray(output[0], Functions.GetBitArrayFromInteger(4, 16));
            
        }
        [TestMethod]
        public void CanParseACode()
        {
            WooComputer.Assembler a = new WooComputer.Assembler(16,
                @"
                    @100

                ");

            var output = a.GetOutput();
            Assert.IsTrue(output.Count() == 1);
            Functions.CompareBitArray(output[0], Functions.GetBitArrayFromInteger(100, 16));

        }
        [TestMethod]
        public void CanParseCInstruction()
        {
            WooComputer.Assembler a = new WooComputer.Assembler(16,
                @"
                    


                    D=D+1

                ");

            var output = a.GetOutput();
            Assert.IsTrue(output.Count() == 1);
            Functions.CompareBitArray(output[0], Functions.GetBitArrayFromString("1110011111010000"));

        }
        [TestMethod]
        public void CanParseLabel()
        {
            WooComputer.Assembler.AssemblerAnalyzer  analyzer = new WooComputer.Assembler.AssemblerAnalyzer();
            WooComputer.Assembler a = new WooComputer.Assembler(16,
                @"
                    (GO)
                        xxxxx
                        whatever    
                        do stuff


                    (Stop)
                        labelstarthere
                        stuff
                         xxxx




                ",analyzer);

            var output = a.GetOutput();
            var symbols = analyzer.GetLabelTable();
            Assert.IsTrue(symbols.Count() == 2);
            Assert.IsTrue(symbols.ContainsKey("GO"));
            Assert.IsTrue(symbols.ContainsKey("Stop"));

        }
        [TestMethod]
        public void CanParseVariable()
        {
            WooComputer.Assembler.AssemblerAnalyzer analyzer = new WooComputer.Assembler.AssemblerAnalyzer();
            WooComputer.Assembler a = new WooComputer.Assembler(16,
                @"
                    (GO)
                        @variable1
                        @variable2  
                        do stuff


                    (Stop)
                        @variable3
                         xxxx




                ", analyzer);

            var output = a.GetOutput();
            Assert.IsTrue(output.Count() == 3);
            var variables = analyzer.GetVariableTable();
            Assert.IsTrue(variables.Count() == 3);
            Assert.IsTrue(variables.ContainsKey("variable1"));
            Assert.IsTrue(variables.ContainsKey("variable2"));
            Assert.IsTrue(variables.ContainsKey("variable3"));

            Assert.IsTrue(variables["variable1"] == 16);
            Assert.IsTrue(variables["variable2"] == 17);
            Assert.IsTrue(variables["variable3"] == 18);



        }
    }
}
