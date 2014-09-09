using System;

namespace ReversePolishNotation
{
    /// <summary>
    /// This class represents an operation.
    /// </summary>
    public static class Operation
    {
        public static double Multiplication(double x, double y)
        {
            return x * y;
        }
        
        public static double Addition(double x, double y)
        {
            return x + y;
        }

        public static double Subtraction(double x, double y)
        {
            return x - y;
        }
        
        public static double Division(double x, double y)
        {
            const double epsilon = 1E-12;
            if (Math.Abs(y) < epsilon)
            {
                throw new DivideByZeroException();
            }
            return x / y;
        }
        public static double Modulation(double x, double y)
        {
            return x % y;
        }

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="x">A double-precision floating-point number to be raised to a power.</param>
        /// <param name="y">A double-precision floating-point number that specifies a power.</param>
        /// <returns>The number x raised to the power y.</returns>
        public static double Exponentiation(double x, double y)
        {
            return Math.Pow(x, y);
        }

        /// <summary>
        /// Returns the square root of a specified number.
        /// </summary>
        /// <param name="x">The number whose square root is to be found.</param>
        /// <returns>The square root of x.</returns>
        public static double Sqrt(double x)
        {
            if (x < 0)
            {
                throw new Exception("Cannot take the square root of the negative number: " + x + "!");
            }

            return Math.Sqrt(x);
        }
    }
}