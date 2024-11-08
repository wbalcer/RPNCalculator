namespace RPN.Conversions;

[Conversion("D")]
public class DecConverter : IConverter
{
    public bool Matches(string input) => input.StartsWith("D");

    public int Parse(string input) => Convert.ToInt32(input.TrimStart('D'), 10);
}