using _Scripts.Infastructure;
using _Scripts.Logic;
using _Scripts.Services.Input;

public class Game {
    public static IInputService InputService;
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain) {
        StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain);
    }
    
}