using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooComputer.Chips;

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
    }
}
