namespace Calculator.Commands.Groups
{
    public abstract class Digit : Command
    {
        private const int MaxDigits = 16;
        
        protected abstract byte Value { get; }

        protected override void Perform()
        {
            if(Register.HasDirtyEntry)
                Register.CleanAll();
            
            if(IsMaxDigitsCount(Register.EntryStrip))
                return;
            
            InsertDigit(Value);
        }

        private void InsertDigit(byte digit)
        {
            string entryStrip = Register.EntryStrip;
        
            if (entryStrip == "0")
                entryStrip = digit.ToString();
            else
                entryStrip += digit;
        
            Register.UpdateEntry(entryStrip);
        }

        private bool IsMaxDigitsCount(string strip)
        {
            int digitsCount = strip.Length;

            if (strip[0] == '-')
                digitsCount--;

            if (strip.Contains(","))
                digitsCount--;
            
            return digitsCount == MaxDigits;
        }
    }
}