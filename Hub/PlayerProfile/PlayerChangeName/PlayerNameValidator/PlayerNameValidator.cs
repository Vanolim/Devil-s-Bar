namespace Hub.PlayerProfile.PlayerChangeName.PlayerNameValidator
{
    public class PlayerNameValidator
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 12;
        
        private readonly ProfanityFilter.ProfanityFilter _profanityFilter = new();

        public bool ValidateNewName(string newName, out PlayerNameErrorValidateMessage errorValidateMessage)
        {
            if (newName.Length < MinNameLength)
            {
                errorValidateMessage = PlayerNameErrorValidateMessage.Short;
                return false;
            }
            if (newName.Length > MaxNameLength)
            {
                errorValidateMessage = PlayerNameErrorValidateMessage.Long;
                return false;
            }
            
            if (_profanityFilter.IsProfanity(newName))
            {
                errorValidateMessage = PlayerNameErrorValidateMessage.Profanity;
                return false;
            }

            errorValidateMessage = PlayerNameErrorValidateMessage.None;
            return true;
        }
    }
}