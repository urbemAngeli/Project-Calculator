using UnityEngine;

namespace Calculator.Commands
{
    [CreateAssetMenu(fileName = "Dot", menuName = "Calculator/Commands/Dot", order = 0)]
    public class Dot : Command
    {
        protected override void Perform()
        {
            if(Register.HasDirtyEntry)
                Register.CleanAll();
            
            string entryStrip = Register.EntryStrip;
                        
            if(entryStrip.Contains(","))
                return;
                        
            entryStrip += ",";
                
            Register.UpdateEntry(entryStrip);
        }
    }
}