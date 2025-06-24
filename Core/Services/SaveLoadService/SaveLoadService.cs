using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Core.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string _encryptionKey = "1234567890123456";
        
        private readonly DataValidator _dataValidator = new();
        private readonly string _dataPath = Application.persistentDataPath + "/save.dat";

        private SaveData _currentData;

        public SaveData CurrentData => _currentData;

        public void SaveData(SaveData newData)
        {
            string json = JsonConvert.SerializeObject(newData);
            byte[] encryptedData = Encrypt(json, _encryptionKey);
            File.WriteAllBytes(_dataPath, encryptedData);
            LoadData();
        }

        public void LoadData()
        {
            if (File.Exists(_dataPath))
            {
                byte[] encryptedData = File.ReadAllBytes(_dataPath);
                string json = Decrypt(encryptedData, _encryptionKey);
                _currentData = JsonConvert.DeserializeObject<SaveData>(json);
                
                if(_dataValidator.ValidateData(ref _currentData) == false)
                    SaveData(_currentData);
            }
            else
            {
                _currentData = _dataValidator.GetDefaultData();
                
                Debug.Log("Load Default");
                foreach (var VARIABLE in _currentData.OpenCharacters)
                {
                    Debug.Log(VARIABLE);
                }
                
                SaveData(_currentData);
            }
        }

        private byte[] Encrypt(string plainText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16]; // Null IV 
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                        sw.Write(plainText);
                    return ms.ToArray();
                }
            }
        }

        private string Decrypt(byte[] cipherText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16]; // Coincides with encrypt
                using (MemoryStream ms = new MemoryStream(cipherText))
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}