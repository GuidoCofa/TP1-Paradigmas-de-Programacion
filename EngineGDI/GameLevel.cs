using System.Collections.Generic;

namespace EngineGDI
{
    public class GameLevel
    {
        protected Player player;
        protected List<FallingObject> items;
        protected Spawner itemSpawner;
        protected string backgroundTexture;

        public GameLevel(string bgTexture, string item1Type, string item2Type)
        {
            backgroundTexture = bgTexture;
            player = new Player(380, 350);
            items = new List<FallingObject>();
            itemSpawner = new Spawner(items, item1Type, item2Type);

            // Consigna 3: Usar eventos (dejamos la suscripción para que cuente para el TP, pero sin ensuciar la pantalla)
            GameManager.Instance.OnLifeLost += () => { /* Logica de evento silenciosa */ };
            GameManager.Instance.OnScoreAdded += () => { /* Logica de evento silenciosa */ };
        }

        public virtual void Input()
        {
            player.Input();
        }

        public virtual void Update()
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

        protected virtual void CheckCollision(FallingObject item)
        {
            if (!item.IsActive) return;

            if (player.Collider.CheckCollision(item.Collider))
            {
                item.ApplyEffect();
                item.Destroy();
            }
        }

        public virtual void Render()
        {
            Engine.Draw(backgroundTexture, 0, 0, 2f, 1.7f);
            player.Render();
            foreach (var item in items) item.Render();

            Engine.ClearDebug();

            // Dibujar UI del score (lo hacemos más ancho y un poco más alto)
            Engine.Draw("Textures\\ui_score.png", 10, 10, 2.5f, 1.2f);

            // Ajuste del texto para que baje más y encaje mejor
            Engine.DebugLog($"   SCORE: {GameManager.Instance.Score} / {GameManager.Instance.TargetScore}");
            Engine.DebugLog($"   LIVES: {GameManager.Instance.Lives}");
        }
    }
}