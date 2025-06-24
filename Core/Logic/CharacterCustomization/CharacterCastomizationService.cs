using System.Collections.Generic;
using System.Linq;
using Core.Logic.CharacterCustomization.Data;
using Core.Logic.CharacterCustomization.Interfaces;
using Cysharp.Threading.Tasks;

namespace Core.Logic.CharacterCustomization
{
    public class CharacterCastomizationService : ICharacterCustomizationService
    {
        private readonly ICharacterCustomizationSlotSpawner _characterCustomizationSlotSpawner;
        private readonly ICharacterCustomizationDataAdapter _characterCastomizationDataAdapter;
        private readonly Dictionary<ICharacterCustomizationSlotView, string> _charactersCustomizationSlot = new();

        private List<CharacterCustomizationData> _charactersCustomizationData = new();

        public CharacterCastomizationService(ICharacterCustomizationSlotSpawner characterCustomizationSlotSpawner, ICharacterCustomizationDataAdapter characterCastomizationDataAdapter, (CharacterCustomizationData, ICharacterCustomizationSlotView)[] charactersSlots)
        {
            _characterCustomizationSlotSpawner = characterCustomizationSlotSpawner;
            _characterCastomizationDataAdapter = characterCastomizationDataAdapter;
        }

        public void SetSelectedCharacter(string characterId)
        {
            _characterCastomizationDataAdapter.ChangeCharacter(characterId);
        }

        public ICharacterCustomizationSlotView GetSelectedSlot()
        {
            string currentCharacterId = _characterCastomizationDataAdapter.GetCurrentCharacterId();
            return _charactersCustomizationSlot.First(x => x.Value == currentCharacterId).Key;
        }

        public CharacterCustomizationData GetCurrentCharacterData()
        {
            string currentCharacterId = _characterCastomizationDataAdapter.GetCurrentCharacterId();

            var currentCharacterData = _charactersCustomizationData.FirstOrDefault(x => x.CharacterId == currentCharacterId);
            
            if (currentCharacterData == null)
            {
                var newData = _characterCastomizationDataAdapter.GetCharactersCustomizationData(currentCharacterId);
                _charactersCustomizationData.Add(newData);
                
                return newData;
            }

            return currentCharacterData;
        }

        public CharacterCustomizationData GetCharacterCustomizationData(ICharacterCustomizationSlotView slot)
        {
            _charactersCustomizationSlot.TryGetValue(slot, out string characterId);
            return _charactersCustomizationData.First(x => x.CharacterId == characterId);
        }

        public async UniTask<ICharacterCustomizationSlotView[]> GetCharactersSlot()
        {
            if (_charactersCustomizationSlot.Any())
            {
                return _charactersCustomizationSlot.Keys.ToArray();
            }

            await InitializeCharactersSlot();
            
            return _charactersCustomizationSlot.Keys.ToArray();
        }

        private async UniTask InitializeCharactersSlot()
        {
            var allCharactersData = _characterCastomizationDataAdapter.GetAllCharactersData();
            var currentCharacterId = _characterCastomizationDataAdapter.GetCurrentCharacterId();

            _charactersCustomizationData = allCharactersData.ToList();
            _charactersCustomizationSlot.Clear();
            
            for (int i = 0; i < allCharactersData.Length; i++)
            {
                CharacterCustomizationData characterData = allCharactersData[i];
                ICharacterCustomizationSlotView slot;

                bool isSelected = characterData.CharacterId == currentCharacterId;

                if (characterData.IsLock)
                {
                    slot = await _characterCustomizationSlotSpawner.GetLockSlot(characterData.LockAvatar, characterData.Price);
                }
                else
                {
                    slot = await _characterCustomizationSlotSpawner.GetUnlockSlot(characterData.CharacterName,
                        characterData.UnlockAvatar, isSelected);
                }

                _charactersCustomizationSlot.Add(slot, characterData.CharacterId);
            }
        }
    }
}