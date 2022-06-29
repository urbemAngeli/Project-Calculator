using Calculator.Commands.Groups;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Four", menuName = "Calculator/Commands/Four", order = 0)]
    public class Four : Digit
    {
        protected override byte Value => 4;
    }
}