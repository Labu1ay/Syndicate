using _Scripts.CameraLogic;
using _Scripts.Infastructure.AssetManagement;
using _Scripts.Logic;
using UnityEngine;

namespace _Scripts.Infastructure {
    public class LoadLevelState : IPayLoadedState<string> {
        private const string _initialPointTag = "InitialPoint";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain) {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName) {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => _loadingCurtain.Hide();

        private void OnLoaded() {
            var hero = _gameFactory.CreateHero(at: GameObject.FindWithTag(_initialPointTag));
            _gameFactory.CreateHud();
            
            CameraFollow(hero);
            
            _stateMachine.Enter<GameLoopState>();
        }

        private static void CameraFollow(GameObject hero) {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(hero);
        }
    }
}