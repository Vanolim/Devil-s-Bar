using System;
using Core.Logic.Shop.Interfaces;
using Core.Managers.ScreenManager;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Core.Logic.Shop.View
{
    public class ShopCoinOfferView : MonoBehaviour, IShopCoinOfferView
    {
        [SerializeField]
        private string _coinOfferId;

        [SerializeField]
        private TMP_Text _price;
        
        [SerializeField]
        private TMP_Text _coinValue;

        [SerializeField]
        private Button _select;
        
        [SerializeField]
        private TMP_Text _noticeText;

        [SerializeField]
        private Image _noticeImage;
        
        private event Action<string> _onSelect;

        public string CoinOfferId => _coinOfferId;
        
        public event Action<IBaseScreen> OnDestroyed;

        private void OnEnable()
        {
            _select.onClick.AddListener(() => _onSelect?.Invoke(CoinOfferId));
        }
        
        public void Initialize(string price, string coinValue, Action<string> select)
        {
            _price.text = price;
            _coinValue.text = coinValue;
            _onSelect = select;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void ShowNotice(string noticeMessage)
        {
            _noticeText.text = noticeMessage;
            _noticeImage.gameObject.SetActive(true);
        }

        public void HideNotice()
        {
            _noticeImage.gameObject.SetActive(false);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _select.onClick.RemoveAllListeners();
        }
    }
}