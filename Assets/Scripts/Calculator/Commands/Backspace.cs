using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Backspace", menuName = "Calculator/Commands/Backspace", order = 0)]
    public class Backspace : Command
    {
        protected override void Perform()
        {
            if(Register.HasDirtyEntry)
                Register.CleanAll();
            
            string entryStrip = Register.EntryStrip;
                
            if(entryStrip.Length >= 1)
                entryStrip = entryStrip.Remove(entryStrip.Length - 1);

            if (IsValidateEntry(entryStrip))
            {
                Register.UpdateEntry(entryStrip);
                return;
            }

            Register.CleanEntry();
        }

        private static bool IsValidateEntry(string entryStrip)
        {
            if (entryStrip.Length == 0)
                return false;

            if (entryStrip == "-")
                return false;
            
            return true;
        }
    }
}