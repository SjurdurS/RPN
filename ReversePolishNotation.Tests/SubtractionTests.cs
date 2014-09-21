using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class SubtractionTests
    {
        [TestMethod]
        public void SubtractionTest1()
        {
            string input = "-1 1 -";
            double expectedResult = -2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void SubtractionTest2()
        {
            string input = "1 -1 -";
            double expectedResult = 2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void SubtractionTest3()
        {
            string input = "1 1 -";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void SubtractionTest4()
        {
            string input = "-1 -1 -";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void SubtractionTest5()
        {
            string input = "0 1 -";
            double expectedResult = -1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void SubtractionTest6()
        {
            string input = "1 0 -";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void SubtractionTest7()
        {
            string input = "0 0 -";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }
    }
}