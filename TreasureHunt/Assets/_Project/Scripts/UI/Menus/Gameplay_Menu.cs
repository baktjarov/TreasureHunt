using Gameplay;
using StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus
{
    public class Gameplay_Menu : MenuBase
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TextMeshProUGUI _currencyText;
        [SerializeField] private TextMeshProUGUI _enemyCountText;
        [SerializeField] private CurrencySystem _currencySystem;
        [SerializeField] private TowerStateMachineBase[] _towerStateMachineBase;

        private Pause_Menu _pauseMenu;
        private Win_Menu _winMenu;
        private Louse_Menu _louseMenu;

        public void Construct(Louse_Menu louse_Menu, Win_Menu win_Menu, Pause_Menu pause_Menu)
        {
            _pauseMenu = pause_Menu;
            _winMenu = win_Menu;
            _louseMenu = louse_Menu;
        }

        private void Start()
        {
            _towerStateMachineBase = FindObjectsOfType<TowerStateMachineBase>();
            _currencySystem.Init();
            UpdateUI();
        }

        private void Update()
        {
            if (_currencySystem._enemyCount <= 0)
            {
                _winMenu.Open();
            }
        }

        public override void Open()
        {
            base.Open();

            _currencySystem.isUseCurrency += UpdateUI;

            foreach (var tower in _towerStateMachineBase)
            {
                tower.isLouse += OpenLouse;
            }

            _pauseButton.onClick.AddListener(OnPauseClicked);

            Time.timeScale = 1f; 
        }

        public override void Close()
        {
            base.Close();

            _currencySystem.isUseCurrency -= UpdateUI;

            foreach (var tower in _towerStateMachineBase)
            {
                tower.isLouse -= OpenLouse;
            }

            _pauseButton.onClick.RemoveListener(OnPauseClicked);

            Time.timeScale = 0f; 
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

        private void OpenLouse()
        {
            _louseMenu.Open();
        }
    }
}