using _Scripts.Infastructure.Services;
using _Scripts.Infastructure.States;
using _Scripts.Logic;
public class Game {
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain) {
        StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
    }
    
}