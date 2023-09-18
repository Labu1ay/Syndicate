using _Scripts.Infastructure.States;
using _Scripts.Logic;
using UnityEngine;

namespace _Scripts.Infastructure {
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner {
        public LoadingCurtain CurtainPrefab;
        private Game _game;

        private void Awake() {
            _game = new Game(this, Instantiate(CurtainPrefab));
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}