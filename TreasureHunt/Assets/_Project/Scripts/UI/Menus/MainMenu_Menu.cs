using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Menus
{
    public class MainMenu_Menu : MenuBase
    {
        [SerializeField] private Button _playButton;

        private InjectService _injectService;

        private GameLevelSelection_Menu _gameLevelSelection_Menu;

        public void Construct(GameLevelSelection_Menu gameLevelSelection_Menu)
        {
            _gameLevelSelection_Menu = gameLevelSelection_Menu;
        }

        protected override void Awake()
        {
            _injectService = ProjectContext.Instance.Container.TryResolve<InjectService>();
            _injectService.Inject(this);

            base.Awake();
        }

        public override void Open()
        {
            base.Open();

            _playButton.onClick.AddListener(OnPLayButtonClicked);
        }

        public override void Close()
        {
            base.Close();

            _playButton.onClick.RemoveListener(OnPLayButtonClicked);
        }

        public void OnPLayButtonClicked()
        {
            _gameLevelSelection_Menu?.Open();
        }
    }
}