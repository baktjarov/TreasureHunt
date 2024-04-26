using Characters;
using DataClasses;
using DataClasses.Static;
using Services;
using SO;
using UnityEngine;
using Zenject;

namespace DI.Installers
{
    public class Gameplay_Installer : MonoInstaller
    {
        [SerializeField] private ListOfAllCharacters _listOfAllWarriors;
        [SerializeField] private CharacterManager _characterManager;

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
            Container.BindInstance(_listOfAllWarriors).AsSingle();
            Container.BindInstance(_characterManager).AsSingle();
        }
    }
}