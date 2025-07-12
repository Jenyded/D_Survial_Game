using _Project.Scripts.Infrastructure.Services.PersistentData;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string SaveKey = "save";
        private const string OptionsKey = "options";

        private readonly IPersistentDataService _persistentDataService;

        public SaveLoadService(IPersistentDataService persistentDataService)
        {
            _persistentDataService = persistentDataService;
        }
    
        public PlayerOptions LoadOptions()
        {
            string json = PlayerPrefs.GetString(OptionsKey);
        
            PlayerOptions options = JsonConvert.DeserializeObject<PlayerOptions>(json);

            return options;
        }

        public PlayerProgress Load()
        {
            string json = PlayerPrefs.GetString(SaveKey);
        
            PlayerProgress progress = JsonConvert.DeserializeObject<PlayerProgress>(json);
            
            return progress;
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(_persistentDataService.Progress, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        
            string jsonOptions = JsonConvert.SerializeObject(_persistentDataService.Options);
        
            PlayerPrefs.SetString(SaveKey, json);
            PlayerPrefs.SetString(OptionsKey, jsonOptions);
        }
    
    }
}