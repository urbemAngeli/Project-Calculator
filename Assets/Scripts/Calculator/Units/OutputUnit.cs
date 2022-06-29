namespace Calculator.Units
{
    public class OutputUnit
    {
        private readonly Register _register;
        private readonly IOutputReader _reader;

        public OutputUnit(Register register, IOutputReader reader)
        {
            _register = register;
            _reader = reader;

            _register.OnChanged += Update;
        }

        private void Update()
        {
            _reader.UpdateOutput(_register.EntryStrip, _register.ExpressionStrip);
        }
    }
}