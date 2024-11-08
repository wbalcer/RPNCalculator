namespace RPN.Conversions;

[Conversion ("O")]
public class OctConverter : IConverter
{
    public bool Matches(string input) => input.StartsWith("O");
    public int Parse(string input) => Convert.ToInt32(input.TrimStart('O'), 8);
}