using System;
using System.Collections.Generic;
using _Scripts.Infastructure.Services;
using _Scripts.Infastructure.Services.PersistentProgress;
using UnityEngine;

namespace _Scripts.Infastructure.Factory {
    public interface IGameFactory : IService {
        List<ISavedProgressReader> progressReaders { get; }
        List<ISavedProgress> progressWriters { get; }
        GameObject HeroGameObject { get; }
        event Action HeroCreated;
        GameObject CreateHero(GameObject at);
        void CreateHud();
        void Cleanup();
    }
}