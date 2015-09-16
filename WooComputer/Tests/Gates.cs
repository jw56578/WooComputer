using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooComputer.Chips;
using System.Collections;
using WooComputer;

namespace Tests
{
    [TestClass]
    public class Gates
    {
        [TestMethod]
        public void NAndWorks()
        {
            Assert.IsTrue(WooComputer.Chips.Gates.NAnd(false, false));
            Assert.IsTrue(WooComputer.Chips.Gates.NAnd(false, true));
            Assert.IsTrue(WooComputer.Chips.Gates.NAnd(true, false));
            Assert.IsFalse(WooComputer.Chips.Gates.NAnd(true, true));
        }
        [TestMethod]
        public void NotWorks()
        {
            Assert.IsTrue(WooComputer.Chips.Gates.Not(false));
            Assert.IsFalse(WooComputer.Chips.Gates.Not(true));
        }
        [TestMethod]
        public void Not8Works()
        {
            CompareBitArray(WooComputer.Chips.Gates.Not(
                new bool[] { false, false, false, false, false, false, false, false }),
                new bool[] { true, true, true, true, true, true, true, true });
            CompareBitArray(WooComputer.Chips.Gates.Not(
                 new bool[] { false, true, false, true, false, true, false, true }),
                 new bool[] { true, false, true, false, true, false, true, false });
            CompareBitArray(WooComputer.Chips.Gates.Not(
                 new bool[] { false, false, false, false, true, true, true, true }),
                 new bool[] { true, true, true, true, false, false, false, false });
        }
        [TestMethod]
        public void AndWorks()
        {
            Assert.IsFalse(WooComputer.Chips.Gates.And(false, false));
            Assert.IsFalse(WooComputer.Chips.Gates.And(false, true));
            Assert.IsFalse(WooComputer.Chips.Gates.And(true, false));
            Assert.IsTrue(WooComputer.Chips.Gates.And(true, true));
        }
        [TestMethod]
        public void OrWorks()
        {
            Assert.IsFalse(WooComputer.Chips.Gates.Or(false, false));
            Assert.IsTrue(WooComputer.Chips.Gates.Or(false, true));
            Assert.IsTrue(WooComputer.Chips.Gates.Or(true, false));
            Assert.IsTrue(WooComputer.Chips.Gates.Or(true, true));
        }
        [TestMethod]
        public void XOrWorks()
        {
            Assert.IsFalse(WooComputer.Chips.Gates.XOr(false, false));
            Assert.IsTrue(WooComputer.Chips.Gates.XOr(false, true));
            Assert.IsTrue(WooComputer.Chips.Gates.XOr(true, false));
            Assert.IsFalse(WooComputer.Chips.Gates.XOr(true, true));
        }
        [TestMethod]
        public void Mux8WayWorks()
        {
            CompareBitArray(WooComputer.Chips.Gates.Mux8Way16(
                 new bool[] { false, false, false, false, true, true, true, true }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, true, false, false, true, false }
                 , new bool[] { false, true, false, true, false, true, false, true }
                 , new bool[] { false, true, false, true, false, true, false, true }
                 , new bool[] { false, true, false, true, false, true, false, true }
                 , new bool[] { true, true, false, true, true, true, false, true }
                 , new bool[] { true, true, false, true, false, true, false, true }
                 , new bool[] { false, false,false }
                 ),
                 new bool[] { false, false, false, false, true, true, true, true });

            CompareBitArray(WooComputer.Chips.Gates.Mux8Way16(
                 new bool[] { false, false, false, false, true, true, true, true }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, true, false, false, true, false }
                 , new bool[] { false, true, false, true, false, true, false, true }
                 , new bool[] { false, true, false, true, false, true, false, true }
                 , new bool[] { false, true, false, true, false, true, false, true }
                 , new bool[] { true, true, false, true, true, true, false, true }
                 , new bool[] { true, true, false, true, false, true, false, true }
                 , new bool[] { false, false, true }
                 ),
                 new bool[] { false, false, false, false, false, false, false, false });


