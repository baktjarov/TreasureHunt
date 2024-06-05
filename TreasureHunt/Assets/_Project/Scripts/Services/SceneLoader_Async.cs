using Interfaces;
using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneLoader_Async : ISceneLoader
    {
        public async void LoadScene(string sceneName, Action onLoaded)
        {
            var handle = SceneManager.LoadSceneAsync(sceneName);
            while (handle.isDone == false)
            {
                await Task.Delay(40);
            }

            onLoaded.Invoke();
        }
    }
}