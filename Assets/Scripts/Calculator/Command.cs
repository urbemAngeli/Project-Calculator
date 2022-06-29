using System;
using Calculator.Units;
using UnityEngine;

namespace Calculator
{
    [Serializable]
    public abstract class Command : ScriptableObject
    {
        public bool HasErrorBlocking => _hasErrorBlocking;

        protected Register Register { get; private set; }

        protected abstract void Perform();

        [SerializeField]
        private bool _hasErrorBlocking;

        public void Run()
        {
            if (Register.HasError)
            {
                Register.CleanAll();
                
                if(_hasErrorBlocking)
                    return;
            }
            
            Perform();
        }

        public void Construct(Register register) => 
            Register = register;
    }
}