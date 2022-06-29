using System;

namespace Calculator.Units
{
    public class Register
    {
        public event Action OnChanged;
        public event Action OnErrored;
        public event Action OnCleaned;
        public event Action<Type> OnCommandStarted;

        public string ExpressionStrip => _expressionStrip;
        
        public string EntryStrip => _entryStrip;

        public IOperator Operator => _operator;

        public bool HasError => _error != null;

        public bool HasOperator => _operator != null;
        
        public bool HasDirtyEntry => _hasDirtyEntry;

        public double FirstOperand => _firstOperand;

        public double? SecondOperand => _secondOperand;

        private string _expressionStrip;
        private string _entryStrip;

        private double _firstOperand;
        private double? _secondOperand;

        private IOperator _operator;

        private IError _error;

        private bool _hasDirtyEntry;

        public void CleanEntry()
        {
            _hasDirtyEntry = false;
            
            _entryStrip = "0";

            OnChanged?.Invoke();
        }

        public void CleanAll()
        {
            _firstOperand = 0;
            
            _error = null;
            _operator = null;
            _secondOperand = null;

            _hasDirtyEntry = false;
            
            _expressionStrip = string.Empty;
            _entryStrip = "0";

            OnChanged?.Invoke();
            OnCleaned?.Invoke();
        }
        
        public void UpdateExpression(string expressionValue)
        {
            _expressionStrip = expressionValue;
            
            OnChanged?.Invoke();
        }
    
        public void UpdateEntry(double entryValue)
        {
            _entryStrip = entryValue.ToString();
            
            OnChanged?.Invoke();
        }

        public void UpdateEntry(string entryValue)
        {
            _entryStrip = entryValue;
            
            OnChanged?.Invoke();
        }

        public void SaveOperator(IOperator mathOperator) => 
            _operator = mathOperator;

        public void CleanOperator() => 
            _operator = null;

        public void SetError(IError error)
        {
            _error = error;
        
            UpdateEntry(error.Message);
        
            OnErrored?.Invoke();
        }

        public void RunCommand<TCommand>() where TCommand : Command => 
            OnCommandStarted?.Invoke(typeof(TCommand));
        
        public void RunCommand(Type commandType) =>
            OnCommandStarted?.Invoke(commandType);

        public void SetDirtyEntry() => 
            _hasDirtyEntry = true;

        public void SetFirstOperand(double operand) => 
            _firstOperand = operand;
        
        public void SetSecondOperand(double operand) => 
            _secondOperand = operand;

        public void CleanSecondOperand() => 
            _secondOperand = null;
    }
}