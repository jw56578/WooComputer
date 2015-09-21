using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WooComputer.Chips;

namespace WooComputer
{
    public class Computer
    {
        static Computer CurrentComputer = null;
        ROM rom = null;
        CPU16Bit cpu;
        Memory memory;
        Tuple<bool[], bool, bool[], bool[]> output = null;
        bool[] memoryValue = new bool[16];
        bool[] instructionAddress = new bool[16];
        Analyzer analyzer;
        bool reset = false;
        public void Reset() {
            reset = true;
        }
        public static void ClockCycled() {

            var instruction = CurrentComputer.rom.Cycle(CurrentComputer.instructionAddress);

            if (CurrentComputer.output != null)
                CurrentComputer.memoryValue = CurrentComputer.memory.Cycle(CurrentComputer.output.Item1, CurrentComputer.output.Item2, CurrentComputer.output.Item3);
            CurrentComputer.output = CurrentComputer.cpu.Cycle(CurrentComputer.memoryValue, instruction, CurrentComputer.reset);
            CurrentComputer.reset = false;
            CurrentComputer.instructionAddress = CurrentComputer.output.Item4;

            if (CurrentComputer.analyzer != null)
            {
                CurrentComputer.analyzer.cycled(CurrentComputer.instructionAddress, CurrentComputer.output.Item1);
            }
        }
        public Computer(ClockCycle clockCycle, ROM rom, CPU16Bit.CPUAnalyzer analyzer)
        {
            CurrentComputer = this;
            this.rom = rom;
            cpu = new CPU16Bit(analyzer);
            memory = new Memory(16);
            clockCycle.Start();
        }
        public Computer(ClockCycle clockCycle)
            : this(clockCycle, new ROM(new List<bool[]>()),null)
        {

        }
        public Computer(ROM instructions)
            : this(new ClockCycle(Computer.ClockCycled, 1), instructions,null)
        {

        }
        public Computer():this(new ClockCycle(Computer.ClockCycled,1), new ROM(new List<bool[]>()),null)
        { 
            
        }
        public Computer(int hertz,
            List<bool[]> instructions,
            CPU16Bit.CPUAnalyzer cpuAnalyzer,
            Analyzer analyzer
            
            )
            : this(new ClockCycle(Computer.ClockCycled, hertz), new ROM(instructions),cpuAnalyzer)
        {
            this.analyzer = analyzer;
        
        }

        public class Analyzer
        {
            //this thing needs to be aware of the clocke cycle? should this also wrap the other analyzers?
            //instruction address
            //memory contents
            public Action<bool[],bool[]> cycled;
            public Analyzer(Action<bool[],bool[]> cycled){
                this.cycled = cycled;
            }
        }
    }
}


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

