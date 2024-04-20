using Core.Interfaces;
using Zenject;

namespace Core.GameStates
{
    public class Init_GameState : IGameState
    {
        [Inject] private IGameStatesManager _gameStateManager;

        public void Enter()
        {
            ProjectContext.Instance.Container.Inject(this);

            _gameStateManager.ChangeState(new MainMenu_GameState());
        }

        public void Exit()
        {

        }
    }
}