using _Scripts.Infastructure.Services;
using UnityEngine;

namespace _Scripts.Infastructure.Factory {
    public interface IGameFactory : IService {
        GameObject CreateHero(GameObject at);
        void CreateHud();
    }
}