namespace Calculator.Commands.Groups
{
    public abstract class Operator : Command, IOperator
    {
        public abstract void Calculate();
        public abstract char Symbol { get; }
        
        protected override void Perform()
        {
            Register.CleanSecondOperand();
            
            if (IsOperatorNotSaved())
            {
                Register.SetFirstOperand(double.Parse(Register.EntryStrip));
            }
        
            Register.UpdateExpression(string.Format("{0} {1}", Register.FirstOperand, Symbol));
            Register.SaveOperator(this);
            Register.CleanEntry();
        }

        protected void UpdateRegister(double firstOperand, double secondOperand, double result)
        {
            Register.SetFirstOperand(result);
            Register.SetSecondOperand(secondOperand);
            
            Register.UpdateExpression(string.Format("{0} {1} {2} =", firstOperand, Symbol, secondOperand));
            Register.UpdateEntry(result);
        }

        private bool IsOperatorNotSaved() => 
            Register.Operator != this;
    }
}