using System;

namespace ReversePolishNotation
{
    /// <summary>
    /// This class represents a mathematical operator that takes three arguments.
    /// </summary>
    internal class TernaryOperation : IOperation
    {
        private readonly Func<double, double, double, double> _performCalculation;

        /// <summary>
        /// Initializes a new instance of the TernaryOperation class.
        /// </summary>
        /// <param name="performCalculation">Delegate that takes three arguments</param>
        public TernaryOperation(Func<double, double, double, double> performCalculation)
        {
            _performCalculation = performCalculation;
        }


        public double Execute(double arg1, params double[] argn)
        {
            return _performCalculation.Invoke(arg1, argn[0], argn[1]);
        }
    }

}