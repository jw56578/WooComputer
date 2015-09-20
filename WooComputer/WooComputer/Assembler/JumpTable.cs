using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer
{
    public partial class Assembler
    {
        Dictionary<string, string> jumpTable = new Dictionary<string, string>() { 
            {"null","000"},
            {"JGT","001"},
            {"JEQ","010"},
            {"JGE","011"},
            {"JLT","100"},
            {"JNE","101"},
            {"JLE","110"},
            {"JMP","111"},
        
        };



    }
}
