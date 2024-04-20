using DataClasses;
using DataClasses.Static;
using Services;
using UnityEngine;
using Zenject;

namespace DI.Installers
{
    public class MainMenu_Installer : MonoInstaller
    {
        private Signal<GameLevel> _onLoadLevelRequested = new Signal<GameLevel>();

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
            Container.Bind<Signal<GameLevel>>().WithId(EventStrings.onLoadLevelRequested).FromInstance(_onLoadLevelRequested).AsSingle();
        }
    }
}