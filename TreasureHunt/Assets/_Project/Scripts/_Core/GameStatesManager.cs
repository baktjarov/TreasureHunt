using Core.Interfaces;

namespace Core
{
    public class GameStatesManager : IGameStatesManager
    {
        private IGameState _currentGameState;

        public void ChangeState(IGameState gameState)
        {
            _currentGameState?.Exit();

            _currentGameState = gameState;
            _currentGameState.Enter();
        }
    }
}