namespace RPN.Operations.Operators
{
    [Operation("-")]
    public class SubtractionOperation : IOperation
    {
        public int? OperandCount => 2;
        
        public int Execute(params int[] operators)
        {
            if (operators.Length != 2)
                throw new ArgumentException("Subtraction requires exactly 2 operands.");

            return operators[0] - operators[1];
        }
    }
}