using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class MultipleOperatorsTests
    {
        [TestMethod]
        public void TwoOperators_Test1()
        {
            string input = "5 5 2 * +";
            double expectedResult = 15;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        
        
        [TestMethod]
        public void TwoOperators_Test2()
        {
            string input = "5 5 * 2 +";
            double expectedResult = 27;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        
        
        [TestMethod]
        public void ThreeOperators_Test1()
        {
            string input = "5 5 5 2 * + -";
            double expectedResult = -10;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }     
        
        [TestMethod]
        public void ThreeOperators_Test2()
        {
            string input = "7 5 - 2 * 5 +";
            double expectedResult = 9;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }
 
        [TestMethod]
        public void FourOperators_Test1()
        {
            string input = "10 7 5 - 2 * 5 + power";
            double expectedResult = 1000000000;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        

        [TestMethod]
        public void FourOperators_Test2()
        {
            string input = "7 5 - 2 * 5 + sqrt";
            double expectedResult = 3;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }
    }
}
