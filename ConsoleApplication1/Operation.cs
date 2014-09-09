using System;

namespace ReversePolishNotation
{
    internal static class Operation
    {
        public static double Multiplication(double a, double b)
        {
            return a * b;
        }
        
        public static double Addition(double a, double b)
        {
            return a + b;
        }

        public static double Subtraction(double a, double b)
        {
            return a - b;
        }

        public static double Division(double a, double b)
        {
            if (Math.Abs(b) < 0.00000001)
            {
                throw new DivideByZeroException();
            }
            return a / b;
        }
        public static double Modulation(double a, double b)
        {
            return a % b;
        }
        public static double Exponentiation(double a, double b)
        {
            return Math.Pow(b, a);
        }        
        public static double Sqrt(double a)
        {
            if (a < 0)
            {
                throw new Exception("Cannot take the square root of the negative number: " + a + "!");
            }

            return Math.Sqrt(a);
        }
    }
}