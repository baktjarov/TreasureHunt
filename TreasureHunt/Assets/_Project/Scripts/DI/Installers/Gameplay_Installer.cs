using DataClasses;
using DataClasses.Static;
using Services;
using Zenject;
namespace DI.Installers
{
    public class Gameplay_Installer : MonoInstaller
    {
        private Signal _onGoToMainMenuRequested = new Signal();

        [Inject] private InjectService _injectService;

        public override void Start()
        {
            base.Start();

            _injectService.AddContainer(Container);
        }

        private void OnDestroy()
        {
            _injectService.RemoveContainer(Container);
        }

        public override void InstallBindings()
        {
            Container.Bind<Signal>().WithId(EventStrings.onGoToMainMenuRequested).FromInstance(_onGoToMainMenuRequested).AsSingle();
        }
    }
}