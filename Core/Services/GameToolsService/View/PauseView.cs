using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Services.GameToolsService.View
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private Button _continueGame;

        public event Action OnContinueGame;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}