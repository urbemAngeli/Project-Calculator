namespace Calculator.Units
{
    public class InputUnit
    {
        private readonly Register _register;
        private readonly IButtonReader[] _buttons;

        public InputUnit(Register register, IButtonReader[] buttons)
        {
            _register = register;
            _buttons = buttons;

            foreach (var button in buttons)
                button.OnClicked += ClickButton;

            _register.OnErrored += BlockButtons;
            _register.OnCleaned += UnblockButtons;
        }

        private void ClickButton(IButtonReader buttonReader) =>
            _register.RunCommand(buttonReader.CommandType);
        
        private void BlockButtons()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (_buttons[i].HasErrorBlocking)
                    _buttons[i].Block();
            }
        }
        
        private void UnblockButtons()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (_buttons[i].HasErrorBlocking)
                    _buttons[i].Unblock();
            }
        }
    }
}