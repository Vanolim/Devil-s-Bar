using System;
using Core.Logic.CharacterCustomization.Infrastructure;
using Core.Logic.CharacterCustomization.Interfaces;
using Core.Logic.View;
using Core.Managers.ScreenManager;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Logic.CharacterCustomization.View
{
    public class CharacterCustomizationChangeView : MonoBehaviour, ICharacterCustomizationChangeView
    {
        [SerializeField] 
        private Button _back;
        
        [SerializeField] 
        private Button _home;
        
        [SerializeField]
        private TMP_Text _characterName;
        
        [SerializeField]
        private TMP_Text _characterDescriprion;

        [SerializeField]
        private Button _randomCharacterInfo;
        
        [SerializeField] 
        private CustomToggleView _randomCharacterToggleView;
        
        [SerializeField] 
        private RectTransform _characterContent;

        [SerializeField]
        private CharacterCustomizationChangeAnimatorUIController _animatorUIController;

        private Action _onBack;
        private Action _onHome;
        private Action _onRandomCharacterInfo;
        private Action<bool> _onRandomCharacterChange;
        
        public event Action<IBaseScreen> OnDestroyed;

        private void OnEnable()
        {
            _back.onClick.AddListener(() => _onBack?.Invoke());
            _home.onClick.AddListener(() => _onHome?.Invoke());
            _randomCharacterInfo.onClick.AddListener(() => _onRandomCharacterInfo?.Invoke());
        }

        public void Initialize(Action back, Action home, Action randomCharacterInfo, Action<bool> randomCharacterChange)
        {
            _onBack = back;
            _onHome = home;
            _onRandomCharacterInfo = randomCharacterInfo;
            _onRandomCharacterChange = randomCharacterChange;
            
            _randomCharacterToggleView.Initialize(true, _onRandomCharacterChange);
        }

        public void SetCurrentCharacterInfo(string name, string description)
        {
            _characterName.text = name;
            _characterDescriprion.text = description;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void SetCharacters(ICharacterCustomizationSlotView[] characters)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                var character = characters[i];
                
                character.SetParent(_characterContent);
                character.Show();
            }
        }

        public async UniTask HideWithAnimation()
        {
            if (gameObject.activeSelf)
            {
                await _animatorUIController.PlayHideAnimation();
                Hide();
            }
        }

        public async UniTask HideViewWithTransitToMenuAnimation()
        {
            if (gameObject.activeSelf)
            {
                await _animatorUIController.PlayHideWithTransitToMenuAnimation();
                Hide();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _back.onClick.RemoveAllListeners();
            _home.onClick.RemoveAllListeners();
            _randomCharacterInfo.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}