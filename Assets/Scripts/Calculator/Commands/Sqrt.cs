using System;
using Calculator.Errors;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Sqrt", menuName = "Calculator/Commands/Sqrt", order = 0)]
    public class Sqrt : Command
    {
        protected override void Perform()
        {
            double entryOperand;
            
            if (!double.TryParse(Register.EntryStrip, out entryOperand))
            {
                Register.SetError(new InvalidInputError());
                return;
            }

            if (entryOperand < 0)
            {
                Register.SetError(new InvalidInputError());
                return;
            }

            double result = Math.Sqrt(entryOperand);
            
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
                    
            Register.CleanAll();
            Register.UpdateExpression(string.Format("√({0})", entryOperand));
            Register.UpdateEntry(result);
        }
    }
}