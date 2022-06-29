using Calculator.Errors;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Percent", menuName = "Calculator/Commands/Percent", order = 0)]
    public class Percent : Command
    {
        protected override void Perform()
        {
            double firstOperand = Register.FirstOperand;
            double secondOperand;

            if (!double.TryParse(Register.EntryStrip, out secondOperand))
            {
                Register.SetError(new InvalidInputError());
                return;
            }
            
            double result = firstOperand / 100d * secondOperand;
            
            if (double.IsNaN(result))
            {
                Register.SetError(new NaNError());
                return;
            }
            
            if(double.IsInfinity(result))
            {
                Register.SetError(new InfinityError());
                return;
            }
            
            Register.UpdateExpression(string.Format("{0} {1} {2}", firstOperand, Register.Operator?.Symbol, result));
            Register.UpdateEntry(result);
        }
    }
}