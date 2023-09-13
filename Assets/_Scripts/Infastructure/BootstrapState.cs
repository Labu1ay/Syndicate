using _Scripts.Services.Input;
using UnityEngine.Device;

namespace _Scripts.Infastructure {
    public class BootstrapState : IState {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() {
            RegisterServices();
            _sceneLoader.Load(Initial, callback: EnterLoadLevel);
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>("Game");

        private void RegisterServices() {
            Game.InputService = RegisterInputService();
        }

        public void Exit() {
            
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