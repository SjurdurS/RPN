using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReversePolishNotation
{
    public enum Operator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Modulation,
        Exponentiation,
        SquareRoot
    }

    public class Program
    {
        

        private static readonly Dictionary<string, object[]> Operators = new Dictionary<string, object[]>
        {
            // token             Operator type     n   
            {"+", new object[] {Operator.Addition, 2}},
            {"-", new object[] {Operator.Subtraction, 2}},
            {"*", new object[] {Operator.Multiplication, 2}},
            {"/", new object[] {Operator.Division, 2}},
            {"%", new object[] {Operator.Modulation, 2}},
            {"^", new object[] {Operator.Exponentiation, 2}},
            {"sqrt", new object[] {Operator.SquareRoot, 1}}
        };

        public static double RPN(string input)
        {

            Stack<double> stack = new Stack<double>();

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
                else if (Operators.ContainsKey(token))
                {
                    
                    Operator op = (Operator)Operators[token].GetValue(0);
                    int n = (int)Operators[token].GetValue(1);

                    if (stack.Count < n)
                    {
                        throw new Exception("Cannot use operator. Not enough values in the stack.");
                    }

                    if (n == 1)
                    {
                        double a = stack.Pop();

                        switch (op)
                        {
                            case Operator.SquareRoot:
                                {

                                    stack.Push(Operation.Sqrt(a));
                                    break;
                                }
                        }

                    }
                    else if (n == 2)
                    {
                        double a = stack.Pop();
                        double b = stack.Pop();

                        switch (op)
                        {
                            case Operator.Addition:
                                {
                                    stack.Push(Operation.Addition(a, b));
                                    break;
                                }
                            case Operator.Subtraction:
                                {
                                    stack.Push(Operation.Subtraction(b, a));
                                    break;
                                }
                            case Operator.Multiplication:
                                {
                                    stack.Push(Operation.Multiplication(a, b));
                                    break;
                                }
                            case Operator.Division:
                                {
                                    stack.Push(Operation.Division(b, a));
                                    break;
                                }
                            case Operator.Modulation:
                                {
                                    stack.Push(Operation.Modulation(a, b));
                                    break;
                                }
                            case Operator.Exponentiation:
                                {
                                    stack.Push(Operation.Exponentiation(a, b));
                                    break;
                                }

                        }
                    }


                }
                else
                {
                    throw new Exception("Invalid operator entered: " + token + "!");
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
        private static bool IsOperator(string token)
        {
            return (token == "+" || token == "-" || token == "*" || token == "/");
        }

        /// <summary>
        ///     Clean up the input string. There was a problem with hyphen and mathematical minus.
        ///     Also incase there are excessive space characters replace multiple white space characters with a single space.
        /// </summary>
        /// <param name="input">RPN</param>
        /// <returns>Cleaned input</returns>
        private static string InputCleaner(string input)
        {
            Regex.Replace(input, @"\s+", " ");
            Regex.Replace(input, "-", "–"); // Replace hyphen with minus
            return input;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(RPN("5 1 2 + -"));
            Console.WriteLine(RPN("5 4 %"));
            Console.WriteLine(RPN("0 sqrt"));
        }
    }
}