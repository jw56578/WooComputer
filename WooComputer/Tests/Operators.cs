using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooComputer.Chips;
namespace Tests
{
    [TestClass]
    public class Operators
    {
        [TestMethod]
        public void HalfAddWorks()
        {
            var sum = WooComputer.Chips.Operators.HalfAdd(false, false);
            Assert.IsTrue(sum.Item1 == false && sum.Item2 == false);
            sum = WooComputer.Chips.Operators.HalfAdd(false, true);
            Assert.IsTrue(sum.Item1 == true && sum.Item2 == false);
            sum = WooComputer.Chips.Operators.HalfAdd(true,false);
            Assert.IsTrue(sum.Item1 == true && sum.Item2 == false);
            sum = WooComputer.Chips.Operators.HalfAdd(true, true);
            Assert.IsTrue(sum.Item1 == false && sum.Item2 == true);

        }
        [TestMethod]
        public void FullAddWorks()
        {
            var sum = WooComputer.Chips.Operators.FullAdd(false, false,false);
            Assert.IsTrue(sum.Item1 == false && sum.Item2 == false);
            sum = WooComputer.Chips.Operators.FullAdd(false, false, true);
            Assert.IsTrue(sum.Item1 == true && sum.Item2 == false);
            sum = WooComputer.Chips.Operators.FullAdd(false, true, false);
            Assert.IsTrue(sum.Item1 == true && sum.Item2 == false);
            sum = WooComputer.Chips.Operators.FullAdd(false, true, true);
            Assert.IsTrue(sum.Item1 == false && sum.Item2 == true);
            sum = WooComputer.Chips.Operators.FullAdd(true,false,false);
            Assert.IsTrue(sum.Item1 == true && sum.Item2 == false);
            sum = WooComputer.Chips.Operators.FullAdd(true, false, true);
            Assert.IsTrue(sum.Item1 == false && sum.Item2 == true);
            sum = WooComputer.Chips.Operators.FullAdd(true, true, false);
            Assert.IsTrue(sum.Item1 == false && sum.Item2 == true);
            sum = WooComputer.Chips.Operators.FullAdd(true, true, true);
            Assert.IsTrue(sum.Item1 == true && sum.Item2 == true);

        }
        [TestMethod]
        public void AddWorks()
        {
            var sum = WooComputer.Chips.Operators.Add(
                new bool[] { false, false, false, false, false, false, false, false },
                new bool[] { false, false, false, false, false, false, false, false });
            CompareBitArray(sum, new bool[] { false, false, false, false, false, false, false, false });
            sum = WooComputer.Chips.Operators.Add(
                new bool[] { false, false, false, false, false, false, false, true },
                new bool[] { false, false, false, false, false, false, false, false });
            CompareBitArray(sum, new bool[] { false, false, false, false, false, false, false, true });
            sum = WooComputer.Chips.Operators.Add(
                new bool[] { false, false, false, false, false, false, false, true },
                new bool[] { false, false, false, false, false, false, false, true });
            CompareBitArray(sum, new bool[] { false, false, false, false, false, false, true, false });
            //10001 + 11101 = 101110:
            sum = WooComputer.Chips.Operators.Add(
               new bool[] { false, false, false, true, false, false, false, true },
               new bool[] { false, false, false, true, true, true, false, true });
            CompareBitArray(sum, new bool[] { false, false, true, false, true, true, true, false });
            //11011 + 1001010 = 1100101
            sum = WooComputer.Chips.Operators.Add(
               new bool[] { false, false, false, true, true, false, true, true },
               new bool[] { false, true, false, false, true, false, true, false });
            CompareBitArray(sum, new bool[] { false, true, true, false, false, true, false, true });
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
