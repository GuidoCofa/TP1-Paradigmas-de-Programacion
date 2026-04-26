using System.Windows.Forms;

namespace EngineGDI
{
    public class VictoryScreen
    {
        private int selectedOption = 0;
        public void Input()
        {
            if (Engine.OnKeyDown(Keys.W))
                selectedOption--;

            if (Engine.OnKeyDown(Keys.S))
                selectedOption++;

            // Loop
            if (selectedOption < 0) selectedOption = 1;
            if (selectedOption > 1) selectedOption = 0;

            if (Engine.OnKeyDown(Keys.Return))
            {
                if (selectedOption == 0) // RETRY
                {
                    GameManager.Instance.StartNewGame();
                    Program.level = new GameLevel();
                    Program.currentState = Program.GameState.Playing;
                }
                else if (selectedOption == 1) // EXIT
                {
                    Program.currentState = Program.GameState.Menu;
                }
            }
        }

        public void Update() { }

        public void Render()
        {
            // Fondo de victoria
            Engine.Draw("Textures\\victory.png", 0, 0, 2f, 1.75f);

            // RETRY
            if (selectedOption == 0)
                Engine.Draw("Textures\\retrybuttonselect.png", 350, 250, 1f, 1f);
            else
                Engine.Draw("Textures\\retrybutton.png", 350, 250, 1f, 1f);

            // EXIT
            if (selectedOption == 1)
                Engine.Draw("Textures\\exitbuttonselect2.png", 350, 330, 1f, 1f);
            else
                Engine.Draw("Textures\\exitbutton2.png", 350, 330, 1f, 1f);
        }
    }
}