using TMPro;
using UnityEngine;

namespace Calculator.UI
{
    public class UIDisplay : MonoBehaviour, IOutputReader
    {
        [SerializeField]
        private TextMeshProUGUI _entryStrip;

        [SerializeField]
        private TextMeshProUGUI _expressionStrip;

        public void UpdateOutput(string entryStrip, string expressionStrip)
        {
            _entryStrip.text = entryStrip;
            _expressionStrip.text = expressionStrip;
        }
    }
}