namespace RPN.Operations.Operators
{
    [Operation("*")]
    public class MultiplicationOperation : IOperation
    {
        public int? OperandCount => 2;

        public int Execute(params int[] operands)
        {
            if (operands.Length != OperandCount)
                throw new ArgumentException($"Multiplication requires exactly {OperandCount} operands.");

            return operands[0] * operands[1];
        }
    }
}