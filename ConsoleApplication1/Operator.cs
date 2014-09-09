namespace ReversePolishNotation
{
    /// <summary>
    /// This class represents an operator.
    /// </summary>
    public class Operator
    {
        public readonly OperatorType OperatorType;
        public readonly int NumOfOperands;

        /// <summary>
        /// Instantiates a new operator.
        /// </summary>
        /// <param name="operatorType">The type of the operator.</param>
        /// <param name="numOfOperands">The number of operands the operator takes.</param>
        public Operator(OperatorType operatorType, int numOfOperands)
        {
            this.OperatorType = operatorType;
            this.NumOfOperands = numOfOperands;
        }
    }
}