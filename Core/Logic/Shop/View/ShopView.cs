using System;
using System.Collections.Generic;
using Core.Logic.Shop.Interfaces;
using Core.Managers.ScreenManager;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Logic.Shop.View
{
    public class ShopView : MonoBehaviour, IShopView
    {
        [SerializeField]
        private Button _back;
        
        [SerializeField]
        private ShopCoinOfferView[] _shopCoinOfferViews;

        private event Action _onBack;
        private event Action<string> _coinOfferSelected;

        public IReadOnlyCollection<IShopCoinOfferView> CoinOffers => _shopCoinOfferViews;
        
        public event Action<IBaseScreen> OnDestroyed;

        private void OnEnable()
        {
            _back.onClick.AddListener(() => _onBack?.Invoke());
        }

        public void Initialize(Action back, Action<string> coinOfferSelected)
        {
            _onBack = back;
            _coinOfferSelected = coinOfferSelected;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _back.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}