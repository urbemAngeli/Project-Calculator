using Calculator.Commands.Groups;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Seven", menuName = "Calculator/Commands/Seven", order = 0)]
    public class Seven : Digit
    {
        protected override byte Value => 7;
    }
}