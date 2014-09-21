using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class AbsoluteValueTests
    {
        [TestMethod]
        public void AbsoluteValue_Test1()
        {
            string input = "0 abs";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        
        
        [TestMethod]
        public void AbsoluteValue_Test2()
        {
            string input = "1 abs";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }    
    
        [TestMethod]
        public void AbsoluteValue_Test3()
        {
            string input = "-1 abs";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }       
 
        [TestMethod]
        public void AbsoluteValue_Test4()
        {
            string input = "-0 abs";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }
    }
}
