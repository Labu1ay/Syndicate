using _Scripts.Infastructure.AssetManagement;
using _Scripts.Infastructure.Factory;
using _Scripts.Infastructure.Services;
using _Scripts.Infastructure.Services.Input;
using _Scripts.Infastructure.Services.PersistentProgress;
using _Scripts.Infastructure.Services.SaveLoad;
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

        private void EnterLoadLevel() => _stateMachine.Enter<LoadProgressState>();

        private void RegisterServices() {
            _services.RegisterSingle<IInputService>(RegisterInputService());
            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(), _services.Single<IGameFactory>()));
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