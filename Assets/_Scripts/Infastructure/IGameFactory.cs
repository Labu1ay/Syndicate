using UnityEngine;

namespace _Scripts.Infastructure {
    public interface IGameFactory {
        GameObject CreateHero(GameObject at);
        void CreateHud();
    }
}