using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void DivisionTest1()
        {
            string input = "1 1 /";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        
        
        [TestMethod]
        public void DivisionTest2()
        {
            string input = "10 10 /";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        

        [TestMethod]
        public void DivisionTest3()
        {
            string input = "-10 -10 /";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void DivisionTest4()
        {
            string input = "-10 10 /";
            double expectedResult = -1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void DivisionTest5()
        {
            string input = "10 -10 /";
            double expectedResult = -1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void DivisionTest6()
        {
            string input = "4 -2 /";
            double expectedResult = -2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }
        [TestMethod]
        public void DivisionTest7()
        {
            string input = "-2 -4 /";
            double expectedResult = 0.5;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void DivisionTest8()
        {
            string input = "100000 10 /";
            double expectedResult = 10000;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void DivisionTest9()
        {
            string input = "0 1 /";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Division_DivisionByZero_Test1()
        {
            string input = "1 0 /";
            double result = Program.RPN(input);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Division_DivisionByZero_ValueSmallerThanEpsilon_Test2()
        {
            string input = "0 1E-15 /";
            double result = Program.RPN(input);
        }
    }
}
