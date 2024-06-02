using DataClasses;
using DataClasses.Static;
using Gameplay;
using Services;
using SO;
using UnityEngine;
using Zenject;

namespace DI.Installers
{
    public class Gameplay_Installer : MonoInstaller
    {
        private Signal _onGoToMainMenuRequested = new Signal();
        private Signal _onLoadLevelRequested = new Signal();

        [SerializeField] private CurrencySystem _currencySystem;
        [SerializeField] private WarriorPooling _warriorPooling;
        [SerializeField] private TorchGoblinPooling _torchGoblinPooling;

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
            InstallSystems();
            InstallSignals();
        }

        private void InstallSignals()
        {
            Container.Bind<Signal>().WithId(EventStrings.onGoToMainMenuRequested).FromInstance(_onGoToMainMenuRequested).AsSingle();
            Container.Bind<Signal>().WithId(EventStrings.onLoadLevelRequested).FromInstance(_onLoadLevelRequested);
        }

        private void InstallSystems()
        {
            Container.Bind<CurrencySystem>().FromInstance(_currencySystem).AsSingle();
            Container.Bind<WarriorPooling>().FromInstance(_warriorPooling).AsSingle();
            Container.Bind<TorchGoblinPooling>().FromInstance(_torchGoblinPooling).AsSingle();
        }
    }
}