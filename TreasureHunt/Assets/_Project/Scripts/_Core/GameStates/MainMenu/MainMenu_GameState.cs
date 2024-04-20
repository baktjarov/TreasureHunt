using Core.Interfaces;
using DataClasses;
using GameStates;
using Services;
using SO;
using Zenject;

namespace Core.GameStates
{
    public class MainMenu_GameState : IGameState
    {
        [Inject] private ListOfAllScenes _listOfAllScenes;
        [Inject] private SceneLoader _sceneLoader;
        [Inject] private IGameStatesManager _gameStatesManager;

        private MainMenu_GameState_Controller controller;

        private InjectService _injectService;

        public void Enter()
        {
            _injectService = ProjectContext.Instance.Container.TryResolve<InjectService>();
            _injectService?.Inject(this);

            controller = new MainMenu_GameState_Controller();

            _sceneLoader.LoadScene(_listOfAllScenes.mainMenuScene.sceneName, () =>
            {
                controller.Initialize();

                controller.model.onGameLevelLoadRequested.AddListener(Play);
            });
        }

        public void Exit()
        {
            controller.model.onGameLevelLoadRequested.RemoveListener(Play);
        }

        private void Play(GameLevel gameLevel)
        {
            _gameStatesManager.ChangeState(new Gameplay_GameState(gameLevel));
        }
    }
}