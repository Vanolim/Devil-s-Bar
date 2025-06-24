using System;
using Core.Managers.ScreenManager;
using Hub.PlayerProfile.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hub.PlayerProfile.View
{
    public class PlayerProfileChangeNameView : MonoBehaviour, IPlayerProfileChangeNameView
    {
        [SerializeField] 
        private TMP_InputField _nameInputField;
        [SerializeField] 
        private TMP_Text _errorMessage;
        
        [SerializeField] 
        private Button _cansel;
        [SerializeField] 
        private Button _accept;
        
        [SerializeField] 
        private Sprite _errorAcceptButtonSprite;
        [SerializeField] 
        private Sprite _acceptButtonSprite;

        private event Action<string> _onNameInputFieldChanged;
        private event Action _onCanselButtonEvent;
        private event Action _onAcceptButtonEvent;
        
        public event Action<IBaseScreen> OnDestroyed;
        
        private void OnEnable()
        {
            _nameInputField.onValueChanged.AddListener(NameInputFieldChangedEvent);
            _cansel.onClick.AddListener(() => _onCanselButtonEvent?.Invoke());
        }

        public void Show()
        {
            SwitchVisibilityErrorMessage(false);
            BlockAcceptButton(true);
            
            gameObject.SetActive(true);
        }

        public void Initialize(Action<string> nameInputFieldChanged, Action canselButtonEvent,
            Action acceptButtonEvent)
        {
            _onNameInputFieldChanged = nameInputFieldChanged;
            _onCanselButtonEvent = canselButtonEvent;
            _onAcceptButtonEvent = acceptButtonEvent;
        }

        public void SetDisplayName(string newName)
        {
            _nameInputField.text = newName;
        }

        public void SetErrorMessage(string message)
        {
            _errorMessage.text = message;
        }

        public void SwitchVisibilityErrorMessage(bool isVisibility)
        {
            _errorMessage.gameObject.SetActive(isVisibility);
        }

        public void BlockAcceptButton(bool isBlock)
        {
            if (isBlock)
            {
                _accept.image.sprite = _errorAcceptButtonSprite;
                _accept.onClick.RemoveAllListeners();
            }
            else
            {
                _accept.image.sprite = _acceptButtonSprite;
                _accept.onClick.RemoveAllListeners();
                _accept.onClick.AddListener(() => _onAcceptButtonEvent?.Invoke());
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void NameInputFieldChangedEvent(string newName) => _onNameInputFieldChanged?.Invoke(newName);

        private void OnDisable()
        {
            _nameInputField.onValueChanged.RemoveAllListeners();
            _cansel.onClick.RemoveAllListeners();
            _accept.onClick.RemoveAllListeners();
        }
        
        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}