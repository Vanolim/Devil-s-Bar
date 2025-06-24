using Core.Infrastructure.Spawners.CharacterSpawner.Interfaces;
using Core.Services.PhotonServices.Interfaces;
using Core.Services.PhotonServices.PhotonEventHandler;
using Cysharp.Threading.Tasks;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace Core.Infrastructure.Spawners.CharacterSpawner
{
    public class CharacterPhotonRegister : ICharacterPhotonRegister
    {
        private readonly IPhotonEventHandler _photonEventHandler;

        public CharacterPhotonRegister(IPhotonEventHandler photonEventHandler)
        {
            _photonEventHandler = photonEventHandler;
        }

        public UniTask RegisterPlayerView(string characterId)
        {
            object[] data = {characterId};
            
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.All,
                CachingOption = EventCaching.DoNotCache,
            };
            
            SendOptions sendOptions = new SendOptions()
            {
                Reliability = true
            };
            
            PhotonNetwork.RaiseEvent(PhotonEventCodeData.ViewSpawn, data, raiseEventOptions, sendOptions);

            return WaitingForThisCharacterRegistered(characterId);
        }

        private UniTask WaitingForThisCharacterRegistered(string characterId)
        {
            var tcs = new UniTaskCompletionSource();

            void CheckCharacter(string registeredCharacterId)
            {
                if (registeredCharacterId == characterId)
                {
                    _photonEventHandler.OnCharacterRegistered -= CheckCharacter;
                    tcs.TrySetResult();
                }
            }

            _photonEventHandler.OnCharacterRegistered += CheckCharacter;
            return tcs.Task;
        }
    }
}