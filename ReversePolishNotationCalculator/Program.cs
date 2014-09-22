using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ReversePolishNotation
{

    // Der skal laves et felt der hedder "AvailableOperators" af type Dictionary
    // --Her--

    /// <summary>
    ///     This class calculates a Reverse Polish Notation expression (also known as postfix).
    /// </summary>
    /// <author>Sjúrður í Sandagerði</author>
    /// <author>Ans Uddin</author>
    /// <author>Nicolai Thorndahl</author>
    public class Program
    {

        
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
                    // -------------

                    // Mangler noget kode her 


                    // -------------

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
            throw new Exception("Too many operands on stack!");
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
            try
            {
                Console.WriteLine(RPN("1 sqrt"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}