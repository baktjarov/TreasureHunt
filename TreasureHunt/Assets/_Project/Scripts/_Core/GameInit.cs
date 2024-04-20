using Core.GameStates;
using Core.Interfaces;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameInit : MonoBehaviour
    {
        [Inject] private IGameStatesManager _gameStateManager;

        private void Start()
        {
            _gameStateManager.ChangeState(new Init_GameState());
        }
    }
}