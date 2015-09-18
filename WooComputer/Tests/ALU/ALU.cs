using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public partial class ALU
    {
        WooComputer.Chips.ALU alu = new WooComputer.Chips.ALU(16);
        [TestMethod]
        public void CanOutputZero()
        {
            var output = alu.Cycle(
                new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , true
                , false
                , true
                , false
                , true
                , false);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });

        }

        [TestMethod]
        public void CanOutputOne()
        {
            var output = alu.Cycle(
                  new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , true
                , true
                , true
                , true
                , true
                , true);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true });

        }

        [TestMethod]
        public void CanOutputNegativeOne()
        {
            var output = alu.Cycle(
                   new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , true
                , true
                , true
                ,false
                , true
                , false);
            Functions.CompareBitArray(output.Item1, new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true });

        }

        [TestMethod]
        public void CanOutputX()
        {
            var output = alu.Cycle(
                   new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , new bool[] { false, true, false, false, false, false, true, true, false, true, false, false, true, false, true, false }
                , false
                , false
                , true
                , true
                , false
                , false);
            Functions.CompareBitArray(output.Item1, new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false });

        }
        [TestMethod]
        public void CanOutputY()
        {
            var output = alu.Cycle(
                   new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , new bool[] { false, true, false, false, false, false, true, true, false, true, false, false, true, false, true, false }
                , true
                , true
                , false
                , false
                , false
                , false);
            Functions.CompareBitArray(output.Item1, new bool[] { false, true, false, false, false, false, true, true, false, true, false, false, true, false, true, false });

        }


        [TestMethod]
        public void CanOutputNotX()
        {
            var output = alu.Cycle(
                   new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , new bool[] { false, true, false, false, false, false, true, true, false, true, false, false, true, false, true, false }
                , false
                , false
                , true
                , true
                , false
                , true);
            Functions.CompareBitArray(output.Item1, new bool[] {true,false,false,true,false,true,false,true,true,false,false,true,false,true,false,true });

        }
        [TestMethod]
        public void CanOutputNotY()
        {
            var output = alu.Cycle(
                   new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , new bool[] { false, true, false, false, false, false, true, true, false, true, false, false, true, false, true, false }
                , true
                , true
                , false
                , false
                , false
                , true);
            Functions.CompareBitArray(output.Item1, new bool[] { true, false, true, true, true, true, false, false, true, false, true, true, false, true, false, true });

        }


        [TestMethod]
        public void CanOutputXPlusOne()
        {
            var output = alu.Cycle(
                   new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
                , new bool[] { false, true, false, false, false, false, true, true, false, true, false, false, true, false, true, false }
                , false
                , true
                , true
                , true
                , true
                , true);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true });
            output = alu.Cycle(
                  new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }
               , new bool[] { false, true, false, false, false, false, true, true, false, true, false, false, true, false, true, false }
               , false
               , true
               , true
               , true
               , true
               , true);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false });

        }
        [TestMethod]
        public void CanOutputYPlusOne()
        {
            var output = alu.Cycle(
                   new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
                , true
                , true
                , false
                , true
                , true
                , true);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true });

        }
        [TestMethod]
        public void CanOutputXMinusOne()
        {
            var output = alu.Cycle(
                   new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }
                , new bool[] { false, true, false, false, false, false, true, true, false, true, false, false, true, false, true, false }
                , false
                , false
                , true
                , true
                , true
                , false);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            output = alu.Cycle(
                  new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false }
               , new bool[] { false, true, false, false, false, false, true, true, false, true, false, false, true, false, true, false }
               , false
               , false
               , true
               , true
               , true
               , false);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true });

        }
        [TestMethod]
        public void CanOutputYMinusOne()
        {
            var output = alu.Cycle(
                   new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false }
                , new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }
                , true
                , true
                , false
                , false
                , true
                , false);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            output = alu.Cycle(
                   new bool[] { false, true, true, false, true, false, true, false, false, true, true, false, true, false, true, false }
                , new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }
                , true
                , true
                , false
                , false
                , true
                , false);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false });

        }
        [TestMethod]
        public void CanOutputXPlusY()
        {
            var output = alu.Cycle(
                   new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
                , new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }
                , false
                , false
                , false
                , false
                , true
                , false);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true });
            output = alu.Cycle(
                   new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }
                , new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }
                , false
                , false
                , false
                , false
                , true
                , false);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false });
            output = alu.Cycle(
                   new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }
                , new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true }
                , false
                , false
                , false
                , false
                , true
                , false);
            Functions.CompareBitArray(output.Item1, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false });

        }
        [TestMethod]
        public void CanOutputYMInusX()
        {

            var six = Functions.GetBitArrayFromInteger(6,16);
            var three = Functions.GetBitArrayFromInteger(3, 16);

            //6-1=5
            var output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(1, 16)
                , six
                , false
                , false
                , false
                , true
                , true
                , true);
            Functions.CompareBitArray(output.Item1, Functions.GetBitArrayFromInteger(5, 16));


            
            output = alu.Cycle(
                    Functions.GetBitArrayFromInteger(10, 16)
                , Functions.GetBitArrayFromInteger(33, 16)
               , false
                , false
                , false
                , true
                , true
                , true);
            Functions.CompareBitArray(output.Item1, Functions.GetBitArrayFromInteger(23, 16));


            output = alu.Cycle(
               Functions.GetBitArrayFromInteger(32, 16)
           , Functions.GetBitArrayFromInteger(111, 16)
          , false
           , false
           , false
           , true
           , true
           , true);
            Functions.CompareBitArray(output.Item1, Functions.GetBitArrayFromInteger(79, 16));


        }


        [TestMethod]
        public void CanOutputXAndY()
        {

            var x = Functions.GetBitArrayFromInteger(6, 16);
            var y = Functions.GetBitArrayFromInteger(3, 16);
            var and = WooComputer.Chips.Gates.And(x, y);

            //6-1=5
            var output = alu.Cycle(
                   x
                , y
                , false
                , false
                , false
                , false
                , false
                , false);
            Functions.CompareBitArray(output.Item1, and);

            x = Functions.GetBitArrayFromInteger(35, 16);
            y = Functions.GetBitArrayFromInteger(75, 16);
            and = WooComputer.Chips.Gates.And(x, y);

            output = alu.Cycle(
                   x
                , y
                , false
                , false
                , false
                , false
                , false
                , false);
            Functions.CompareBitArray(output.Item1, and);

        }


        [TestMethod]
        public void CanOutputXOrY()
        {

            var x = Functions.GetBitArrayFromInteger(6, 16);
            var y = Functions.GetBitArrayFromInteger(3, 16);
            var or = WooComputer.Chips.Gates.Or(x, y);

            //6-1=5
            var output = alu.Cycle(
                  x
                , y
                , false
                , true
                , false
                , true
                , false
                , true);
            Functions.CompareBitArray(output.Item1, or);

            x = Functions.GetBitArrayFromInteger(35, 16);
            y = Functions.GetBitArrayFromInteger(75, 16);
            or = WooComputer.Chips.Gates.Or(x, y);

            output = alu.Cycle(
                  x
                , y
                , false
                , true
                , false
                , true
                , false
                , true);
            Functions.CompareBitArray(output.Item1, or);

        }
 
        [TestMethod]
        public void IsZeroWorks()
        {
            //item2

            var output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(1, 16)
                , Functions.GetBitArrayFromInteger(1, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsTrue(output.Item2);

            output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(2, 16)
                , Functions.GetBitArrayFromInteger(2, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsTrue(output.Item2);

            output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(11, 16)
                , Functions.GetBitArrayFromInteger(11, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsTrue(output.Item2);

            output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(12, 16)
                , Functions.GetBitArrayFromInteger(12, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsTrue(output.Item2);

            output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(13, 16)
                , Functions.GetBitArrayFromInteger(16, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsFalse(output.Item2);

            output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(14, 16)
                , Functions.GetBitArrayFromInteger(166, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsFalse(output.Item2);

            output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(1555, 16)
                , Functions.GetBitArrayFromInteger(12222, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsFalse(output.Item2);

            output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(3456, 16)
                , Functions.GetBitArrayFromInteger(3456, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsTrue(output.Item2);



        }
    }
}
