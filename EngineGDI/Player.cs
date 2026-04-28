using System;
using System.Windows.Forms;

namespace EngineGDI
{
    public class Player
    {

        private float posX;
        private float posY;
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
            posX = startX;
            posY = startY;


            Collider = new Hitbox(50f, 10f, 15f, 0f);
            Collider.UpdatePosition(posX, posY);

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

            posX += velocityX * Program.deltaTime;

            
            if (posX < 0) { posX = 0; velocityX = 0; }
            if (posX > 800 - 80) { posX = 800 - 80; velocityX = 0; }
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
            Collider.UpdatePosition(posX, posY);
        }

        public void Render()
        {
            Engine.Draw(runAnimation.CurrentSprite, posX, posY, SCALE, SCALE, 0, 0f, 0f);
        }
    }
}