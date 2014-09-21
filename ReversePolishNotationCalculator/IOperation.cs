using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    public interface IOperation
    {
        double Execute(double arg1, params double[] argn);   
    }
}
