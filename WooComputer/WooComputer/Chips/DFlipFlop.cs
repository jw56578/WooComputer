using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    //this is like the Nand gate, maintaining a C# field represents the concept that we don't know how a flip flop really works because its a 
    //electrical engineering thing
    public class DFlipFlop
    {
        public bool Value {get;set;}
        public DFlipFlop() { 
        
        }
    }
}
