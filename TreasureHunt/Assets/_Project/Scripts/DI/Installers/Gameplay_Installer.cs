using Characters;
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
        private Signal _onReloadLevelRequested = new Signal();

        [SerializeField] private CurrencySystem _currencySystem;
        [SerializeField] private CharacterManager _characterManager;
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
            Container.Bind<Signal>().WithId(EventStrings.onReloadLevelRequested).FromInstance(_onReloadLevelRequested);
            Container.Bind<Signal>().WithId(EventStrings.onGoToMainMenuRequested).FromInstance(_onGoToMainMenuRequested).AsSingle();
        }

        private void InstallSystems()
        {
            Container.Bind<CurrencySystem>().FromInstance(_currencySystem).AsSingle();
            Container.Bind<CharacterManager>().FromInstance(_characterManager).AsSingle();
            Container.Bind<WarriorPooling>().FromInstance(_warriorPooling).AsSingle();
            Container.Bind<TorchGoblinPooling>().FromInstance(_torchGoblinPooling).AsSingle();
        }
    }
}