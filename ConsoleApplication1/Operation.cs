﻿using System;

namespace ReversePolishNotation
{
    public static class Operation
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
            const double epsilon = 1E-12;
            if (Math.Abs(b) < epsilon)
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
            return Math.Pow(a, b);
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