using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer
{
    public partial class Assembler
    {
        string code;
        int width;
        Dictionary<string, int> symbolTable = new Dictionary<string, int>();
        Dictionary<string, int> labelTable = new Dictionary<string, int>();
        Dictionary<string, int> variableTable = new Dictionary<string, int>();
        Assembler.AssemblerAnalyzer analyzer;
        int currentVariableAddress = 16;
        int currentLine = 0;

        public Assembler(int width, string code,Assembler.AssemblerAnalyzer analyzer)
        {
            if (analyzer != null)
                analyzer.assembler = this;
            this.code = code;
            this.width = width;
            this.analyzer = analyzer;
        }
        public Assembler(int width, string code):this(width,code,null) {
           
            
        }
        public List<bool[]> GetOutput() {
            List<bool[]> output = new List<bool[]>();

            var lines = code.Replace(" ","").Split(Environment.NewLine.ToCharArray());
            lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            CreateLabelTable(lines);

            foreach (var l in lines)
            {
                var linecode = Parse(l);
                if (linecode != null) {
                    output.Add(linecode);
                    currentLine++;
                }
            }
            return output;
        }
        void CreateLabelTable(string[] lines) {
            //this logic will work out because once the label is removed from the code, the address will match up to the line of code right after it
            for (int i = 0; i < lines.Length; i ++ )
            {
                var l = lines[i];
                if (l.Substring(0, 1) == "(")
                {
                    var labelname = l.Substring(1, l.Length - 2);
                    labelTable.Add(labelname, i);
                    
                }
            }
        }
        bool[] Parse(string line)
        {
            line = line.Replace(" ", "");
            if (string.IsNullOrEmpty(line))
                return null;
            //Handle Registers
            //R1 = @1 = 0000000000000001
            //parse number after R and convert to binary
            if (line.Substring(0, 1) == "R")
            {
                return ParseAtSymbol(line);
            }
            else if (line.Substring(0, 1) == "@")
            {
                return ParseAtSymbol(line);
            }
            //C instruction
            else 
            {
                return ParseCInstruction(line);
            }

 
            return null;
            
        }
        bool[] ParseCInstruction(string line)
        {
            string[] destcomp = line.Split("=".ToCharArray());
            string[] jump = line.Split(";".ToCharArray());

            var destination = destinationTable[destcomp[0]];
            var a = computationTable[destcomp[1]].Item1;
            var computation = computationTable[destcomp[1]].Item2;
            var jumpCode = jump.Length > 1 ? jumpTable[jump[1]] : jumpTable["null"];


            return Functions.GetBitArrayFromString("111" + a + computation + destination + jumpCode );
        }
        bool[] ParseAtSymbol(string line)
        {
            var valueAfterSymbol = line.Substring(1, line.Length - 1);
            int number;
            if (int.TryParse(valueAfterSymbol, out number))
            {
                //address location or number
                return Functions.GetBitArrayFromInteger(number, width);
            }
            else { 
                //label
                if (labelTable.ContainsKey(valueAfterSymbol))
                {
                    return Functions.GetBitArrayFromInteger(labelTable[valueAfterSymbol], width);
                }
                //existing variable
                else if (this.variableTable.ContainsKey(valueAfterSymbol))
                {
                    return Functions.GetBitArrayFromInteger(variableTable[valueAfterSymbol], width);
                }
                else // new variable observed
                {
                    variableTable.Add(valueAfterSymbol, currentVariableAddress);
                    var bits = Functions.GetBitArrayFromInteger(currentVariableAddress, width);
                    currentVariableAddress++;
                    return bits;
                }
            }
        }
    }
}
