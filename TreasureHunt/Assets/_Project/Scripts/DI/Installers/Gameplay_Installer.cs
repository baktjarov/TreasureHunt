using DataClasses;
using DataClasses.Static;
using Gameplay;
using Services;
using UnityEngine;
using Zenject;

namespace DI.Installers
{
    public class Gameplay_Installer : MonoInstaller
    {
        private Signal _onGoToMainMenuRequested = new Signal();
        private Signal _onLoadLevelRequested = new Signal();
        
        [SerializeField] private CurrencySystem _currencySystem;

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
            Container.Bind<Signal>().WithId(EventStrings.onLoadLevelRequested).FromInstance(_onLoadLevelRequested);

            Container.Bind<CurrencySystem>().FromInstance(_currencySystem).AsSingle();
        }
    }
}