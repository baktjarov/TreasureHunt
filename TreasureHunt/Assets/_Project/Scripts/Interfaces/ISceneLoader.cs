using System;

namespace Interfaces
{
    public interface ISceneLoader
    {
        public void LoadScene(string sceneName, Action onLoaded);
    }
}