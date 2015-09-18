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
        Ram16K ram;
        public Memory(int width)
        {
            this.width = width;
            ram = new Ram16K(width);
        }
        /// <summary>
        /// https://github.com/jw56578/Nand2Tetris-1/blob/master/05/Memory.hdl
        /// </summary>
        /// <param name="input"></param>
        /// <param name="load"></param>
        /// <param name="address">15 bits?</param>
        public bool[] Cycle(bool[] input, bool load, bool[] address )
        {
            //address[13..14], 
            var dmuxOutput = Gates.DMux4Way(load, new bool[] { address[0], address[1] });
            var orOutput = Gates.Or(dmuxOutput.Item1,dmuxOutput.Item2);


            var ramOutput = ram.Cycle(input, orOutput, new bool[]{
            address[1],
            address[2],
            address[3],
            address[4],
            address[5],
            address[6],
            address[7],
            address[8],
            address[9],
            address[10],
            address[11],
            address[12],
            address[13],
            address[14],
            });

            var output = Gates.Mux4Way16(ramOutput, ramOutput, new bool[16], new bool[16], new bool[] { address[0], address[1] });

            return output;

        }
    }
}
