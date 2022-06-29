using Calculator.Commands.Groups;
using Calculator.Errors;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Addition", menuName = "Calculator/Commands/Addition", order = 0)]
    public class Addition : Operator
    {
        public override char Symbol => '+';
        
        public override void Calculate()
        {
            double entryOperand;
            
            if (!double.TryParse(Register.EntryStrip, out entryOperand))
            {
                Register.SetError(new InvalidInputError());
                return;
            }
            
            double firstOperand = Register.FirstOperand;
            double secondOperand = Register.SecondOperand ?? entryOperand;

            double result = firstOperand + secondOperand;
            
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
            
            UpdateRegister(firstOperand, secondOperand, result);

            // ---------------------------
            // double storedOperand = Register.StoredOperand;
            // double entryOperand = double.Parse(Register.EntryStrip);
            //
            // double result = storedOperand + entryOperand;
            //
            // if (double.IsNaN(result))
            // {
            //     Register.SetError(new NaNError());
            //     return;
            // }
            //
            // if(double.IsInfinity(result))
            // {
            //     Register.SetError(new InfinityError());
            //     return;
            // }
            //
            // UpdateRegister(storedOperand, entryOperand, result);
        }
    }
}