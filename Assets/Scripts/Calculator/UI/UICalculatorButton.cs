using System;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.UI
{
    [RequireComponent(typeof(Button))]
    public class UICalculatorButton : MonoBehaviour, IButtonReader, ICommandReader
    {
        public event Action<IButtonReader> OnClicked;

        public bool HasErrorBlocking => _command.HasErrorBlocking;
        public Type CommandType => _command.GetType();

        public Command Command => _command;

        [SerializeField]
        private Command _command;

        [SerializeField, HideInInspector]
        private Button _button;

        private void OnValidate()
        {
            if (_button == null)
                _button = GetComponent<Button>();
        }

        private void Awake() => 
            _button.onClick.AddListener(Click);

        private void OnDisable() => 
            _button.onClick.RemoveListener(Click);

        private void Click() => 
            OnClicked?.Invoke(this);

        public void Block() => 
            _button.interactable = false;

        public void Unblock() => 
            _button.interactable = true;
    }
}