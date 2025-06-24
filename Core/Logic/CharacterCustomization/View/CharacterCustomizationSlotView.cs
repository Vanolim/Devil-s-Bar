using System;
using Core.Logic.CharacterCustomization.Interfaces;
using Core.Managers.ScreenManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Logic.CharacterCustomization.View
{
    public class CharacterCustomizationSlotView : MonoBehaviour, ICharacterCustomizationSlotView
    {
        [SerializeField]
        private Button _select;
        
        [SerializeField]
        private TMP_Text _name;

        [SerializeField]
        private Image _avatar;

        [SerializeField]
        private GameObject _selectMark;
        
        [SerializeField]
        private GameObject _lockMark;

        [SerializeField]
        private TMP_Text _price;

        private Action<ICharacterCustomizationSlotView> _onSelect;
        
        public event Action<IBaseScreen> OnDestroyed;

        private void OnEnable()
        {
            _select.onClick.AddListener(SelectEvent);
        }
        
        public void Initialize(Action<ICharacterCustomizationSlotView> select)
        {
            _onSelect = select;
        }

        public void SetUnlockData(string name, Sprite avatar, bool isSelect)
        {
            _avatar.sprite = avatar;
            _name.text = name;
            
            SwitchToUnlock(avatar, isSelect);
        }

        public void SetLockData(Sprite avatar, string price)
        {
            _avatar.sprite = avatar;
            
            SwitchToLock(avatar, price);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void SwitchToUnlock(Sprite avatar, bool isSelect)
        {
            _avatar.sprite = avatar;
            
            _price.gameObject.SetActive(false);
            _lockMark.gameObject.SetActive(false);
            
            SetSelected(isSelect);
        }

        public void SwitchToLock(Sprite avatar, string price)
        {
            _name.gameObject.SetActive(false);
            
            _avatar.sprite = avatar;
            
            _lockMark.gameObject.SetActive(true);
            _selectMark.gameObject.SetActive(false);
            
            _price.text = price;
        }

        public void SetSelected(bool value)
        {
            _selectMark.gameObject.SetActive(value);
        }

        public void SetParent(RectTransform parent)
        {
            transform.parent = parent;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        private void SelectEvent() => _onSelect?.Invoke(this);

        private void OnDisable()
        {
            _select.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}