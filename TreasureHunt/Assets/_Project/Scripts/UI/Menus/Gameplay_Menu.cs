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
        [SerializeField] private TextMeshProUGUI _currencyText;
        [SerializeField] private TextMeshProUGUI _enemyCountText;

        private Pause_Menu _pause_Menu;
        private Win_Menu _win_Menu;
        private Louse_Menu _louse_Menu;

        public void Construct(Pause_Menu pause_Menu, Win_Menu win_Menu, Louse_Menu louse_Menu)
        {
            _pause_Menu = pause_Menu;
            _win_Menu = win_Menu;
            _louse_Menu = louse_Menu;
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
            _currencySystem._isUIUpdate += UpdateUI;
        }

        public override void Close()
        {
            base.Close();

            _pauseButton.onClick.RemoveListener(OnPauseClicked);
            _currencySystem._isUIUpdate -= UpdateUI;
        }

        public void OnPauseClicked()
        {
            _pause_Menu?.Open();
        }

        public void UpdateUI()
        {
            _currencyText.text = _currencySystem._currency.ToString();
            _enemyCountText.text = _currencySystem._enemyCount.ToString();
        }
    }
}