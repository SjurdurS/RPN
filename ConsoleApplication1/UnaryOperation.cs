using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    class UnaryOperation : IOperation
    {

        private readonly Func<double, double> _performCalculation;

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
