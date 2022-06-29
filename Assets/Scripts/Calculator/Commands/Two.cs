using Calculator.Commands.Groups;
using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Two", menuName = "Calculator/Commands/Two", order = 0)]
    public class Two : Digit
    {
        protected override byte Value => 2;
    }
}