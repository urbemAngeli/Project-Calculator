namespace Calculator.Errors
{
    public class NaNError : IError
    {
        public string Message => "Result is not defined";
    }
}