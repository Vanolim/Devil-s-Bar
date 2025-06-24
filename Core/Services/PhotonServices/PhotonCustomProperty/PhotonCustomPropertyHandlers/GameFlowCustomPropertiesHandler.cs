using System;
using Core.Extensions;
using Game.Card;
using Game.Data;
using Game.Weapon;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace Core.Services.PhotonServices.PhotonCustomProperty.PhotonCustomPropertyHandlers
{
    public class GameFlowCustomPropertiesHandler
    {
        public Hashtable GetCustomProperties(GameFlowData gameFlowData)
        {
            Hashtable customRoomData = new Hashtable
            {
                [CustomPropertyKeys.Game.GameLoopManagerId] = gameFlowData.GameLoopManagerId,
                [CustomPropertyKeys.Game.CurrentState] = (int)gameFlowData.CurrentState,
                [CustomPropertyKeys.Game.ShooterSaidPatronType] = (int)gameFlowData.ShooterSaidPatronType,
                [CustomPropertyKeys.Game.ShootTargetId] = gameFlowData.ShootTargetId,
                [CustomPropertyKeys.Game.AdditionalCards] = gameFlowData.GetAdditionalCards(),
                [CustomPropertyKeys.Game.AdditionalCardPlaceIndex] = gameFlowData.AdditionalCardPlaceIndexes,
                [CustomPropertyKeys.Game.WeaponPatrons] = gameFlowData.GetWeaponPatrons(),
                [CustomPropertyKeys.Game.CardDeckCards] = gameFlowData.GetCardDeckCards(),
                [CustomPropertyKeys.Game.IsWeaponDoubleShoot] = gameFlowData.IsWeaponDoubleShot,
            };
            return customRoomData;
        }

        public void SetNewGameFlowData(GameFlowData gameFlowData) => 
            PhotonNetwork.CurrentRoom.SetCustomProperties(GetCustomProperties(gameFlowData));

        public void SetTargetCustomProperty(string targetKey, object value)
        {
            object targetValue = value;
            switch (targetKey)
            {
                case CustomPropertyKeys.Game.AdditionalCards:
                    if (targetValue is CardType[] additionalCards) 
                        targetValue = additionalCards.ToIntArray();
                    break;
                case CustomPropertyKeys.Game.WeaponPatrons:
                    if (targetValue is PatronType[] patronTypes) 
                        targetValue = patronTypes.ToIntArray();
                    break;
                case CustomPropertyKeys.Game.CardDeckCards:
                    if (targetValue is CardType[] cardDeckCards) 
                        targetValue = cardDeckCards.ToIntArray();
                    break;
            }
            
            Hashtable targetCustomProperty = new Hashtable
            {
                [targetKey] = targetValue
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(targetCustomProperty);
        }

        public GameFlowData GetCurrentGameFlowData()
        {
            var data = PhotonNetwork.CurrentRoom.CustomProperties;

            if (data.ContainsKey(CustomPropertyKeys.Game.CurrentState) == false)
            {
                return GetDefaultGameFlowData();
            }
            
            GameFlowState gameFlowState = (GameFlowState)data[CustomPropertyKeys.Game.CurrentState];
            string gameLoopManagerId = (string)data[CustomPropertyKeys.Game.GameLoopManagerId];
            PatronType shooterSaidPatronType = (PatronType)data[CustomPropertyKeys.Game.ShooterSaidPatronType];
            string shootTargetId = (string)data[CustomPropertyKeys.Game.ShootTargetId];
            int[] additionalCards = (int[])data[CustomPropertyKeys.Game.AdditionalCards];
            int[] additionalCardPlaceIndex = (int[])data[CustomPropertyKeys.Game.AdditionalCardPlaceIndex];
            int[] weaponPatrons = (int[])data[CustomPropertyKeys.Game.WeaponPatrons];
            int[] cardDeckCards = (int[])data[CustomPropertyKeys.Game.CardDeckCards];
            bool isWeaponDoubleShot = (bool)data[CustomPropertyKeys.Game.IsWeaponDoubleShoot];
            
            
            return new GameFlowData(
                gameLoopManagerId, 
                gameFlowState, 
                shooterSaidPatronType, 
                shootTargetId, 
                GameFlowData.GetAdditionalCards(additionalCards), 
                additionalCardPlaceIndex,
                GameFlowData.GetWeaponPatrons(weaponPatrons), 
                GameFlowData.GetCardDeckCards(cardDeckCards), 
                isWeaponDoubleShot);
        }

        private GameFlowData GetDefaultGameFlowData()
        {
            return new GameFlowData(
                "None",
                GameFlowState.None,
                PatronType.None,
                "None", 
                Array.Empty<CardType>(), 
                Array.Empty<int>(),
                Array.Empty<PatronType>(),
                Array.Empty<CardType>(),
                false);
        }
    }
}