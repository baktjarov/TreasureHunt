using Interfaces;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneLoader_Coroutine : ISceneLoader
    {
        private readonly CoroutineRunner _coroutineRunner;
        private readonly IEnumerator _wait = new WaitForSecondsRealtime(0.25f);

        public SceneLoader_Coroutine(CoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string sceneName, Action onLoaded)
        {
            _coroutineRunner?.StartCoroutine(LoadScene_Coroutine(sceneName, onLoaded));
        }

        private IEnumerator LoadScene_Coroutine(string sceneName, Action onLoaded)
        {
            var handle = SceneManager.LoadSceneAsync(sceneName);
            while (handle.isDone == false)
            {
                yield return _wait;
            }

            onLoaded.Invoke();
        }
    }
}