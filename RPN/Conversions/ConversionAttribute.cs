namespace RPN.Conversions;

public class ConversionAttribute: Attribute
{
    public string Symbol { get; }

    public ConversionAttribute(string symbol)
    {
        Symbol = symbol;
    }
}