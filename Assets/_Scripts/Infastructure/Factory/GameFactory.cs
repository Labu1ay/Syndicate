using System;
using System.Collections.Generic;
using _Scripts.Infastructure.AssetManagement;
using _Scripts.Infastructure.Services.PersistentProgress;
using UnityEngine;

namespace _Scripts.Infastructure.Factory {
    public class GameFactory : IGameFactory {
        private readonly IAssets assets;

        public List<ISavedProgressReader> progressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> progressWriters { get; } = new List<ISavedProgress>();
        
        public GameObject HeroGameObject { get; set; }
        public event Action HeroCreated;

        public GameFactory(IAssets assets) {
            this.assets = assets;
        }

        public GameObject CreateHero(GameObject at) {
            HeroGameObject = InstantiateRegistered(AssetPath.HeroPath, at.transform.position);
            HeroCreated?.Invoke();
            return HeroGameObject;
        }

        public void CreateHud() => InstantiateRegistered(AssetPath.HudPath);

        public void Cleanup() {
            progressReaders.Clear();
            progressWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefapPath, Vector3 at) {
            GameObject gameObject = assets.Instantiate(prefapPath, at);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        } 
        private GameObject InstantiateRegistered(string prefapPath) {
            GameObject gameObject = assets.Instantiate(prefapPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject) {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader) {
            if (progressReader is ISavedProgress progressWriter) 
                progressWriters.Add(progressWriter);
            
            progressReaders.Add(progressReader);
        }
    }
}