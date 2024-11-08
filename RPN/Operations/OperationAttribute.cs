namespace RPN.Operations;

public class OperationAttribute: Attribute
{
    public string Symbol { get; }

    public OperationAttribute(string symbol)
    {
        Symbol = symbol;
    }
}