using Interfaces;
using UI.Menus;
using UnityEngine;

namespace GameStates
{
    public class MainMenu_GameState_View : IInitializable<bool>
    {
        private MainMenu_GameState_Model model;

        private MainMenu_Menu _mainMenu_Menu;
        private GameLevelSelection_Menu gameLevelSelection_Menu;

        public MainMenu_GameState_View(MainMenu_GameState_Model model)
        {
            this.model = model;
        }

        public bool Initialize()
        {
            _mainMenu_Menu = Object.Instantiate(model.listOfAllMenus.GetMenu<MainMenu_Menu>());
            gameLevelSelection_Menu = Object.Instantiate(model.listOfAllMenus.GetMenu<GameLevelSelection_Menu>());

            _mainMenu_Menu.Construct(gameLevelSelection_Menu);
            gameLevelSelection_Menu.Construct(_mainMenu_Menu);

            _mainMenu_Menu.Open();

            return true;
        }
    }
}