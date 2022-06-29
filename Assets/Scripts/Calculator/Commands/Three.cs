using Calculator.Commands.Groups;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Three", menuName = "Calculator/Commands/Three", order = 0)]
    public class Three : Digit
    {
        protected override byte Value => 3;
    }
}