using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class SquareRootTests
    {
        [TestMethod]
        public void Sqrt_Squares_Test0()
        {
            string input = "0 sqrt";
            double expectedResult = 0;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Sqrt_Squares_Test1()
        {
            string input = "1 sqrt";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Sqrt_Squares_Test2()
        {
            string input = "4 sqrt";
            double expectedResult = 2;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Sqrt_Squares_Test3()
        {
            string input = "9 sqrt";
            double expectedResult = 3;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Sqrt_Squares_Test4()
        {
            string input = "16 sqrt";
            double expectedResult = 4;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Sqrt_FractionResult_Test1()
        {
            double epsilon = 1E-14;
            string input = "2 sqrt";
            double expectedResult = 1.4142135623730950488016887242097;
            double result = Program.RPN(input);

            double difference = Math.Abs(result - expectedResult);
            Assert.IsTrue(difference < epsilon);
        }
        [TestMethod]
        public void Sqrt_FractionResult_Test2()
        {
            double epsilon = 1E-14;
            string input = "3 sqrt";
            double expectedResult = 1.7320508075688772935274463415059;
            double result = Program.RPN(input);

            double difference = Math.Abs(result - expectedResult);
            Console.WriteLine(difference);
            Assert.IsTrue(difference < epsilon);
        }

        [TestMethod]
        public void Sqrt_FractionResult_Test3()
        {
            double epsilon = 1E-14;
            string input = "5 sqrt";
            double expectedResult = 2.2360679774997896964091736687313;
            double result = Program.RPN(input);

            double difference = Math.Abs(result - expectedResult);
            Assert.IsTrue(difference < epsilon);
        }

        [TestMethod]
        public void Sqrt_FractionInput_Test1()
        {
            double epsilon = 1E-14;
            string input = "0.5 sqrt";
            double expectedResult = 0.70710678118654752440084436210485;
            double result = Program.RPN(input);

            double difference = Math.Abs(result - expectedResult);
            Assert.IsTrue(difference < epsilon);
        }
        [TestMethod]
        public void Sqrt_FractionInput_Test2()
        {
            double epsilon = 1E-14;
            string input = "1.5 sqrt";
            double expectedResult = 1.2247448713915890490986420373529;
            double result = Program.RPN(input);

            double difference = Math.Abs(result - expectedResult);
            Assert.IsTrue(difference < epsilon);
        }
        [TestMethod]
        public void Sqrt_FractionInput_Test3()
        {
            double epsilon = 1E-14;
            string input = "2.5 sqrt";
            double expectedResult = 1.5811388300841896659994467722164;
            double result = Program.RPN(input);

            double difference = Math.Abs(result - expectedResult);
            Assert.IsTrue(difference < epsilon);
        }

        /*
        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Cannot take the square root of the negative number: -1")]
        public void Sqrt_NegativeInput_Test()
        {
            string input = "-1 sqrt";
            double result = Program.RPN(input);
        }
         */
    }

}