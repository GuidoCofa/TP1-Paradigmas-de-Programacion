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

            if (Program.currentLevelIndex == 1 || Program.currentLevelIndex == 2)
            {
                if (selectedOption < 0) selectedOption = 1;
                if (selectedOption > 1) selectedOption = 0;
            }
            else
            {
                selectedOption = 0; // Nivel 3: Solo una opción
            }

            if (Engine.OnKeyDown(Keys.Return))
            {
                if (selectedOption == 0)
                {
                    if (Program.currentLevelIndex == 1)
                    {
                        Program.currentLevelIndex = 2;
                        GameManager.Instance.SaveLevelScore();
                        GameManager.Instance.StartNewGame(2);
                        Program.level = new Level2();
                        Program.currentState = Program.GameState.Playing;
                    }
                    else if (Program.currentLevelIndex == 2)
                    {
                        Program.currentLevelIndex = 3;
                        GameManager.Instance.SaveLevelScore();
                        GameManager.Instance.StartNewGame(3);
                        Program.level = new Level3();
                        Program.currentState = Program.GameState.Playing;
                    }
                    else
                    {
                        System.Windows.Forms.Application.Exit(); // Cierra el juego al ganar el nivel 3
                    }
                }
                else if (selectedOption == 1) 
                {
                    Program.currentState = Program.GameState.Menu;
                }
            }
        }

        public void Update() { }

        public void Render()
        {
            Engine.Draw("Textures\\victory.png", 0, 0, 2f, 1.75f);

            if (Program.currentLevelIndex == 1 || Program.currentLevelIndex == 2)
            {
                // Botón continuar
                if (selectedOption == 0)
                    Engine.Draw("Textures\\continuebuttonselect.png", 300, 250, 1f, 1f);
                else
                    Engine.Draw("Textures\\continuebutton.png", 300, 250, 1f, 1f);

                // Botón salir al menú
                if (selectedOption == 1)
                    Engine.Draw("Textures\\exitbuttonselect2.png", 350, 330, 1f, 1f);
                else
                    Engine.Draw("Textures\\exitbutton2.png", 350, 330, 1f, 1f);
            }
            else
            {
                // Solo un botón de EXIT en el nivel 3
                if (selectedOption == 0)
                    Engine.Draw("Textures\\exitbuttonselect2.png", 350, 300, 1f, 1f);
                else
                    Engine.Draw("Textures\\exitbutton2.png", 350, 300, 1f, 1f);
            }
        }
    }
}