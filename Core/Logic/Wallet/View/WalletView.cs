using System;
using Core.Logic.Wallet.Interfaces;
using Core.Managers.ScreenManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Logic.Wallet.View
{
    public class WalletView : MonoBehaviour, IWalletView
    {
        [SerializeField]
        private TMP_Text _walletValueDisplay;

        [SerializeField]
        private Button _walletButton;

        private event Action _onWalletButtonClicked;
        
        public event Action<IBaseScreen> OnDestroyed;

        private void OnEnable()
        {
            _walletButton.onClick.AddListener(() => _onWalletButtonClicked?.Invoke());
        }
        
        public void Initialize(Action walletButtonClicked)
        {
            _onWalletButtonClicked = walletButtonClicked;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void SetValue(string value)
        {
            _walletValueDisplay.text = value;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        private void OnDisable()
        {
            _walletButton.onClick.RemoveAllListeners();
        }
    }
}