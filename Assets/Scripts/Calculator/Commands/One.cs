using Calculator.Commands.Groups;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "One", menuName = "Calculator/Commands/One", order = 0)]
    public class One : Digit
    {
        protected override byte Value => 1;
    }
}