using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "CleaningEntry", menuName = "Calculator/Commands/CleaningEntry", order = 0)]
    public class CleaningEntry : Command
    {
        protected override void Perform()
        {
            if (Register.HasDirtyEntry)
            {
                Register.CleanAll();
                return;
            }

            Register.CleanEntry();
        }
    }
}