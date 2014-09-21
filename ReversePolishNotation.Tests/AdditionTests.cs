using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class AdditionTests
    {
        [TestMethod]
        public void AdditionTest1()
        {
            string input = "-1 1 +";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void AdditionTest2()
        {
            string input = "1 -1 +";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void AdditionTest3()
        {
            string input = "1 1 +";
            double expectedResult = 2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void AdditionTest4()
        {
            string input = "-1 -1 +";
            double expectedResult = -2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void AdditionTest5()
        {
            string input = "0 1 +";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void AdditionTest6()
        {
            string input = "1 0 +";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void AdditionTest7()
        {
            string input = "0 0 +";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }
    }
}