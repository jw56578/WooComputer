using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooComputer
{
    public partial class Assembler
    {
        Dictionary<string, Tuple<string,string>> computationTable = new Dictionary<string, Tuple<string,string>>() { 
            {"0",new Tuple<string,string>("0","101010")},
            {"1",new Tuple<string,string>("0","111111")},
            {"-1",new Tuple<string,string>("0","111010")},
            {"D",new Tuple<string,string>("0","001100")},
            {"A",new Tuple<string,string>("0","110000")},
            {"!D",new Tuple<string,string>("0","001101")},
            {"!A",new Tuple<string,string>("0","110001")},
            {"-D",new Tuple<string,string>("0","001111")},
            {"-A",new Tuple<string,string>("0","110011")},
            {"D+1",new Tuple<string,string>("0","011111")},
            {"A+1",new Tuple<string,string>("0","110111")},
            {"D-1",new Tuple<string,string>("0","001110")},
            {"A-1",new Tuple<string,string>("0","110010")},
            {"D+A",new Tuple<string,string>("0","000010")},
            {"D-A",new Tuple<string,string>("0","010011")},
            {"A-D",new Tuple<string,string>("0","000111")},
            {"D&A",new Tuple<string,string>("0","000000")},
            {"D|A",new Tuple<string,string>("0","010101")},
          
           // {"",new Tuple<string,string>("1","101010")},
            //{"",new Tuple<string,string>("1","111111")},
           // {"",new Tuple<string,string>("1","111010")},
           // {"",new Tuple<string,string>("1","001100")},
            {"M",new Tuple<string,string>("1","110000")},
           // {"",new Tuple<string,string>("1","001101")},
            {"!M",new Tuple<string,string>("1","110001")},
           // {"",new Tuple<string,string>("1","001111")},
            {"-M",new Tuple<string,string>("1","110011")},
            //{"",new Tuple<string,string>("1","011111")},
            {"M+1",new Tuple<string,string>("1","110111")},
            //{"",new Tuple<string,string>("1","001110")},
            {"M-1",new Tuple<string,string>("1","110010")},
            {"D+M",new Tuple<string,string>("1","000010")},
            {"D-M",new Tuple<string,string>("1","010011")},
            {"M-D",new Tuple<string,string>("1","000111")},
            {"D&M",new Tuple<string,string>("1","000000")},
            {"D|M",new Tuple<string,string>("1","010101")},
        
        };



    }
}
