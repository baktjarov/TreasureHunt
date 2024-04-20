using Interfaces;

namespace Core.GameStates
{
    public class Gameplay_GameState_Controller : IInitializable<bool>
    {
        public Gameplay_GameState_Model model;
        public Gameplay_GameState_View view;

        public bool Initialize()
        {
            model = new Gameplay_GameState_Model();
            view = new Gameplay_GameState_View(model);

            model.Initialize();
            view.Initialize();

            return true;
        }
    }
}