using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class FunctionTests
    {
        [TestMethod]
        public void CanConvertBitArrayToInt()
        {

            var zero = Functions.GetIntegerFromBitArray(new bool[16]);
            Assert.AreEqual(zero, 0);

            var one = Functions.GetIntegerFromBitArray(new bool[]{false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true});
            Assert.AreEqual(one, 1);
        }
    }
}
