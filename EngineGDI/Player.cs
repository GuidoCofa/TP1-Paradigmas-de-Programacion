using System;
using System.Windows.Forms;

namespace EngineGDI
{
    // Consigna 7: Uso de interfaces
    public class Player : IUpdatable, IRenderable, ICollidable
    {

        // Consigna 5: Componente Transform
        public Transform TransformComp { get; private set; }
        public Hitbox Collider { get; private set; }

  
        private float velocityX = 0f;
        private const float ACCEL = 1000f; 
        private const float MAX_SPEED = 2000f;
        private const float SCALE = 1f; 

        private Animation runAnimation;
        private float stepTimer = 0f;
        private const float STEP_INTERVAL = 0.3f; 

        public Player(float startX, float startY)
        {
            TransformComp = new Transform(startX, startY);

            Collider = new Hitbox(50f, 10f, 15f, 0f);
            Collider.UpdatePosition(TransformComp.Position.X, TransformComp.Position.Y);

            string[] frames = { "Textures\\Character1.png"
                    , "Textures\\Character2.png"
                    , "Textures\\Character3.png"
                    , "Textures\\Character4.png"
                    , "Textures\\Character5.png"        
                    , "Textures\\Character6.png"
                    , "Textures\\Character7.png"
                    , "Textures\\Character8.png" };
            runAnimation = new Animation(frames, 10f, true);
        }

        public void Input()
        {

            if (Engine.IsKeyDown(Keys.A)) velocityX -= ACCEL * Program.deltaTime;
            else if (Engine.IsKeyDown(Keys.D)) velocityX += ACCEL * Program.deltaTime;
            else velocityX = 0;

            
            if (velocityX > MAX_SPEED) velocityX = MAX_SPEED;
            if (velocityX < -MAX_SPEED) velocityX = -MAX_SPEED;

            TransformComp.Position.X += velocityX * Program.deltaTime;

            
            if (TransformComp.Position.X < 0) { TransformComp.Position.X = 0; velocityX = 0; }
            if (TransformComp.Position.X > 800 - 80) { TransformComp.Position.X = 800 - 80; velocityX = 0; }
        }

        public void Update(float deltaTime)
        {
            if (Math.Abs(velocityX) > 1f)
            {
                runAnimation.Update(deltaTime);
                stepTimer += deltaTime;
                if (stepTimer >= STEP_INTERVAL)
                {
                    Engine.PlaySound(@"Sounds\move.wav");
                    stepTimer -= STEP_INTERVAL;
                }
            }
            else
            {
                runAnimation.Reset();
                stepTimer = STEP_INTERVAL; 
            }
            Collider.UpdatePosition(TransformComp.Position.X, TransformComp.Position.Y);
        }

        public void Render()
        {
            Engine.Draw(runAnimation.CurrentSprite, TransformComp.Position.X, TransformComp.Position.Y, SCALE, SCALE, 0, 0f, 0f);
        }
    }
}