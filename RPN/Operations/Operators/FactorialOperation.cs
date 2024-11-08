namespace RPN.Operations.Operators
{
    [Operation("!")]
    public class FactorialOperation : IOperation
    {
        public int? OperandCount => 1;
        
        public int Execute(params int[] operators)
        {
            if (operators.Length != 1)
                throw new ArgumentException("Factorial requires exactly 1 operand.");

            int number = operators[0];
            if (number < 0)
                throw new ArgumentException("Factorial is not defined for negative numbers.");

            return number <= 1 ? 1 : number * Execute(new int[] { number - 1 });
        }
    }
}