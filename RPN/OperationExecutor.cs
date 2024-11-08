namespace RPN;

public class OperationExecutor
{
    private readonly MyStack<int> _operators;
    private readonly Dictionary<string, IOperation> _operations;

    public OperationExecutor(MyStack<int> operators, Dictionary<string, IOperation> operations)
    {
        _operators = operators;
        _operations = operations;
    }

    public void ExecuteOperation(string token)
    {
        var operation = _operations[token];
        var operandCount = operation.OperandCount;
        var operands = new List<int>();
        if (operandCount.HasValue)
        {
            try
            {
                for (int i = 0; i < operandCount; i++)
                {
                    operands.Add(_operators.Pop());
                }
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Not enough operands for operation '{token}'");
            }
        }
        else
        {
            while (_operators.Count > 0)
            {
                operands.Add(_operators.Pop());
            }
        }


        operands.Reverse();

        var result = operation.Execute(operands.ToArray());
        _operators.Push(result);
    }
}
