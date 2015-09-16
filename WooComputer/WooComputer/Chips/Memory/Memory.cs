using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer.Chips
{
    public class Memory
    {
        int width;
        public Memory(int width)
        {
            this.width = width;
        }

        public void Cycle(bool[] input, bool load, bool[] address )
        {

            //not sure if subtracting 2 is specific to 16 bit. might need to adjusts
            var dmuxout1 = Gates.DMux(load, address[address.Length -2]);



        // Select between Ram and MM to send load bit
        //DMux(in=load, sel=address[14], a=loadRam, b=loadMM);

        //RAM16K(in=in, load=loadRam, address=address[0..13], out=outRam);

        //// ----- Memory Map (MM) ----- //
        //DMux(in=loadMM, sel=address[13], a=loadScreen, b=loadKeyboard);

        //Screen(in=in, load=loadScreen, address=address[0..12], out=outScreen);
        //Keyboard(out=outKeyboard);

        //// Select between screen and keyboard for output
        //Mux16(a=outScreen, b=outKeyboard, sel=address[13], out=outMM);
        //// ----- End Memory Map ----- //

        //// Select from RAM or MM for output
        //Mux16(a=outRam, b=outMM, sel=address[14], out=out);
        
        }
    }
}
