using DataClasses;
using DataClasses.Static;
using Services;
using SO;
using UI.Elements;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Menus
{
    public class GameLevelSelection_Menu : MenuBase
    {
        [Inject(Id = EventStrings.onLoadLevelRequested)] private Signal<GameLevel> _onLoadLevelRequested;
        [Inject] private ListOfAllScenes _listOfAllScenes;

        [SerializeField] private Transform _gameLevelsContentHolder;
        [SerializeField] private GameLevelUI _gameLevelUIPrefab;
        [SerializeField] private Button _backButton;

        private InjectService _injectService;

        protected override void Awake()
        {
            _injectService = ProjectContext.Instance.Container.TryResolve<InjectService>();
            _injectService.Inject(this);

            base.Awake();
        }

        public override void Open()
        {
            _injectService = ProjectContext.Instance.Container.TryResolve<InjectService>();
            _injectService.Inject(this);
            base.Open();

            foreach (var gameLevelUI in _gameLevelsContentHolder.GetComponentsInChildren<GameLevelUI>(true))
            {
                Destroy(gameLevelUI.gameObject);
            }

            foreach (var gameLevel in _listOfAllScenes.gameLevels)
            {
                GameLevelUI gameLevelInstance = Instantiate(_gameLevelUIPrefab, _gameLevelsContentHolder);
                gameLevelInstance.Setup(gameLevel, _onLoadLevelRequested);
            };

            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        public override void Close()
        {
            base.Close();

            _backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            _backMenu?.Open();
        }
    }
}