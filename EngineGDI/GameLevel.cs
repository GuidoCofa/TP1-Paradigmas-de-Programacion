using System.Collections.Generic;

namespace EngineGDI
{
    public class GameLevel
    {
        private Player player;
        private List<FallingObject> items;
        private Spawner itemSpawner;


        public GameLevel()
        {
            player = new Player(380, 350);
            items = new List<FallingObject>();
            itemSpawner = new Spawner(items);

            // Consigna 3: Usar eventos
            GameManager.Instance.OnLifeLost += () => Engine.DebugLog("Evento: ¡Vida perdida!");
            GameManager.Instance.OnScoreAdded += () => Engine.DebugLog("Evento: ¡Puntaje obtenido!");
        }

        public void Input()
        {
            player.Input();
        }

        public void Update()
        {
            float dt = Program.deltaTime;

            player.Update(dt);
            itemSpawner.Update(dt);

            foreach (var item in items)
            {
                item.Update(dt);
                CheckCollision(item);
            }

            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (!items[i].IsActive)
                {
                    itemSpawner.ReturnItem(items[i]);
                    items.RemoveAt(i);
                }
            }

            if (GameManager.Instance.IsVictory())
            {
                Engine.PlaySound(@"Sounds\victory.wav");
                Program.currentState = Program.GameState.Victory;
            }
            else if (GameManager.Instance.IsDefeat())
            {
                Engine.PlaySound(@"Sounds\defeat.wav");
                Program.currentState = Program.GameState.Defeat;
            }
        }

        private void CheckCollision(FallingObject item)
        {
            if (!item.IsActive) return;


            if (player.Collider.CheckCollision(item.Collider))
            {
                item.ApplyEffect();
                item.Destroy();
            }
        }

        public void Render()
        {
            Engine.Draw("Textures\\background.png", 0, 0, 2f, 1.7f);
            player.Render();
            foreach (var item in items) item.Render();

            Engine.ClearDebug();

            Engine.DebugLog("");
            Engine.DebugLog("");
            Engine.DebugLog("");
            Engine.DebugLog("");

            Engine.DebugLog($"SCORE: {GameManager.Instance.Score} / {GameManager.Instance.TargetScore}");
            Engine.DebugLog($"LIVES: {GameManager.Instance.Lives}");

        }
    }
}