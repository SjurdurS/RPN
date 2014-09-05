using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class RPNTest
    {
        [TestMethod]
        public void TestEmptyAndSingle()
        {
            double input1 = Program.RPN("");
            Assert.AreEqual(input1, 0);

            double input2 = Program.RPN("5");
            Assert.AreEqual(input2, 5);
        }

        [TestMethod]
        public void TestOperations()
        {
            double input3 = Program.RPN("5 5 +");
            Assert.AreEqual(input3, 10);

            double input4 = Program.RPN("5 5 -");
            Assert.AreEqual(input4, 0);

            double input5 = Program.RPN("5 5 *");
            Assert.AreEqual(input5, 25);

            double input6 = Program.RPN("5 5 /");
            Assert.AreEqual(input6, 1);
        }

        [TestMethod]
        public void TestComplexOperations()
        {
            double input7 = Program.RPN("5 5 2 * +");
            Assert.AreEqual(input7, 15);

            double input8 = Program.RPN("5 5 / 2 + 3 -");
            Assert.AreEqual(input8, 0);

            double input9 = Program.RPN("5 1 2 + 4 * + 3 -");
            Assert.AreEqual(input9, 14); 
        }
    }
}