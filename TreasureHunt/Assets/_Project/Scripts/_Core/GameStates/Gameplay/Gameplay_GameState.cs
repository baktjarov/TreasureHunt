using Core.Interfaces;
using DataClasses;
using Services;
using Zenject;

namespace Core.GameStates
{
    public class Gameplay_GameState : IGameState
    {
        [Inject] private SceneLoader _sceneLoader;
        [Inject] private IGameStatesManager _gameStatesManager;

        private GameLevel _gameLevel;

        private Gameplay_GameState_Controller controller;

        public Gameplay_GameState(GameLevel gameLevel)
        {
            _gameLevel = gameLevel;
        }

        public void Enter()
        {
            ProjectContext.Instance.Container.TryResolve<InjectService>()?.Inject(this);

            controller = new Gameplay_GameState_Controller();

            _sceneLoader.LoadScene(_gameLevel.sceneName, () =>
            {
                controller.Initialize();

                controller.model.onGoToMenuRequested.AddListener(GoToMainMenu);
            });
        }

        public void Exit()
        {
            controller.model.onGoToMenuRequested.RemoveListener(GoToMainMenu);
        }

        private void GoToMainMenu()
        {
            _gameStatesManager.ChangeState(new MainMenu_GameState());
        }
    }
}