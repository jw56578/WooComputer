using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WooComputer
{
    class Computer
    {
        static Computer CurrentComputer = null;
        public static void ClockCycled() { 
        
        }
        public Computer(ClockCycle clockCycle) {
            CurrentComputer = this;
        }
        public Computer():this(new ClockCycle(Computer.ClockCycled))
        { 
            
        }
    }
}



/* start with ROM that will be where the instructions come from
 * Need a timer for the clock cycle 
 * Need a way to architect chips 
 * 
 * should all chips be linked together by observing. events will be registered by the chips that care about other chips output being changed
 */

public class ClockCycle{
    Action cycled;
    public ClockCycle(Action cycled) {
        this.cycled = cycled;
    }
    Timer timer = new Timer();
    public void Start(){
        timer.Interval = 1000;
        timer.Start();
    }
}

/// <summary>
/// should this thing implement an interface in order to be a Time Dependent Chip? like the traingle indicates?
/// should this thing take function delegates to call when the program counter is cycled
/// </summary>
public class ProgramCounter
{
    public int InstructionLocation = 0;
    public bool[] inputoutput ;
    public ProgramCounter() {
      
    }
    public void Next() {
        InstructionLocation++;
    }
    public void Reset() {
        InstructionLocation = 0;
    }
    public void Load(bool[] input)
    {
        inputoutput = input;
    }
    public bool[] GetOut() {
        return inputoutput;
    }


}