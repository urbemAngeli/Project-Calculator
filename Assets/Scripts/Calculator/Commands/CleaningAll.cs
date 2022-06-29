using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "CleaningAll", menuName = "Calculator/Commands/CleaningAll", order = 0)]
    public class CleaningAll : Command
    {
        protected override void Perform() => 
            Register.CleanAll();
    }
}