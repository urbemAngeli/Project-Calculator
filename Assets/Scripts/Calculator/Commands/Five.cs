using Calculator.Commands.Groups;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Five", menuName = "Calculator/Commands/Five", order = 0)]
    public class Five : Digit
    {
        protected override byte Value => 5;
    }
}