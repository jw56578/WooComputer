using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer
{
    public partial class Assembler
    {
        public class AssemblerAnalyzer
        {
            public Assembler assembler = null;
            public AssemblerAnalyzer()
            {

            }

            public Dictionary<string,int> GetSymbolTable()
            {
                return assembler.symbolTable;
            }
            public Dictionary<string, int> GetLabelTable()
            {
                return assembler.labelTable;
            }
            public Dictionary<string, int> GetVariableTable()
            {
                return assembler.variableTable;
            }

        }
    }

}
