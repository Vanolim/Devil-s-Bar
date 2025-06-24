using Hub.PlayerProfile.Data;
using Hub.PlayerProfile.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hub.PlayerProfile.View
{
    public class PlayerProfileView : MonoBehaviour, IPlayerProfileView
    {
        [SerializeField] 
        private Image _avatar;
        [SerializeField] 
        private TMP_Text _name;
        [SerializeField] 
        private TMP_Text _matchesPlayed;
        [SerializeField] 
        private TMP_Text _winRate;

        public void SetDisplayedData(PlayerProfileDisplayData playerProfileDisplayData)
        {
            _avatar.sprite = playerProfileDisplayData.Avatar;
            _name.text = $"{playerProfileDisplayData.Name}#{playerProfileDisplayData.NameDiscriminator}";
            _matchesPlayed.text = playerProfileDisplayData.MatchesPlayed;
            //_winRate.text = playerProfileDisplayData.WinRate;
        }
    }
}