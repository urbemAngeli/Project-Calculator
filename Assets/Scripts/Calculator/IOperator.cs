namespace Calculator
{
    public interface IOperator
    {
        public void Calculate();
        char Symbol { get; }
    }
}