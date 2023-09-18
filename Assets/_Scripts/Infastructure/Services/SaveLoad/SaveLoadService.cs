using _Scripts.Data;
using _Scripts.Infastructure.Factory;
using _Scripts.Infastructure.Services.PersistentProgress;
using UnityEngine;

namespace _Scripts.Infastructure.Services.SaveLoad {
    public class SaveLoadService : ISaveLoadService {
        private const string ProgressKey = "Progress";
        
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService progressService,IGameFactory gameFactory) {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress() {
            foreach (ISavedProgress progressWriter in _gameFactory.progressWriters) 
                progressWriter.UpdateProgress(_progressService.Progress);
            
            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() => 
            PlayerPrefs.GetString(ProgressKey)?
                .ToDeserialized<PlayerProgress>();
    }
}