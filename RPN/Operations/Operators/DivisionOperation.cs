namespace RPN.Operations.Operators
{    
    [Operation("/")]
    public class DivisionOperation : IOperation
    {
        public int? OperandCount => 2;
        
        public int Execute(params int[] operators)
        {
            if (operators[0] == 0)
                throw new InvalidDataException("Cannot divide by zero.");
            if (operators.Length != 2)
                throw new ArgumentException("Division requires exactly 2 operands.");

            return operators[0] / operators[1];
        }
    }
}