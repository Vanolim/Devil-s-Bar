using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Logic.View
{
    public class CustomToggleView : MonoBehaviour
    {
        [SerializeField]
        private Toggle _toggle;
        
        [SerializeField]
        private GameObject _on;
        
        [SerializeField]
        private GameObject _off;
        
        private event Action<bool> _onValueChanged;

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(ValueChangedEvent);
        }

        public void Initialize(bool initValueIsOn, Action<bool> valueChanged)
        {
            _toggle.isOn = initValueIsOn;
            SwitchView(initValueIsOn);
            _onValueChanged = valueChanged;
        }

        private void ValueChangedEvent(bool value)
        {
            SwitchView(value);
            _onValueChanged?.Invoke(value);
        }

        private void SwitchView(bool value)
        {
            _off.gameObject.SetActive(!value);
            _on.gameObject.SetActive(value);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveAllListeners();
        }
    }
}