using UnityEngine;
using UnityEngine.UI;

namespace UI.Menus
{
    public class Gameplay_Menu : MenuBase
    {
        [SerializeField] private Button _pauseButton;

        private Pause_Menu _pause_Menu;

        public void Construct(Pause_Menu pause_Menu)
        {
            _pause_Menu = pause_Menu;
        }
        public override void Open()
        {
            base.Open();

            _pauseButton.onClick.AddListener(OnPauseClicked);
        }

        public override void Close()
        {
            base.Close();

            _pauseButton.onClick.RemoveListener(OnPauseClicked);
        }

        public void OnPauseClicked()
        {
            _pause_Menu?.Open();
        }
    }
}