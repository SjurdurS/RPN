using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReversePolishNotation
{
    public class Program
    {
        /// <summary>
        ///     List of available operators.
        ///     <Key>The operator as a token.</Key>
        ///     <value index="0">Enumerate value of the operator.</value>
        ///     <value index="1">Number of operands the operator takes.</value>
        /// </summary>
        public static readonly Dictionary<string, Operator> AvailableOperators = new Dictionary<string, Operator>
        {
            {"+", new Operator(OperatorType.Addition, 2)},
            {"-", new Operator(OperatorType.Subtraction, 2)},
            {"*", new Operator(OperatorType.Multiplication, 2)},
            {"/", new Operator(OperatorType.Division, 2)},
            {"%", new Operator(OperatorType.Modulation, 2)},
            {"^", new Operator(OperatorType.Exponentiation, 2)},
            {"sqrt", new Operator(OperatorType.SquareRoot, 1)}
        };

        /// <summary>
        ///     Reverse Polish Notation calculator.
        ///     This method calculates the value of a postfix / Reverse Polish Notation (RPN) expression.
        /// </summary>
        /// <param name="postfix">Mathematical postfix expression.</param>
        /// <returns>Returns the value of the specified postfix expression.</returns>
        public static double RPN(string postfix)
        {
            var stack = new Stack<double>();

            if (postfix == "")
            {
                return 0.0;
            }

            postfix = InputCleaner(postfix);

            string[] tokens = postfix.Split(' ');


            foreach (string token in tokens)
            {
                double num;
                if (double.TryParse(token, out num))
                {
                    stack.Push(num);
                }
                else if (IsOperator(token))
                {
                    Operator op = AvailableOperators[token];
                    OperatorType operatorType = op.OperatorType;
                    int n = op.NumOfOperands;

                    if (stack.Count < n)
                    {
                        throw new Exception("Cannot use operator. Not enough operands available.");
                    }

                    if (n == 1)
                    {
                        double a = stack.Pop();

                        switch (operatorType)
                        {
                            case OperatorType.SquareRoot:
                            {
                                stack.Push(Operation.Sqrt(a));
                                break;
                            }
                        }
                    }
                    else if (n == 2)
                    {
                        double b = stack.Pop();
                        double a = stack.Pop();

                        switch (operatorType)
                        {
                            case OperatorType.Addition:
                            {
                                stack.Push(Operation.Addition(a, b));
                                break;
                            }
                            case OperatorType.Subtraction:
                            {
                                stack.Push(Operation.Subtraction(a, b));
                                break;
                            }
                            case OperatorType.Multiplication:
                            {
                                stack.Push(Operation.Multiplication(a, b));
                                break;
                            }
                            case OperatorType.Division:
                            {
                                stack.Push(Operation.Division(a, b));
                                break;
                            }
                            case OperatorType.Modulation:
                            {
                                stack.Push(Operation.Modulation(a, b));
                                break;
                            }
                            case OperatorType.Exponentiation:
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
            throw new Exception("Too many operands in the stack!");
        }

        /// <summary>
        ///     Clean up a postfix string. There was a problem with hyphen and mathematical minus.
        ///     Also in case there are excessive space characters replace
        ///     multiple white space characters with a single space character.
        /// </summary>
        /// <param name="input">postfix</param>
        /// <returns>Cleaned postfix</returns>
        private static string InputCleaner(string postfix)
        {
            Regex.Replace(postfix, @"\s+", " ");
            Regex.Replace(postfix, "-", "–"); // Replace hyphen with minus
            return postfix;
        }

        /// <summary>
        ///     Check if the
        /// </summary>
        /// <param name="token">Operator token</param>
        /// <returns>Returns true if the specified token is one of the available operators, and false otherwise</returns>
        private static Boolean IsOperator(string token)
        {
            return AvailableOperators.ContainsKey(token);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(RPN("5 1 2 + -"));
            Console.WriteLine(RPN("5 4 %"));
            Console.WriteLine(RPN("0 sqrt"));
        }
    }
}