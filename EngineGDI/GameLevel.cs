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

            items.RemoveAll(i => !i.IsActive);

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

            // 1. Refactorización de Colisiones: GameLevel NO tiene acceso a la posición real del Player ni del Item.
            // GameLevel solo delega la verificación espacial a la Hitbox, asegurando el encapsulamiento.
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
            Engine.DebugLog($"SCORE: {GameManager.Instance.Score} / {GameManager.Instance.TargetScore}");
            Engine.DebugLog($"LIVES: {GameManager.Instance.Lives}");
        }
    }
}