using System.Reflection;
using RPN.Conversions;
namespace RPN;

public class ParserDiscoverer
{
    public Dictionary<string, IConverter> DiscoverParsers()
    {
        var parsers = new Dictionary<string, IConverter>();
        var conversionTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IConverter).IsAssignableFrom(t) && t.GetCustomAttribute<ConversionAttribute>() != null);
        foreach (var conversionType in conversionTypes)
        {
            var attribute = conversionType.GetCustomAttribute<ConversionAttribute>();
            if (attribute != null)
            {
                var conversionInstance = (IConverter)Activator.CreateInstance(conversionType);
                parsers[attribute.Symbol] = conversionInstance;
            }
        }

        return parsers;
    }
}