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



/* start with ROM that will be where the instructions come from, watch video on how instructions are formatted
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

