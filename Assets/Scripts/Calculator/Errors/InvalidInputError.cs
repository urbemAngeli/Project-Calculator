namespace Calculator.Errors
{
    public class InvalidInputError : IError
    {
        public string Message => "Invalid input";
    }
}