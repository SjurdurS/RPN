﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class VariousOtherCases
    {
        [TestMethod]
        public void NoOperator_1_Operand_Test1()
        {
            string input = "1";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        
        
        [TestMethod]
        public void NoOperator_1_Operand_Test2()
        {
            string input = "999";
            double expectedResult = 999;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }
  
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid operator entered: datCosinus!")]
        public void Invalid_Operator_Test1()
        {
            string input = "24 datCosinus";
            double result = Program.RPN(input);
        }
    
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid operator entered: pows!")]
        public void Invalid_Operator_Test2()
        {
            string input = "15 2 pows";
            double result = Program.RPN(input);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Not_Enough_Operands_Test1()
        {
            string input = "1 +";
            double result = Program.RPN(input);        
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Not_Enough_Operands_Test2()
        {
            string input = "1 3 + + -";
            double result = Program.RPN(input);        
        }
    }
}
