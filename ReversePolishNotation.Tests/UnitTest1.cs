using System;
using System.Security.Cryptography.X509Certificates;
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

            double input10 = Program.RPN("1 1 + 1 - 3 * 6 /");
            Assert.AreEqual(input10, 0.5); 
        }


        [TestMethod]
        public void TestModulationOperations()
        {
            double input1 = Program.RPN("4 5 %");
            Assert.AreEqual(input1, 4);       
 
            double input2 = Program.RPN("5 4 %");
            Assert.AreEqual(input2, 1);
        }

        [TestMethod]
        public void TestSqrtOperations()
        {
            double input1 = Program.RPN("9 sqrt");
            Assert.AreEqual(input1, 3);   
            
            double input2 = Program.RPN("4 sqrt");
            Assert.AreEqual(input2, 2);     
            
            double input3 = Program.RPN("0 sqrt");
            Assert.AreEqual(input3, 0);
        }        
        
        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot take the square root of the negative number: -1!")]
        public void TestSqrtNegativeOperations() 
        {
            double input1 = Program.RPN("-1 sqrt");
        }

        [TestMethod]
        [ExpectedException(typeof (Exception), "Invalid operator entered: log!")]
        public void TestInvalidOperator()
        {
            double input = Program.RPN("2 log");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot use operator. Not enough operands available.")]
        public void TestNotEnoughValuesInStack()
        {
            double input = Program.RPN("+");
        }

        [TestMethod]
        [ExpectedException(typeof (DivideByZeroException))]
        public void TestDivisionByZero()
        {
            double input = Program.RPN("2 2 1E-13 * /");
        }
       
    }
}