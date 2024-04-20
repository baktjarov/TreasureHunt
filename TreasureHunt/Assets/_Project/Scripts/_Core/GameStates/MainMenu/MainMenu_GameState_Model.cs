using DataClasses;
using DataClasses.Static;
using Interfaces;
using Services;
using SO;
using Zenject;

namespace GameStates
{
    public class MainMenu_GameState_Model : IInitializable<bool>
    {
        [Inject(Id = EventStrings.onLoadLevelRequested)] public Signal<GameLevel> onGameLevelLoadRequested;

        [Inject] public ListOfAllMenus listOfAllMenus { get; private set; }
        [Inject] public InjectService injectService { get; private set; }

        public MainMenu_GameState_Model()
        {
            ProjectContext.Instance.Container.TryResolve<InjectService>()?.Inject(this);
        }

        public bool Initialize()
        {
            return true;
        }
    }
}