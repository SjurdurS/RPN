using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReversePolishNotation
{
    public class Program
    {
        private static readonly Stack<double> stack = new Stack<double>();


        public static double RPN(string input)
        {
            if (input == "")
            {
                return 0.0;
            }
            input = InputCleaner(input);

            string[] tokens = input.Split(' ');


            foreach (string token in tokens)
            {
                double num;
                if (double.TryParse(token, out num))
                {
                    stack.Push(num);
                }
                else if (IsOperator(token))
                {
                    if (token == "+")
                    {
                        if (stack.Count < 2)
                        {
                            throw new Exception("Cannot use operator. Stack is empty.");
                        }

                        double a = stack.Pop();
                        double b = stack.Pop();
                        stack.Push(Operators.Addition(a, b));
                    }
                    else if (token == "-")
                    {
                        if (stack.Count < 2)
                        {
                            throw new Exception("Cannot use operator. Stack is empty.");
                        }

                        double a = stack.Pop();
                        double b = stack.Pop();
                        stack.Push(Operators.Subtraction(b, a));
                    }
                    else if (token == "*")
                    {
                        if (stack.Count < 2)
                        {
                            throw new Exception("Cannot use operator. Stack is empty.");
                        }

                        double a = stack.Pop();
                        double b = stack.Pop();
                        stack.Push(Operators.Multiplication(a, b));
                    }
                    else if (token == "/")
                    {
                        if (stack.Count < 2)
                        {
                            throw new Exception("Cannot use operator. Stack is empty.");
                        }

                        double a = stack.Pop();
                        double b = stack.Pop();
                        stack.Push(Operators.Division(b, a));
                    }
                }

                else
                {
                    throw new Exception("Invalid operator found!");
                }
            }

            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new Exception("Too many values left in the stack!");

            }
            
        }

        /// <summary>
        ///     Check is a token is one of the valid operators.
        /// </summary>
        /// <param name="input">RPN</param>
        /// <returns>True if the token is a valid operator and false otherwise.</returns>
        public static bool IsOperator(string token)
        {
            return (token == "+" || token == "-" || token == "*" || token == "/");
        }

        /// <summary>
        ///     Clean up the input string. There was a problem with hyphen and mathematical minus.
        ///     Also incase there are excessive space characters replace multiple white space characters with a single space.
        /// </summary>
        /// <param name="input">RPN</param>
        /// <returns>Cleaned input</returns>
        public static string InputCleaner(string input)
        {
            Regex.Replace(input, @"\s+", " ");
            Regex.Replace(input, "-", "–"); // Replace hyphen with minus
            return input;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(RPN("5 1 2 + 4 * + 3 -"));
            Console.WriteLine(RPN(""));
            Console.WriteLine(RPN("1"));
        }
    }
}