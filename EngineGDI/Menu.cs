using System.Windows.Forms;

namespace EngineGDI
{
    public class Menu
    {
        private int selectedOption = 0;

        public void Input()
        {
            
            if (Engine.OnKeyDown(Keys.W))
                selectedOption--;

            if (Engine.OnKeyDown(Keys.S))
                selectedOption++;

            
            if (selectedOption < 0) selectedOption = 1;
            if (selectedOption > 1) selectedOption = 0;

            
            if (Engine.OnKeyDown(Keys.Return))
            {
                if (selectedOption == 0) 
                {
                    GameManager.Instance.StartNewGame();
                    Program.level = new GameLevel();
                    Program.currentState = Program.GameState.Playing;
                }
                else if (selectedOption == 1) 
                {
                    Engine.Window.Close();
                }
            }
        }

        public void Update() { }

        public void Render()
        {
           
            Engine.Draw("Textures\\menuscreen.png", 0, 0, 2f, 1.75f);

            
            if (selectedOption == 0)
                Engine.Draw("Textures\\playbuttonselect.png", 350, 250, 1f, 1f);
            else
                Engine.Draw("Textures\\playbutton.png", 350, 250, 1f, 1f);

            
            if (selectedOption == 1)
                Engine.Draw("Textures\\exitbuttonselect.png", 350, 300, 1f, 1f);
            else
                Engine.Draw("Textures\\exitbutton.png", 350, 300, 1f, 1f);
        }
    }
}