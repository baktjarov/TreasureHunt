using System;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Menus
{
    public class Gameplay_Menu : MenuBase
    {
        [Inject] public CurrencySystem _currencySystem;

        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _spawnButton;

        [SerializeField] private TextMeshProUGUI _currencyText;
        [SerializeField] private TextMeshProUGUI _enemyCountText;

        private Pause_Menu _pauseMenu;
        private Win_Menu _winMenu;
        private Louse_Menu _louseMenu;

        public void Construct(Pause_Menu pause_Menu, Win_Menu win_Menu, Louse_Menu louse_Menu)
        {
            _pauseMenu = pause_Menu;
            _winMenu = win_Menu;
            _louseMenu = louse_Menu;
        }

        public void Start()
        {
            _currencySystem.Init();
            UpdateUI();
        }

        public override void Open()
        {
            base.Open();

            _pauseButton.onClick.AddListener(OnPauseClicked);
            _currencySystem.isUseCurrency += UpdateUI;
        }

        public override void Close()
        {
            base.Close();

            _pauseButton.onClick.RemoveListener(OnPauseClicked);
            _currencySystem.isUseCurrency -= UpdateUI;
        }

        public void OnPauseClicked()
        {
            _pauseMenu?.Open();
        }

        private void UpdateUI()
        {
            _currencyText.text = _currencySystem._currency.ToString();
            _enemyCountText.text = _currencySystem._enemyCount.ToString();
        }
    }
}