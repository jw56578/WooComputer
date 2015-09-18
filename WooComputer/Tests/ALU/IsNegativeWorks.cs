using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{

    public partial class ALU
    {
        [TestMethod]
        public void IsNegativeWorks()
        {
            //Item3
            var output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(13, 16)
                , Functions.GetBitArrayFromInteger(1, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsTrue(output.Item3);

            output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(2, 16)
                , Functions.GetBitArrayFromInteger(1, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsTrue(output.Item3);

            output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(3, 16)
                , Functions.GetBitArrayFromInteger(1, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsTrue(output.Item3);


            output = alu.Cycle(
                   Functions.GetBitArrayFromInteger(3333, 16)
                , Functions.GetBitArrayFromInteger(1, 16)
                , false
                , false
                , false
                , true
                , true
                , true);
            Assert.IsTrue(output.Item3);


            output = alu.Cycle(
                  Functions.GetBitArrayFromInteger(1, 16)
               , Functions.GetBitArrayFromInteger(1, 16)
               , false
               , false
               , false
               , true
               , true
               , true);
            Assert.IsFalse(output.Item3);

            output = alu.Cycle(
                Functions.GetBitArrayFromInteger(1, 16)
             , Functions.GetBitArrayFromInteger(4441, 16)
             , false
             , false
             , false
             , true
             , true
             , true);
            Assert.IsFalse(output.Item3);
        }
    }
}