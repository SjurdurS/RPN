using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class MultiplicationTests
    {
        [TestMethod]
        public void MultiplicationTest1()
        {
            string input = "0 0 *";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        
        
        [TestMethod]
        public void MultiplicationTest2()
        {
            string input = "1 0 *";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }  
      
        [TestMethod]
        public void MultiplicationTest3()
        {
            string input = "0 1 *";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }  
    
        [TestMethod]
        public void MultiplicationTest4()
        {
            string input = "1 1 *";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }  
    
        [TestMethod]
        public void MultiplicationTest5()
        {
            string input = "2 1 *";
            double expectedResult = 2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }    

        [TestMethod]
        public void MultiplicationTest6()
        {
            string input = "1 2 *";
            double expectedResult = 2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }    

        [TestMethod]
        public void MultiplicationTest7()
        {
            string input = "2 2 *";
            double expectedResult = 4;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void MultiplicationTest8()
        {
            string input = "-2 -2 *";
            double expectedResult = 4;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void MultiplicationTest9()
        {
            string input = "-2 2 *";
            double expectedResult = -4;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void MultiplicationTest10()
        {
            string input = "-100 100 *";
            double expectedResult = -10000;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }
    }
}
