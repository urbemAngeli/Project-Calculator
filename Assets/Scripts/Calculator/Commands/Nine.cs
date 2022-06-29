using Calculator.Commands.Groups;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Nine", menuName = "Calculator/Commands/Nine", order = 0)]
    public class Nine : Digit
    {
        protected override byte Value => 9;
    }
}