using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    /// <summary>
    /// This class represents a mathematical operator that takes two arguments.
    /// </summary>
    class BinaryOperation : IOperation
    {

        private readonly Func<double, double, double> _performCalculation;

        /// <summary>
        /// Initializes a new instance of the BinaryOperation class.
        /// </summary>
        /// <param name="performCalculation">Function that takes two arguments</param>
        public BinaryOperation(Func<double, double, double> performCalculation)
        {
            _performCalculation = performCalculation;
        }

        public double Execute(double arg1, params double[] argn)
        {
            return _performCalculation.Invoke(arg1, argn[0]);
        }
    }
}
