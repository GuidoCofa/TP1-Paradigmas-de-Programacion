using System.Windows.Forms;

namespace EngineGDI
{
    public class VictoryScreen
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
            // Opcional: Si tenés una imagen "Textures\victory.png", descomentá esto:
            // Engine.Draw("Textures\\victory.png", 0, 0, 1f, 1f, 0, 0f, 0f);

            Engine.ClearDebug();
            Engine.DebugLog("==============================");
            Engine.DebugLog("           VICTORY!           ");
            Engine.DebugLog("==============================");
            Engine.DebugLog("");
            Engine.DebugLog("  Congratulations! You reached the goal!");
            Engine.DebugLog($"  Final Score: {GameManager.Instance.Score}");
            Engine.DebugLog($"  Lives remaining: {GameManager.Instance.Lives}");
            Engine.DebugLog("");
            Engine.DebugLog("  Press ENTER to return to Menu");
        }
    }
}