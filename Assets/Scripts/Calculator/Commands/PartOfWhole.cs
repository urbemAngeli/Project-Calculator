using Calculator.Errors;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "PartOfWhole", menuName = "Calculator/Commands/PartOfWhole", order = 0)]
    public class PartOfWhole : Command
    {
        protected override void Perform()
        {
            string entryStrip = Register.EntryStrip;
            
            Register.CleanAll();
            
            if (double.TryParse(entryStrip, out _))
            {
                Register.UpdateEntry(1d);
                Register.RunCommand<Division>();
            
                Register.UpdateEntry(entryStrip);
                Register.RunCommand<Equals>();
            }
            else
            {
                Register.SetError(new InvalidInputError());
            }

            Register.UpdateExpression(string.Format("1/({0})", entryStrip));
        }
    }
}