using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooComputer.Chips;
namespace Tests
{
    [TestClass]
    public class Memory
    {
        [TestMethod]
        public void BitWorks()
        {
            Bit b = new Bit();
            Assert.IsFalse(b.Cycle(false,false));
            Assert.IsFalse(b.Cycle(true,false));
            Assert.IsTrue(b.Cycle(true,true));
            Assert.IsTrue(b.Cycle(true,false));
            Assert.IsTrue(b.Cycle(false,false));
            Assert.IsFalse(b.Cycle(false,true));
            Assert.IsFalse(b.Cycle(true,false));
        }
        [TestMethod]
        public void RegisterWorks()
        {
            Register r = new Register(8);
            TestRegister(r);
        }
        void TestRegister(Register r)
        {
            CompareBitArray(new bool[] { true, true, true, true, true, true, true, true }, new bool[] { false, false,false,false,false,false,false,false },r,false);
            CompareBitArray(new bool[] { true, true, true, true, true, true, true, true }, new bool[] { true, true, true, true, true, true, true, true }, r, true);
            CompareBitArray(new bool[] { true, true, true, true, true, true, true, true }, new bool[] { true, true, true, true, true, true, true, true }, r, false);

            CompareBitArray(new bool[] { true, false, true, false, true, false, true, false }, new bool[] { true, true, true, true, true, true, true, true }, r, false);
            CompareBitArray(new bool[] { true, false, true, false, true, false, true, false }, new bool[] { true, false, true, false, true, false, true, false }, r, true);
            CompareBitArray(new bool[] { true, true, true, true, true, true, true, true }, new bool[] { true, false, true, false, true, false, true, false }, r, false);

        }

        void CompareBitArray(bool[] source, bool[] compareTo,Register r,bool load) {
            var output = r.Cycle(source, load);
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output[i], compareTo[i]);
            }
        }
        void TestRam(RAM r, int address)
        {
            CompareBitArray(new bool[] { true, true, true, true, true, true, true, true }, new bool[] { false, false, false, false, false, false, false, false }, r, false, address);
            CompareBitArray(new bool[] { true, true, true, true, true, true, true, true }, new bool[] { true, true, true, true, true, true, true, true }, r, true, address);
            CompareBitArray(new bool[] { true, true, true, true, true, true, true, true }, new bool[] { true, true, true, true, true, true, true, true }, r, false, address);

            CompareBitArray(new bool[] { true, false, true, false, true, false, true, false }, new bool[] { true, true, true, true, true, true, true, true }, r, false, address);
            CompareBitArray(new bool[] { true, false, true, false, true, false, true, false }, new bool[] { true, false, true, false, true, false, true, false }, r, true, address);
            CompareBitArray(new bool[] { true, true, true, true, true, true, true, true }, new bool[] { true, false, true, false, true, false, true, false }, r, false, address);

        }

        void CompareBitArray(bool[] source, bool[] compareTo, RAM r, bool load, int address)
        {
            var output = r.Cycle(source, load,address);
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output[i], compareTo[i]);
            }
        }
        [TestMethod]
        public void RAMWorks()
        {
            RAM r = new RAM(8,8);
            TestRam(r, 0);
            //reset
            CompareBitArray(new bool[] { false, false, false, false, false, false, false, false }, new bool[] { false, false, false, false, false, false, false, false }, r, true, 0);
            TestRam(r, 0);
            TestRam(r, 1);
            CompareBitArray(new bool[] { false, false, false, false, false, false, false, false }, new bool[] { false, false, false, false, false, false, false, false }, r, true, 1);
            TestRam(r, 1);
            TestRam(r, 2);
            TestRam(r, 3);
            TestRam(r, 4);
            TestRam(r, 5);
            TestRam(r, 6);
            TestRam(r, 7);
        }
        [TestMethod]
        public void RAM8Works()
        {
            Ram8 r = new Ram8(16);
            var input = new bool[]{false, false, false, false, false, false, false, false};
            var output = r.Cycle(input, true, new bool[] { false, false, false });
        }




        void CompareBitArray(bool[] source, bool[] compareTo)
        {
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], compareTo[i]);
            }
        }

    }
}
