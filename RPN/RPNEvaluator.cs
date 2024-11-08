namespace RPN;

public class RpnEvaluator
{
    private readonly MyStack<int> _operators = new MyStack<int>();
    private readonly Dictionary<string, IOperation> _operations;
    private readonly NumberParser _numberParser;
    private readonly OperationExecutor _operationExecutor;

    public RpnEvaluator()
    {
        var discoverer = new OperationDiscoverer();
        _operations = discoverer.DiscoverOperations();
        _numberParser = new NumberParser();
        _operationExecutor = new OperationExecutor(_operators, _operations);
    }

    public int EvalRpn(string input)
    {
        var splitInput = input.Split(' ');
        foreach (var op in splitInput)
        {
            if (_operations.ContainsKey(op))
            {
                _operationExecutor.ExecuteOperation(op);
            }
            else
            {
                var parsedNumber = _numberParser.ParseNumber(op);
                _operators.Push(parsedNumber);
            }
        }
        
        var result = _operators.Pop();
        if (_operators.IsEmpty)
        {
            return result;
        }
        throw new InvalidOperationException("Invalid RPN expression: The stack should be empty after processing.");
    }
}
