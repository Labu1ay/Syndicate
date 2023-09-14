using _Scripts.Infastructure.AssetManagement;
using UnityEngine;

namespace _Scripts.Infastructure.Factory {
    public class GameFactory : IGameFactory {
        private readonly IAssets assets;

        public GameFactory(IAssets assets) {
            this.assets = assets;
        }

        public GameObject CreateHero(GameObject at) => assets.Instantiate(AssetPath.HeroPath, at: at.transform.position);

        public void CreateHud() => assets.Instantiate(AssetPath.HudPath);
    }
}