using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WooComputer.Chips;

namespace WooComputer
{
    class Computer
    {
        static Computer CurrentComputer = null;
        ROM rom = null;
        CPU16Bit cpu;

        //need to build the memory unit!!!!! where is that in the lecture


        public static void ClockCycled() { 
        
            //how would you emulate the actual occurance of a cycle happening which takes the instruction from the ROM and puts that into the CPU
            CurrentComputer.cpu.Cycle(Functions.GetBitArrayFromInteger(0, 16), Functions.GetBitArrayFromInteger(0, 16), false);

            
        }
        public Computer(ClockCycle clockCycle, ROM rom ) {
            CurrentComputer = this;
            this.rom = rom;
            cpu = new CPU16Bit();

            clockCycle.Start();
        }
        public Computer(ClockCycle clockCycle)
            : this(clockCycle, new ROM(new List<bool[]>()))
        {

        }
        public Computer(ROM instructions)
            : this(new ClockCycle(Computer.ClockCycled, 1), instructions)
        {

        }
        public Computer():this(new ClockCycle(Computer.ClockCycled,1), new ROM(new List<bool[]>()))
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
    int hrz;
    Timer timer = new Timer();
    public ClockCycle(Action cycled, int hrz) {
        this.cycled = cycled;
        this.hrz = hrz;
        timer.Elapsed += timer_Elapsed;
    }

    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        cycled();
    }
    
    public void Start(){
        timer.Interval = this.hrz * 1000;
        timer.Start();
    }
}

