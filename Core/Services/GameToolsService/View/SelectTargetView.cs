using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Services.GameToolsService.View
{
    public class SelectTargetView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerName1;
        [SerializeField] private TMP_Text _playerId1;
        [SerializeField] private Toggle _isTargetPlayer1;
        
        [SerializeField] private TMP_Text _playerName2;
        [SerializeField] private TMP_Text _playerId2;
        [SerializeField] private Toggle _isTargetPlayer2;
        
        [SerializeField] private TMP_Text _playerName3;
        [SerializeField] private TMP_Text _playerId3;
        [SerializeField] private Toggle _isTargetPlayer3;

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void SetPlayerInfo(string name, string id, int playerIndex)
        {
            switch (playerIndex)
            {
                case 1:
                    _playerName1.text = "Name: " + name;
                    _playerId1.text = "Id: " + id;
                    break;
                case 2:
                    _playerName2.text = "Name: " + name;
                    _playerId2.text = "Id: " + id;
                    break;
                case 3:
                    _playerName3.text = "Name: " + name;
                    _playerId3.text = "Id: " + id;
                    break;
            }
        }

        public void SetTarget(int playerIndex)
        {
            switch (playerIndex)
            {
                case 1:
                    _isTargetPlayer1.isOn = true;
                    _isTargetPlayer2.isOn = false;
                    _isTargetPlayer3.isOn = false;
                    break;
                case 2:
                    _isTargetPlayer1.isOn = false;
                    _isTargetPlayer2.isOn = true;
                    _isTargetPlayer3.isOn = false;
                    break;
                case 3:
                    _isTargetPlayer1.isOn = false;
                    _isTargetPlayer2.isOn = false;
                    _isTargetPlayer3.isOn = true;
                    break;
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}