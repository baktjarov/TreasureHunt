using DataClasses;
using DataClasses.Static;
using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Menus
{
    public class Pause_Menu : MenuBase
    {
        [Inject(Id = EventStrings.onGoToMainMenuRequested)] private Signal _onGoToMainMenuRequested;

        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _goToMainMenuButton;

        private InjectService _injectService;

        protected override void Awake()
        {
            _injectService = ProjectContext.Instance.Container.TryResolve<InjectService>();
            _injectService.Inject(this);

            base.Awake();
        }

        public override void Open()
        {
            base.Open();

            _resumeButton.onClick.AddListener(OnResumeButtonClicked);
            _goToMainMenuButton.onClick.AddListener(OnGoToMainMenuClicked);
        }

        public override void Close()
        {
            base.Close();

            _resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
            _goToMainMenuButton.onClick.RemoveListener(OnGoToMainMenuClicked);
        }

        public void OnGoToMainMenuClicked()
        {
            _onGoToMainMenuRequested?.Invoke();
        }

        public void OnResumeButtonClicked()
        {
            _backMenu?.Open();
        }
    }
}