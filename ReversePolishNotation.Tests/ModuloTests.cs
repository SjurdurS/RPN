using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class ModuloTests
    {
        /*
        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Modulo by zero")]
        public void Modulo_ModuloByZero_Test1()
        {
            string input = "0 0 %";
            double result = Program.RPN(input);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Modulo by zero")]
        public void Modulo_ModuloByZero_Test2()
        {
            string input = "1 0 %";
            double result = Program.RPN(input);
        }
         * */

        [TestMethod]
        public void Modulo_Test1()
        {
            string input = "0 1 %";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Modulo_Test2()
        {
            string input = "1 1 %";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Modulo_Test3()
        {
            string input = "-1 1 %";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        
        
        [TestMethod]
        public void Modulo_Test4()
        {
            string input = "-1 -1 %";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Modulo_X_less_than_Y_Test1()
        {
            string input = "2 5 %";
            double expectedResult = 2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Modulo_X_less_than_Y_Test2()
        {
            string input = "2 -5 %";
            double expectedResult = 2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Modulo_X_less_than_Y_Test3()
        {
            string input = "-2 -5 %";
            double expectedResult = -2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Modulo_X_less_than_Y_Test4()
        {
            string input = "-2 5 %";
            double expectedResult = -2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }
        [TestMethod]
        public void Modulo_X_greater_than_Y_Test1()
        {
            string input = "5 3 %";
            double expectedResult = 2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Modulo_X_greater_than_Y_Test2()
        {
            string input = "5 -3 %";
            double expectedResult = 2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Modulo_X_greater_than_Y_Test3()
        {
            string input = "-5 -3 %";
            double expectedResult = -2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Modulo_X_greater_than_Y_Test4()
        {
            string input = "-5 3 %";
            double expectedResult = -2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }
    }
}