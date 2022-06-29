using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Equals", menuName = "Calculator/Commands/Equals", order = 0)]
    public class Equals : Command
    {
        protected override void Perform()
        {
            if (Register.HasOperator)
            {
                Register.Operator?.Calculate();
                Register.SetDirtyEntry(); 
            }
        }
    }
}