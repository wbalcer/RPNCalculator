using RPN;

public class Rpn
{
    private readonly RpnEvaluator _evaluator;

    public Rpn()
    {
        _evaluator = new RpnEvaluator();
    }

    public int EvalRpn(string input)
    {
        return _evaluator.EvalRpn(input);
    }
}