using DataClasses;
using DataClasses.Static;
using Interfaces;
using Services;
using SO;
using Zenject;

namespace Core.GameStates
{
    public class Gameplay_GameState_Model : IInitializable<bool>
    {
        [Inject(Id = EventStrings.onGoToMainMenuRequested)] public Signal onGoToMenuRequested { get; private set; }

        [Inject] public ListOfAllScenes listOfAllScenes { get; private set; }
        [Inject] public ListOfAllMenus listOfAllMenus { get; private set; }

        private InjectService _injectService;

        public Gameplay_GameState_Model()
        {
            _injectService = ProjectContext.Instance.Container.TryResolve<InjectService>();
            _injectService.Inject(this);
        }

        public bool Initialize()
        {
            return true;
        }
    }
}