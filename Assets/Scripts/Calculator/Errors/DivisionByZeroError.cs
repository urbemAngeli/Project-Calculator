namespace Calculator.Errors
{
    public class DivisionByZeroError : IError
    {
        public string Message => "Division by zero is not possible";
    }
}