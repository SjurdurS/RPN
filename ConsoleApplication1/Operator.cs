namespace ReversePolishNotation
{
    /// <summary>
    /// This class represents an operator.
    /// Each operator has a type and a number of operands it needs.
    /// </summary>
    /// <author>Sjúrður í Sandagerði</author>
    /// <author>Ans Uddin</author>
    /// <author>Nicolai Thorndahl</author>
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