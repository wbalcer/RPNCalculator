using RPN.Conversions;

namespace RPN;

public class NumberParser
{
    private readonly Dictionary<string, IConverter> _converters;

    public NumberParser()
    {
        var discoverer = new ParserDiscoverer();
        _converters = discoverer.DiscoverParsers();
    }

    public int ParseNumber(string token)
    {
        var symbol = token[0].ToString();
        if (_converters.ContainsKey(symbol))
        {
            return _converters[symbol].Parse(token);
        }
        throw new InvalidOperationException($"Unrecognized token: {token}");
    }
}
