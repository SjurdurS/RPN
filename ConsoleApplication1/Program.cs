using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReversePolishNotation
{
    public class Program
    {

        /// <summary>
        /// List of available operators.
        /// <Key>The operator as a token.</Key>
        /// <value index="0">Enumerate value of the operator.</value>
        /// <value index="1">Number of operands the operator takes.</value>
        /// </summary>
        public static readonly Dictionary<string, object[]> availableOperators = new Dictionary<string, object[]>
        {
          // token                    Operator enum             n   
            {"+",       new object[] {Operator.Addition,        2}},
            {"-",       new object[] {Operator.Subtraction,     2}},
            {"*",       new object[] {Operator.Multiplication,  2}},
            {"/",       new object[] {Operator.Division,        2}},
            {"%",       new object[] {Operator.Modulation,      2}},
            {"^",       new object[] {Operator.Exponentiation,  2}},
            {"sqrt",    new object[] {Operator.SquareRoot,      1}}
        };

        /// <summary>
        /// Reverse Polish Notation calculator.
        /// This method calculates the value of a postfix / Reverse Polish Notation (RPN) expression.
        /// </summary>
        /// <param name="postfix">Mathematical postfix expression.</param>
        /// <returns>Returns the value of the specified postfix expression.</returns>
        public static double RPN(string postfix)
        {

            Stack<double> stack = new Stack<double>();

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

                    Operator op = (Operator) availableOperators[token].GetValue(0);
                    int n = (int) availableOperators[token].GetValue(1);

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
        ///     Clean up the postfix string. There was a problem with hyphen and mathematical minus.
        ///     Also incase there are excessive space characters replace multiple white space characters with a single space.
        /// </summary>
        /// <param name="input">RPN</param>
        /// <returns>Cleaned postfix</returns>
        private static string InputCleaner(string input)
        {
            Regex.Replace(input, @"\s+", " ");
            Regex.Replace(input, "-", "–"); // Replace hyphen with minus
            return input;
        }

        private static Boolean IsOperator(string token)
        {
            return Operators.AvailableOperators.ContainsKey(token);
        }

        /// <summary>
        /// Convert infix to RPN.
        /// </summary>
        /// <param name="infix"></param>
        /// <returns></returns>
        private static string InfixToRPN(string infix)
        {
            return "";
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(RPN("5 1 2 + -"));
            Console.WriteLine(RPN("5 4 %"));
            Console.WriteLine(RPN("0 sqrt"));
        }
    }
}