using Calculator.UI;
using Calculator.Units;
using UnityEngine;

namespace Calculator
{
    public class SimpleCalculator : MonoBehaviour
    {
        [SerializeField]
        private UICalculatorButton[] _uiButtons;

        [SerializeField]
        private UIDisplay _uiDisplay;

        private Register _register;
        private CommandUnit _commandUnit;
        private InputUnit _inputUnit;
        private OutputUnit _outputUnit;
        
        private void Awake()
        {
            Construct();
            Initialize();
        }

        private void Construct()
        {
            _register = new Register();
            _commandUnit = new CommandUnit(_register, _uiButtons);
            _inputUnit = new InputUnit(_register, _uiButtons);
            _outputUnit = new OutputUnit(_register, _uiDisplay);
            
            ConstructCommands(_uiButtons);
        }

        private void Initialize() => 
            _register.CleanAll();

        private void ConstructCommands(ICommandReader[] readers)
        {
            for (int i = 0; i < readers.Length; i++) 
                readers[i].Command.Construct(_register);
        }
    }
}