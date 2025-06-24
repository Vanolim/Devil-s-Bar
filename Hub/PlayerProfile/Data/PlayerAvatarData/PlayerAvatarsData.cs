using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Hub.PlayerProfile.Data.PlayerAvatarData
{
    [CreateAssetMenu(fileName = "PlayerAvatarsData", menuName = "ScriptableObjects/PlayerAvatarsData")]
    public class PlayerAvatarsData : ScriptableObject
    {
        [SerializeField] private List<PlayerAvatarData> _data;
        
        public IReadOnlyList<PlayerAvatarData> Data => _data;

        public Sprite GetAvatar(int avatarId)
        { 
            PlayerAvatarData data = _data.FirstOrDefault(x => x.AvatarId == avatarId);
            if (data.Avatar == null)
            {
                Debug.LogError($"No avatar found with id {avatarId} in {GetType()}");
                return _data.First().Avatar;
            }
            
            return data.Avatar;
        }
    }
}