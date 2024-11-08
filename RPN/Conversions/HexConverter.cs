namespace RPN.Conversions;

[Conversion("#")]
public class HexConverter : IConverter
{
    public bool Matches(string input) => input.StartsWith("#");
    
    public int Parse(string input) => Convert.ToInt32(input.TrimStart('#'), 16);
}