using DataClasses;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
    public class GameLevelUI : MonoBehaviour
    {
        private Signal<GameLevel> _onLoadLevelRequested;

        [SerializeField] private TextMeshProUGUI _gameLevelName;
        [SerializeField] private Button _playButton;

        private GameLevel _gameLevel;

        public void Setup(GameLevel gameLevel, Signal<GameLevel> onLoadLevelRequested)
        {
            _gameLevel = gameLevel;
            _onLoadLevelRequested = onLoadLevelRequested;

            _gameLevelName.text = _gameLevel.sceneName;
        }

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            _onLoadLevelRequested?.Invoke(_gameLevel);
        }
    }
}