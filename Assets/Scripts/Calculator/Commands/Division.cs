using System;
using Calculator.Commands.Groups;
using Calculator.Errors;
using Extensions;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Division", menuName = "Calculator/Commands/Division", order = 0)]
    public class Division : Operator
    {
        public override char Symbol => '÷';

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

            if (secondOperand.IsZero())
            {
                Register.SetError(new DivisionByZeroError());
                return;
            }

            double result = firstOperand / secondOperand;
            
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
        }
    }
}