using System.Collections.Generic;
using _Scripts.Infastructure;
using _Scripts.Logic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner {
    public LoadingCurtain Curtain;
    private Game _game;

    private void Awake() {
        _game = new Game(this, Curtain);
        _game.StateMachine.Enter<BootstrapState>();
        DontDestroyOnLoad(this);
    }
}