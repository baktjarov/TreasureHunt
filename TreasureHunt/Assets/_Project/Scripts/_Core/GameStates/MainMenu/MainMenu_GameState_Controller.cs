using Interfaces;

namespace GameStates
{
    public class MainMenu_GameState_Controller : IInitializable<bool>
    {
        public MainMenu_GameState_Model model { get; set; }
        public MainMenu_GameState_View view { get; set; }

        public bool Initialize()
        {
            model = new MainMenu_GameState_Model();
            view = new MainMenu_GameState_View(model);

            model.Initialize();
            view.Initialize();

            return true;
        }
    }
}