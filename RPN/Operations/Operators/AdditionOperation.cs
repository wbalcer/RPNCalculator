namespace RPN.Operations.Operators
{
    [Operation("+")]
    public class AdditionOperation : IOperation
    {
        public int? OperandCount => 2;

        public int Execute(params int[] operands)
        {
            if (operands.Length != OperandCount)
                throw new ArgumentException($"Addition requires exactly {OperandCount} operands.");

            return operands[0] + operands[1];
        }
    }
}