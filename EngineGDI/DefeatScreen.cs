using System.Windows.Forms;

namespace EngineGDI
{
    public class DefeatScreen
    {
        public void Input()
        {
            if (Engine.OnKeyDown(Keys.Return) || Engine.OnKeyDown(Keys.Escape))
            {
                Program.currentState = Program.GameState.Menu;
            }
        }

        public void Update() { }

        public void Render()
        {
            // Opcional: Si tenés una imagen "Textures\defeat.png", descomentá esto:
            // Engine.Draw("Textures\\defeat.png", 0, 0, 1f, 1f, 0, 0f, 0f);

            Engine.ClearDebug();
            Engine.DebugLog("==============================");
            Engine.DebugLog("          GAME OVER           ");
            Engine.DebugLog("==============================");
            Engine.DebugLog("");
            Engine.DebugLog("  You lost all your lives...");
            Engine.DebugLog($"  Final Score: {GameManager.Instance.Score}");
            Engine.DebugLog("");
            Engine.DebugLog("  Press ENTER to return to Menu");
        }
    }
}