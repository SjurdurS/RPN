using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    class BinaryOperation : IOperation
    {

        private readonly Func<double, double, double> _performCalculation;

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