            CompareBitArray(WooComputer.Chips.Gates.Mux8Way16(
                 new bool[] { false, false, false, false, true, true, true, true }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, true, false, false, true, false }
                 , new bool[] { false, true, false, true, false, true, false, true }
                 , new bool[] { false, true, false, true, false, true, false, true }
                 , new bool[] { false, true, false, true, false, true, false, true }
                 , new bool[] { true, true, false, true, true, true, false, true }
                 , new bool[] { true, true, false, true, false, true, false, true }
                 , new bool[] { false, true, false }
                 ),
                 new bool[] { false, false, false, true, false, false, true, false });

            CompareBitArray(WooComputer.Chips.Gates.Mux8Way16(
                new bool[] { false, false, false, false, true, true, true, true }
                , new bool[] { false, false, false, false, false, false, false, false }
                , new bool[] { false, false, false, true, false, false, true, false }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { true, true, false, true, true, true, false, true }
                , new bool[] { true, true, false, true, false, true, false, true }
                , new bool[] { false, true, true }
                ),
                new bool[] { false, true, false, true, false, true, false, true });

            CompareBitArray(WooComputer.Chips.Gates.Mux8Way16(
                new bool[] { false, false, false, false, true, true, true, true }
                , new bool[] { false, false, false, false, false, false, false, false }
                , new bool[] { false, false, false, true, false, false, true, false }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { true, true, true, true, true, true, true, true }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { true, true, false, true, true, true, false, true }
                , new bool[] { true, true, false, true, false, true, false, true }
                , new bool[] { true, false, false }
                ),
                new bool[] { true, true, true, true, true, true, true, true });

            CompareBitArray(WooComputer.Chips.Gates.Mux8Way16(
                new bool[] { false, false, false, false, true, true, true, true }
                , new bool[] { false, false, false, false, false, false, false, false }
                , new bool[] { false, false, false, true, false, false, true, false }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { true, true, true, true, true, true, true, true }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { true, true, false, true, true, true, false, true }
                , new bool[] { true, true, false, true, false, true, false, true }
                , new bool[] { true, false, true }
                ),
                new bool[] { false, true, false, true, false, true, false, true });

            CompareBitArray(WooComputer.Chips.Gates.Mux8Way16(
                new bool[] { false, false, false, false, true, true, true, true }
                , new bool[] { false, false, false, false, false, false, false, false }
                , new bool[] { false, false, false, true, false, false, true, false }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { true, true, true, true, true, true, true, true }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { true, true, false, true, true, true, false, true }
                , new bool[] { true, true, false, true, false, true, false, true }
                , new bool[] { true, true, false }
                ),
                new bool[] { true, true, false, true, true, true, false, true });

            CompareBitArray(WooComputer.Chips.Gates.Mux8Way16(
                new bool[] { false, false, false, false, true, true, true, true }
                , new bool[] { false, false, false, false, false, false, false, false }
                , new bool[] { false, false, false, true, false, false, true, false }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { true, true, true, true, true, true, true, true }
                , new bool[] { false, true, false, true, false, true, false, true }
                , new bool[] { true, true, false, true, true, true, false, true }
                , new bool[] { true, true, false, true, false, true, false, true }
                , new bool[] { true, true, true }
                ),
                new bool[] { true, true, false, true, false, true, false, true });



        }
        [TestMethod]
        public void Mux4WayWorks()
        {
            CompareBitArray(WooComputer.Chips.Gates.Mux4Way16(
                 new bool[] { false, false, false, false, true, true, true, true }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false }
                 ),
                 new bool[] { false, false, false, false, true, true, true, true });

            CompareBitArray(WooComputer.Chips.Gates.Mux4Way16(
                 new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, false, true, true, true, true }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, true }
                 ),
                 new bool[] { false, false, false, false, true, true, true, true });

            CompareBitArray(WooComputer.Chips.Gates.Mux4Way16(
                 new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, false, true, true, true, true }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { true, false }
                 ),
                 new bool[] { false, false, false, false, true, true, true, true });


            CompareBitArray(WooComputer.Chips.Gates.Mux4Way16(
                 new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, false, false, false, false, false }
                 , new bool[] { false, false, false, false, true, true, true, true }
                 , new bool[] { true,true }
                 ),
                 new bool[] { false, false, false, false, true, true, true, true });



        }
        [TestMethod]
        public void MuxWorks()
        {
            Assert.IsFalse(WooComputer.Chips.Gates.Mux(false, false,false));
            Assert.IsFalse(WooComputer.Chips.Gates.Mux(false, true,false));
            Assert.IsTrue(WooComputer.Chips.Gates.Mux(true, false, false));
            Assert.IsTrue(WooComputer.Chips.Gates.Mux(true, true, false));

            Assert.IsFalse(WooComputer.Chips.Gates.Mux(false, false, true));
            Assert.IsTrue(WooComputer.Chips.Gates.Mux(false, true, true));
            Assert.IsFalse(WooComputer.Chips.Gates.Mux(true, false, true));
            Assert.IsTrue(WooComputer.Chips.Gates.Mux(true, true, true));

        }
        [TestMethod]
        public void DMuxWorks()
        {
            var output = WooComputer.Chips.Gates.DMux(true, false);
            Assert.IsTrue(output.Item1);
            Assert.IsFalse(output.Item2);

            output = WooComputer.Chips.Gates.DMux(false, false);
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);

            output = WooComputer.Chips.Gates.DMux(true,true);
            Assert.IsFalse(output.Item1);
            Assert.IsTrue(output.Item2);

            output = WooComputer.Chips.Gates.DMux(false, true);
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);



        }
        [TestMethod]
        public void DMux4WayWorks()
        {
            //1
            var output = WooComputer.Chips.Gates.DMux4Way(true, new bool[]{false,false});
            Assert.IsTrue(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);

            output = WooComputer.Chips.Gates.DMux4Way(true, new bool[] { false, true });
            Assert.IsFalse(output.Item1);
            Assert.IsTrue(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);

            output = WooComputer.Chips.Gates.DMux4Way(true, new bool[] { true, false });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsTrue(output.Item3);
            Assert.IsFalse(output.Item4);

            output = WooComputer.Chips.Gates.DMux4Way(true, new bool[] { true, true });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsTrue(output.Item4);
            //2
            output = WooComputer.Chips.Gates.DMux4Way(false, new bool[] { false, false });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);

            output = WooComputer.Chips.Gates.DMux4Way(false, new bool[] { false, true });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);

            output = WooComputer.Chips.Gates.DMux4Way(false, new bool[] { true, false });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);

            output = WooComputer.Chips.Gates.DMux4Way(false, new bool[] { true, true });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);

        }
        [TestMethod]
        public void DMux8WayWorks()
        {
            var output = WooComputer.Chips.Gates.DMux8Way(true, new bool[] { false, false,false });
            Assert.IsTrue(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(true, new bool[] { false, false, true });
            Assert.IsFalse(output.Item1);
            Assert.IsTrue(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(true, new bool[] { false, true, false });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsTrue(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(true, new bool[] { false, true, true });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsTrue(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(true, new bool[] { true, false, false });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsTrue(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(true, new bool[] { true, false, true });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsTrue(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(true, new bool[] { true, true, false });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsTrue(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(true, new bool[] { true, true, true });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsTrue(output.Rest.Item1);


            //false input


            output = WooComputer.Chips.Gates.DMux8Way(false, new bool[] { false, false, false });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(false, new bool[] { false, false, true });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(false, new bool[] { false, true, false });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(false, new bool[] { false, true, true });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(false, new bool[] { true, false, false });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(false, new bool[] { true, false, true });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(false, new bool[] { true, true, false });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);

            output = WooComputer.Chips.Gates.DMux8Way(false, new bool[] { true, true, true });
            Assert.IsFalse(output.Item1);
            Assert.IsFalse(output.Item2);
            Assert.IsFalse(output.Item3);
            Assert.IsFalse(output.Item4);
            Assert.IsFalse(output.Item5);
            Assert.IsFalse(output.Item6);
            Assert.IsFalse(output.Item7);
            Assert.IsFalse(output.Rest.Item1);
        }
        [TestMethod]
        public void BinaryConverterWorks()
        {
            //BitArray test = new BitArray(1, false);
            //Assert.IsTrue (0 == BinaryConverter.ToNumeral(test));
            //test = new BitArray(new bool[]{true});
            //Assert.IsTrue(1 == BinaryConverter.ToNumeral(test));
            //test = new BitArray(new bool[] { true,false });
            //Assert.IsTrue(2 == BinaryConverter.ToNumeral(test));
            //test = new BitArray(new bool[] { true, true });
            //Assert.IsTrue(3 == BinaryConverter.ToNumeral(test));
            //test = new BitArray(new bool[] { true, false,false });
            //Assert.IsTrue(4 == BinaryConverter.ToNumeral(test));
        }
        void CompareBitArray(bool[] source, bool[] compareTo)
        {
            Functions.CompareBitArray(source, compareTo);
        }
    }
}
