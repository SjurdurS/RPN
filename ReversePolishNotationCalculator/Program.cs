using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ReversePolishNotation
{
    /// <summary>
    ///     This class calculates a Reverse Polish Notation expression (also known as postfix).
    /// </summary>
    /// <author>Sjúrður í Sandagerði</author>
    /// <author>Ans Uddin</author>
    /// <author>Nicolai Thorndahl</author>
    public class Program
    {
        /// <summary>
        ///     List of available operators.
        ///     <Key>The operator as a token.</Key>
        ///     <value index="0">Enumerate value of the operator.</value>
        ///     <value index="1">Number of operands the operator takes.</value>
        /// </summary>
        private static readonly Dictionary<string, IOperation> AvailableOperators = new Dictionary<string, IOperation>
        {
            {"+", new BinaryOperation((x, y) => x + y)},
            {"-", new BinaryOperation((x, y) => x - y)},
            {"*", new BinaryOperation((x, y) => x * y)},
            {"/", new BinaryOperation((x, y) =>
                    {
                        const double epsilon = 1E-14;
                        if (Math.Abs(y) < epsilon) throw new DivideByZeroException();
                        return x/y;
                    })},
            {"%", new BinaryOperation((x, y) =>
                    {
                        const double epsilon = 1E-14;
                        if (Math.Abs(y) < epsilon) throw new ArgumentException("Modulo by zero");
                        return x%y;
                    })},
            {"power", new BinaryOperation((x, y) => Math.Pow(x, y))},
            {"sqrt", new UnaryOperation(x =>
            {
                if (x < 0)
                {
                    throw new ArgumentException("Cannot take the square root of the negative number: " + x);
                } else return Math.Sqrt(x);
            })},
            {"abs", new UnaryOperation(x => Math.Abs(x))}
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
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out num))
                {
                    stack.Push(num);
                }
                else if (IsOperator(token))
                {
                    IOperation operation = AvailableOperators[token];

                    try
                    {
                        if (operation is UnaryOperation)
                        {
                            double a = stack.Pop();
                            stack.Push(operation.Execute(a));
                        }
                        else if (operation is BinaryOperation)
                        {
                            double b = stack.Pop();
                            double a = stack.Pop();
                            stack.Push(operation.Execute(a, b));
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new InvalidOperationException(ex.Message);
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid operator entered: " + token + "!");
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
        /// <param name="postfix">postfix</param>
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
            Console.WriteLine(RPN("-1 sqrt"));
        }
    }
}