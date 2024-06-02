using Core;
using Core.GameStates;
using Core.Interfaces;
using Services;
using SO;
using UnityEngine;
using Zenject;

namespace DI.Installers
{
    public class Global_Installer : MonoInstaller
    {
        [SerializeField] private ListOfAllScenes _listOfAllScenes;
        [SerializeField] private ListOfAllMenus _listOfAllMenus;
        [SerializeField] private ListOfAllUnits _listOfAllUnits;
        [SerializeField] private ListOfAllTowers _listOfAllTowers;

        private InjectService _injectService = new();

        public override void InstallBindings()
        {
            _injectService.AddContainer(Container);

            InstallSO();
            InstallService();
            InstallInterface();
        }

        private void InstallSO()
        {
            Container.BindInstance(_listOfAllScenes).AsSingle();
            Container.BindInstance(_listOfAllMenus).AsSingle();
            Container.BindInstance(_listOfAllUnits).AsSingle();
            Container.BindInstance(_listOfAllTowers).AsSingle();
        }

        private void InstallService()
        {
            Container.Bind<IGameStatesManager>().To<GameStatesManager>().AsSingle();
            Container.Bind<InjectService>().FromInstance(_injectService).AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void InstallInterface()
        {
            Container.BindInterfacesTo<Init_GameState>().AsSingle();
            Container.BindInterfacesTo<Gameplay_GameState>().AsSingle();
        }
    }
}