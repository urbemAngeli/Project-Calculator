using Calculator.Errors;
using UnityEngine;

namespace Calculator.Commands
{   
    [CreateAssetMenu(fileName = "Sign", menuName = "Calculator/Commands/Sign", order = 0)]
    public class Sign : Command
    {
        protected override void Perform()
        {
            double entryOperand;
            
            if (!double.TryParse(Register.EntryStrip, out entryOperand))
            {
                Register.SetError(new InvalidInputError());
                return;
            }

            entryOperand *= -1;
            
            if(Register.HasDirtyEntry)
                Register.CleanAll();
                    
            Register.UpdateEntry(entryOperand);
        }
    }
}