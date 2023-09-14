using _Scripts.Infastructure.AssetManagement;
using _Scripts.Infastructure.Factory;
using _Scripts.Infastructure.Services;
using _Scripts.Services.Input;
using UnityEngine.Device;

namespace _Scripts.Infastructure.States {
    public class BootstrapState : IState {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegisterServices();
        }

        public void Enter() {
            _sceneLoader.Load(Initial, callback: EnterLoadLevel);
        }

        public void Exit() { }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>("Game");

        private void RegisterServices() {
            _services.RegisterSingle<IInputService>(RegisterInputService());
            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
        }

        private static InputService RegisterInputService() {
            if (Application.isEditor)
                return new StandaloneInputService();
            else {
                return new MobileInputService();
            }
        }
    }
}