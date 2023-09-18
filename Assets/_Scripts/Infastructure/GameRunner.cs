using UnityEngine;

namespace _Scripts.Infastructure {
    public class GameRunner : MonoBehaviour {
        public GameBootstrapper BootstrapperPrefab;
        private void Awake() {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();
            if (!bootstrapper) {
                Instantiate(BootstrapperPrefab);
            }
        }
    }
}