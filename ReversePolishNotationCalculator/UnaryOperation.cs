using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    /// <summary>
    /// This class represents a mathematical operator that takes one argument.
    /// </summary>
    class UnaryOperation : IOperation
    {

        private readonly Func<double, double> _performCalculation;

        /// <summary>
        /// Initializes a new instance of the UnaryOperation class.
        /// </summary>
        /// <param name="performCalculation">Function that takes one argument</param>
        public UnaryOperation(Func<double, double> performCalculation)
        {
            _performCalculation = performCalculation;
        }


        public double Execute(double arg1, params double[] argn)
        {
            return _performCalculation.Invoke(arg1);
        }
    }
}
