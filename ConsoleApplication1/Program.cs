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
        private static readonly Stack<double> Stack = new Stack<double>();

        private static readonly Dictionary<string, object[]> Operators = new Dictionary<string, object[]>
        {
            // token                n   Operator type
            {"+", new object[] {2, Operator.Addition}},
            {"-", new object[] {2, Operator.Subtraction}},
            {"*", new object[] {2, Operator.Multiplication}},
            {"/", new object[] {2, Operator.Division}},
            {"%", new object[] {2, Operator.Modulation}},
            {"^", new object[] {2, Operator.Exponentiation}},
            {"sqrt", new object[] {1, Operator.SquareRoot}}
        };

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
                    Stack.Push(num);
                }
                else if (Operators.ContainsKey(token))
                {
                    int n = (int)Operators[token].GetValue(0);
                    Operator op = (Operator)Operators[token].GetValue(1);

                    if (Stack.Count < n)
                    {
                        throw new Exception("Cannot use operator. Not enough values in the stack.");
                    }

                    if (n == 1)
                    {
                        double a = Stack.Pop();

                        switch (op)
                        {
                            case Operator.SquareRoot:
                                {

                                    Stack.Push(Operation.Sqrt(a));
                                    break;
                                }
                        }

                    }
                    else if (n == 2)
                    {
                        double a = Stack.Pop();
                        double b = Stack.Pop();

                        switch (op)
                        {
                            case Operator.Addition:
                                {
                                    Stack.Push(Operation.Addition(a, b));
                                    break;
                                }
                            case Operator.Subtraction:
                                {
                                    Stack.Push(Operation.Subtraction(b, a));
                                    break;
                                }
                            case Operator.Multiplication:
                                {
                                    Stack.Push(Operation.Multiplication(a, b));
                                    break;
                                }
                            case Operator.Division:
                                {
                                    Stack.Push(Operation.Division(b, a));
                                    break;
                                }
                            case Operator.Modulation:
                                {
                                    Stack.Push(Operation.Modulation(a, b));
                                    break;
                                }
                            case Operator.Exponentiation:
                                {
                                    Stack.Push(Operation.Exponentiation(a, b));
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



            if (Stack.Count == 1)
            {
                return Stack.Pop();
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
            Console.WriteLine(RPN("5 2 ^ 2 +"));
            Console.WriteLine(RPN("5 4 %"));
            Console.WriteLine(RPN("0 sqrt"));
        }
    }
}