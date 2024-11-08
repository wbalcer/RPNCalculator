namespace RPN.Operations.Operators
{
    [Operation("$")]
    public class SummationOperation : IOperation
    { 
        public int? OperandCount => null;

        public int Execute(params int[] operands)
        {
            return operands.Sum();
        }
    }
}