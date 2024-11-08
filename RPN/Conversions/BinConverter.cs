namespace RPN.Conversions;

[Conversion("B")]
public class BinConverter : IConverter
{
    public bool Matches(string input) => input.StartsWith("B");

    public int Parse(string input) => Convert.ToInt32(input.TrimStart('B'), 2);
}