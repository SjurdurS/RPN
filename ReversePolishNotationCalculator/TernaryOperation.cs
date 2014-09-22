using System;

namespace ReversePolishNotation
{
    internal class TernaryOperation : IOperation
    {
        private readonly Func<double, double, double, double> _performCalculation;

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