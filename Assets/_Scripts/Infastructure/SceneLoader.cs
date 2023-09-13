using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader {
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) {
        _coroutineRunner = coroutineRunner;   
    }

    public void Load(string name, Action callback = null) => _coroutineRunner.StartCoroutine(LoadScene(name, callback));

    public IEnumerator LoadScene(string nextScene, Action callback = null) {
        if (SceneManager.GetActiveScene().name == nextScene) {
            callback?.Invoke();
            yield break;
        }   
        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

        while (!waitNextScene.isDone) {
            yield return null;
        }
        callback?.Invoke();
    }
}