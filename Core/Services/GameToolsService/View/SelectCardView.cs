using System;
using System.Collections.Generic;
using Game.Card;
using TMPro;
using UnityEngine;

namespace Core.Services.GameToolsService.View
{
    public class SelectCardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerName1;
        [SerializeField] private TMP_Text _playerId1;
        [SerializeField] private TMP_Dropdown _playerCard1;
        
        [SerializeField] private TMP_Text _playerName2;
        [SerializeField] private TMP_Text _playerId2;
        [SerializeField] private TMP_Dropdown _playerCard2;
        
        [SerializeField] private TMP_Text _playerName3;
        [SerializeField] private TMP_Text _playerId3;
        [SerializeField] private TMP_Dropdown _playerCard3;
        
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

        public void SetCards(CardType[] allCardsType)
        {
            var options = new List<TMP_Dropdown.OptionData>();
            foreach (var card in allCardsType)
            {
                options.Add(new TMP_Dropdown.OptionData(card.ToString(), null, Color.gray));
            }
            
            int defaultIndex = Array.IndexOf(allCardsType, CardType.None); 
            
            _playerCard1.ClearOptions();
            _playerCard1.AddOptions(options);
            //_playerCard1.value = defaultIndex >= 0 ? defaultIndex : 0;
            _playerCard1.RefreshShownValue();
            
            _playerCard2.ClearOptions();
            _playerCard2.AddOptions(options);
            //_playerCard2.value = defaultIndex >= 0 ? defaultIndex : 0;
            _playerCard2.RefreshShownValue();
            
            _playerCard3.ClearOptions();
            _playerCard3.AddOptions(options);
            //_playerCard3.value = defaultIndex >= 0 ? defaultIndex : 0;
            _playerCard3.RefreshShownValue();
        }
        
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}