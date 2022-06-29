using System;
using Calculator.Errors;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Sqr", menuName = "Calculator/Commands/Sqr", order = 0)]
    public class Sqr : Command
    {
        protected override void Perform()
        {
            double entryOperand;
            
            if (!double.TryParse(Register.EntryStrip, out entryOperand))
            {
                Register.SetError(new InvalidInputError());
                return;
            }
            
            double result = Math.Pow(entryOperand, 2);
        
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
            Register.UpdateExpression(string.Format("sqr({0})", entryOperand));
            Register.UpdateEntry(result);
        }
    }
}