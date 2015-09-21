using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WooComputer
{
    public partial class Form1 : Form
    {
        Computer c;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
            string code = @"
                @62
                D=A
                @45
                D=D+A
                @R0
                M=D
                //first location in memory should have 107 in it

            ";
            Assembler a = new Assembler(16, code);
            var machineCode = a.GetOutput();
            var cpuAnalyzer = new WooComputer.Chips.CPU16Bit.CPUAnalyzer();
            var analyzer = new Computer.Analyzer((instructionAddress,memoryValue)=>{
                if (txtARegister.InvokeRequired)
                {
                    txtARegister.Invoke(new MethodInvoker(delegate { txtARegister.Text = Functions.GetIntegerFromBitArray(cpuAnalyzer.GetAContents()).ToString(); }));
                }
                if (txtDRegister.InvokeRequired)
                {
                    txtDRegister.Invoke(new MethodInvoker(delegate { txtDRegister.Text = Functions.GetIntegerFromBitArray(cpuAnalyzer.GetDContents()).ToString(); }));
                }

                if (txtMemoryValue.InvokeRequired)
                {
                    txtMemoryValue.Invoke(new MethodInvoker(delegate { txtMemoryValue.Text = Functions.GetIntegerFromBitArray(memoryValue).ToString(); }));
                }
                if (txtInstructionAddress.InvokeRequired)
                {
                    txtInstructionAddress.Invoke(new MethodInvoker(delegate { txtInstructionAddress.Text = Functions.GetIntegerFromBitArray(instructionAddress).ToString(); }));
                }
                //txtARegister.Text = Functions.GetIntegerFromBitArray(cpuAnalyzer.GetAContents()).ToString();
                //txtDRegister.Text =  Functions.GetIntegerFromBitArray(cpuAnalyzer.GetDContents()).ToString();
                //txtMemoryValue.Text =  Functions.GetIntegerFromBitArray(memoryValue).ToString();
                //txtInstructionAddress.Text = Functions.GetIntegerFromBitArray(instructionAddress).ToString();
            
            });

            c = new Computer(2, machineCode, cpuAnalyzer, analyzer);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            c.Reset();
        }
    }
}
