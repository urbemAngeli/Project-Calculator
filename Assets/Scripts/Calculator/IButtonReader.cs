using System;

namespace Calculator
{
    public interface IButtonReader
    {
        event Action<IButtonReader> OnClicked;
        bool HasErrorBlocking { get; }
        Type CommandType { get; }
        void Block();
        void Unblock();
    }
}