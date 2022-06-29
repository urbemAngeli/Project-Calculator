using Calculator.Commands.Groups;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Zero", menuName = "Calculator/Commands/Zero", order = 0)]
    public class Zero : Digit
    {
        protected override byte Value => 0;
    }
}