using _Scripts.CameraLogic;
using _Scripts.Infastructure.Factory;
using _Scripts.Infastructure.Services.PersistentProgress;
using _Scripts.Logic;
using UnityEngine;

namespace _Scripts.Infastructure.States {
    public class LoadLevelState : IPayLoadedState<string> {
        private const string _initialPointTag = "InitialPoint";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, IPersistentProgressService progressService) {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName) {
            _loadingCurtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => _loadingCurtain.Hide();

        private void OnLoaded() {
            InitGameWorld();
            InformProgressReaders();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders() {
            foreach (ISavedProgressReader progressReader in _gameFactory.progressReaders) {
                progressReader.LoadProgress(_progressService.Progress);
            }
        }

        private void InitGameWorld() {
            var hero = _gameFactory.CreateHero(at: GameObject.FindWithTag(_initialPointTag));
            _gameFactory.CreateHud();

            CameraFollow(hero);
        }

        private static void CameraFollow(GameObject hero) {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(hero);
        }
    }
}