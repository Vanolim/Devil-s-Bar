using System;
using Core.Logic.CharacterCustomization.Infrastructure;
using Core.Logic.CharacterCustomization.Interfaces;
using Core.Managers.ScreenManager;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Logic.CharacterCustomization.View
{
    public class CharacterCustomizationMenuView : MonoBehaviour, ICharacterCustomizationMenuView
    {
        [SerializeField] 
        private Button _back;
        
        [SerializeField] 
        private Button _menu;
        
        [SerializeField] 
        private Button _characters;
        
        [SerializeField] 
        private Button _skins;
        
        [SerializeField] 
        private Button _weapons;

        [SerializeField]
        private TMP_Text _characterName;
        
        [SerializeField]
        private TMP_Text _characterDescriprion;

        [SerializeField]
        private CharacterCustomizationMenuAnimatorUIController _animatorUIController;

        private Action _onBack;
        private Action _onMenu;
        private Action _onCharacters;
        private Action _onSkins;
        private Action _onWeapons;
        
        public event Action<IBaseScreen> OnDestroyed;

        private void OnEnable()
        {
            _back.onClick.AddListener(() => _onBack?.Invoke());
            _menu.onClick.AddListener(() => _onMenu?.Invoke());
            _characters.onClick.AddListener(() => _onCharacters?.Invoke());
            _skins.onClick.AddListener(() => _onSkins?.Invoke());
            _weapons.onClick.AddListener(() => _onWeapons?.Invoke());
        }
        
        public void Initialize(Action back, Action menu, Action characters, Action skins, Action weapons)
        {
            _onBack = back;
            _onMenu = menu;
            _onCharacters = characters;
            _onSkins = skins;
            _onWeapons = weapons;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public async UniTask ShowAfterChange()
        {
            await _animatorUIController.PlayShowAfterChangeAnimation();
            Show();
        }

        public void SetCharacterInfo(string name, string description)
        {
            _characterName.text = name;
            
            _characterDescriprion.text = description;
        }

        public async UniTask HideWithAnimation()
        {
            if (gameObject.activeSelf)
            {
                await _animatorUIController.PlayHideAnimation();
                Hide();
            }
        }
        
        public async UniTask HideViewWithTransitToChangeAnimation()
        {
            if (gameObject.activeSelf)
            {
                await _animatorUIController.PlayHideWithTransitToChangeAnimation();
                Hide();
            }
        }
        
        public UniTask HideViewWithTransitToMenuAnimation()
        {
            if (gameObject.activeSelf)
            {
                return _animatorUIController.PlayHideWithTransitToChangeAnimation();
            }
            
            return UniTask.CompletedTask;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _back.onClick.RemoveAllListeners();
            _menu.onClick.RemoveAllListeners();
            _characters.onClick.RemoveAllListeners();
            _skins.onClick.RemoveAllListeners();
            _weapons.onClick.RemoveAllListeners();
        }
        
        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}