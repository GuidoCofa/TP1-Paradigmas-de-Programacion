using System.Windows.Forms;

namespace EngineGDI
{
    public class Menu
    {
        public void Input()
        {
            if (Engine.OnKeyDown(Keys.Return))
            {
                // 1. Reiniciamos los datos globales en el Singleton
                GameManager.Instance.StartNewGame();

                // 2. Creamos un nivel nuevo desde cero
                Program.level = new GameLevel();

                // 3. Cambiamos el estado
                Program.currentState = Program.GameState.Playing;
            }
        }

        public void Update() { }

        public void Render()
        {
            // Opcional: Si tenés una imagen "Textures\menu.png", descomentá la línea de abajo:
            // Engine.Draw("Textures\\menu.png", 0, 0, 1f, 1f, 0, 0f, 0f);

            Engine.ClearDebug();
            Engine.DebugLog("==============================");
            Engine.DebugLog("          CATCH GAME          ");
            Engine.DebugLog("==============================");
            Engine.DebugLog("");
            Engine.DebugLog("  Use LEFT and RIGHT arrows to move.");
            Engine.DebugLog("  Catch the GOOD items (+10 points).");
            Engine.DebugLog("  Avoid the BAD items (-1 life).");
            Engine.DebugLog("");
            Engine.DebugLog($"  Goal: Reach {GameManager.Instance.TargetScore} points.");
            Engine.DebugLog("");
            Engine.DebugLog("  Press ENTER to Start");
            Engine.DebugLog("==============================");
        }
    }
}