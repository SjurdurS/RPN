using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReversePolishNotation.Tests
{
    [TestClass]
    public class PowerTests
    {

        [TestMethod]
        public void Power_Squares_Test1()
        {
            string input = "2 2 power";
            double expectedResult = 4;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }    

        [TestMethod]
        public void Power_Squares_Test2()
        {
            string input = "3 2 power";
            double expectedResult = 9;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }    

        [TestMethod]
        public void Power_Squares_Test3()
        {
            string input = "4 2 power";
            double expectedResult = 16;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }    

        [TestMethod]
        public void Power_Squares_Test4()
        {
            string input = "5 2 power";
            double expectedResult = 25;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }   

        [TestMethod]
        public void Power_Cubes_Test1()
        {
            string input = "2 3 power";
            double expectedResult = 8;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }    
        [TestMethod]
        public void Power_Cubes_Test2()
        {
            string input = "3 3 power";
            double expectedResult = 27;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }    
        [TestMethod]
        public void Power_Cubes_Test3()
        {
            string input = "4 3 power";
            double expectedResult = 64;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Power_Cubes_Test4()
        {
            string input = "5 3 power";
            double expectedResult = 125;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Power_Fractional_Test1()
        {
            double epsilon = 1E-14;
            string input = "2 2.3 power";
            double expectedResult = 4.924577653379665137997572276671;
            
            double result = Program.RPN(input);

            double difference = Math.Abs(result - expectedResult);
            Assert.IsTrue(difference < epsilon);
        } 
        
        [TestMethod]
        public void Power_Fractional_Test2()
        {
            double epsilon = 1E-14;
            string input = "2.1 2.1 power";
            double expectedResult = 4.74963809174224171568853059421;
            double result = Program.RPN(input);

            double difference = Math.Abs(result - expectedResult);
            Assert.IsTrue(difference < epsilon);
        }

        [TestMethod]
        public void Power_Fractional_Test3()
        {
            string input = "3.14 2 power";
            double expectedResult = 9.8596;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }    

        [TestMethod]
        public void Power_ZeroPower_Test1()
        {
            string input = "0 0 power";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        
        
        [TestMethod]
        public void Power_ZeroPower_Test2()
        {
            string input = "1 0 power";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        
        
        [TestMethod]
        public void Power_ZeroPower_Test3()
        {
            string input = "-1 0 power";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        
        
        [TestMethod]
        public void Power_NegativePower_Test1()
        {
            string input = "-1 -1 power";
            double expectedResult = -1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }        

        [TestMethod]
        public void Power_NegativePower_Test2()
        {
            string input = "1 -1 power";
            double expectedResult = 1;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Power_NegativePower_Test3()
        {
            string input = "2 -1 power";
            double expectedResult = 0.5;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Power_NegativePower_Test4()
        {
            string input = "2 -2 power";
            double expectedResult = 0.25;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Power_NegativePower_PositiveInfinity_Test1()
        {
            string input = "0 -1 power";
            double expectedResult = Double.PositiveInfinity;
            double result = Program.RPN(input);
            Assert.AreEqual(result, expectedResult);
        }         
        
    }
}
