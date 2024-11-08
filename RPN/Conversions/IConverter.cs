namespace RPN.Conversions;

public interface IConverter
{
    bool Matches(string input);
    int Parse(string input);
}