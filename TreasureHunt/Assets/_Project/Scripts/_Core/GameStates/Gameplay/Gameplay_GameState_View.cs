using Interfaces;
using UI.Menus;
using UnityEngine;

namespace Core.GameStates
{
    public class Gameplay_GameState_View : IInitializable<bool>
    {
        private Gameplay_GameState_Model _model;

        private Gameplay_Menu _gameplay_Menu;
        private Pause_Menu _pause_Menu;

        public Gameplay_GameState_View(Gameplay_GameState_Model model)
        {
            _model = model;
        }

        public bool Initialize()
        {
            _gameplay_Menu = Object.Instantiate(_model.listOfAllMenus.GetMenu<Gameplay_Menu>());
            _pause_Menu = Object.Instantiate(_model.listOfAllMenus.GetMenu<Pause_Menu>());

            _pause_Menu.Construct(_gameplay_Menu);
            _gameplay_Menu.Construct(_pause_Menu);

            _gameplay_Menu.Open();

            return true;
        }
    }
}