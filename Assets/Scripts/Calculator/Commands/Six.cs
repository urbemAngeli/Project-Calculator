using Calculator.Commands.Groups;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Six", menuName = "Calculator/Commands/Six", order = 0)]
    public class Six : Digit
    {
        protected override byte Value => 6;
    }
}