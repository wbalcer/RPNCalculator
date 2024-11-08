public interface IOperation
{
    int? OperandCount { get; }
    int Execute(params int[] operands);
}