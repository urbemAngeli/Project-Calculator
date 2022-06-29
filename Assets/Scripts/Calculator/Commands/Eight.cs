using Calculator.Commands.Groups;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Eight", menuName = "Calculator/Commands/Eight", order = 0)]
    public class Eight : Digit
    {
        protected override byte Value => 8;
    }
}