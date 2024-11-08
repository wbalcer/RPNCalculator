namespace RPNTest;

[TestFixture]
public class RpnTest {
    private Rpn _sut;
    [SetUp]
    public void Setup() {
        _sut = new Rpn();
    }
    [Test]
    public void CheckIfTestWorks() {
        Assert.Pass();
    }

    [Test]
    public void CheckIfCanCreateSut() {
        Assert.That(_sut, Is.Not.Null);
    }

    [Test]
    public void SingleDecimalDigitOneInputOneReturn() {
        var result = _sut.EvalRpn("D1");

        Assert.That(result, Is.EqualTo(1));

    }
    [Test]
    public void SingleBinaryDigitOneInputOneReturn() {
        var result = _sut.EvalRpn("B1");

        Assert.That(result, Is.EqualTo(1));

    }
    [Test]
    public void SingleHexDigitOneInputOneReturn() {
        var result = _sut.EvalRpn("#1");

        Assert.That(result, Is.EqualTo(1));

    }
    [Test]
    public void SingleDecimalDigitOtherThanOneInputNumberReturn() {
        var result = _sut.EvalRpn("D2");

        Assert.That(result, Is.EqualTo(2));

    }
    [Test]
    public void SingleBinaryDigitOtherThanOneInputNumberReturn() {
        var result = _sut.EvalRpn("B10");

        Assert.That(result, Is.EqualTo(2));

    }
    [Test]
    public void SingleHexDigitOtherThanOneInputNumberReturn() {
        var result = _sut.EvalRpn("#2");

        Assert.That(result, Is.EqualTo(2));

    }

    [Test]
    public void SingleOctDigitOtherThanOneInputNumberReturn()
    {
        var result = _sut.EvalRpn("O11");
        
        Assert.That(result, Is.EqualTo(9));
    }
    [Test]
    public void TwoDigitsNumberInputNumberReturn() {
        var result = _sut.EvalRpn("D12");

        Assert.That(result, Is.EqualTo(12));

    }
    [Test]
    public void TwoNumbersGivenWithoutOperator_ThrowsException() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("#1 #2"));

    }
    [Test]
    public void UnsupportedOperation_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("#1 #2 ?"));
    }

    [Test]
    public void NotEnoughOperands_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("D10 +"));
    }
    [Test]
    public void UnsupportedParser_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("Z2 !"));
    }
    [Test]
    public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("B1 #2 +");

        Assert.That(result, Is.EqualTo(3));
    }
    [Test]
    public void OperatorTimes_MultiplyingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("#2 D2 *");

        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void OperatorTimes_MultiplyingByZero_ReturnCorrectResult()
    {
        var result = _sut.EvalRpn("#2 D0 *");
        
        Assert.That(result, Is.EqualTo(0));
    }
    [Test]
    public void OperatorMinus_SubtractingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("B11 #2 -");

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void OperatorMinus_SubtractingTwoNumbers_ReturnCorrectNegativeResult()
    {
        var result = _sut.EvalRpn("B1 #2 -");
        
        Assert.That(result, Is.EqualTo(-1));
    }
    [Test]
    public void OperatorDivide_SubtractingByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _sut.EvalRpn("D1 B0 /"));
    }
    [Test]
    public void OperatorDivide_DivingTwoNumbers_ReturnCorrectResult()
    {
        var result = _sut.EvalRpn("#F B101 /");

        Assert.That(result, Is.EqualTo(3));
    }
    [Test]
    public void OperatorFactor_FactoringANumber_ReturnCorrectResult()
    {
        var result = _sut.EvalRpn("#5 !");
        
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void OperatorFactor_FactoringZero_ReturnCorrectResult()
    {
        var result = _sut.EvalRpn("#0 !");
        
        Assert.That(result, Is.EqualTo(1));
    }
    [Test]
    public void ComplexExpression() {
        var result = _sut.EvalRpn("D15 D7 B1 B1 + - / #3 * #2 D1 B1 + + -");
        
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void ComplexExpression2()
    {
        var result = _sut.EvalRpn("B1010 #A * D99 #DD B1111 + + -");
        
        Assert.That(result, Is.EqualTo(-235));
    }

    [Test]
    public void OperatorSum_SummingAllNumbers_ReturnCorrectResult()
    {
        var result = _sut.EvalRpn("D15 B10 #A $");
        
        Assert.That(result, Is.EqualTo(27));
    }

}