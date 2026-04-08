using System.Windows.Forms;

namespace EngineGDI
{
    public class Player
    {
        public float PosX { get; private set; }
        public float PosY { get; private set; }
        public Hitbox Collider { get; private set; }

        // --- CAMBIOS PARA MOVIMIENTO FLUIDO ---
        private float velocityX = 0f;
        private const float ACCEL = 3500f;  // Qué tan rápido arranca
        private const float FRICTION = 0.88f; // Qué tanto desliza (0.1 a 0.9)
        private const float MAX_SPEED = 900f;
        private const float SCALE = 0.12f; // Un poco más chico como pediste

        private Animation runAnimation;

        public Player(float startX, float startY)
        {
            PosX = startX;
            PosY = startY;

            // HITBOX CORREGIDA: Ahora es delgada y está en la "boca" del canasto
            // Ancho 50, Alto 10, desplazada un poco a la derecha (15) para centrarla
            Collider = new Hitbox(50f, 10f, 15f, 0f);

            string[] frames = { "Textures\\player_1.png", "Textures\\player_2.png", "Textures\\player_3.png", "Textures\\player_4.png" };
            runAnimation = new Animation(frames, 10f, true);
        }

        public void Input()
        {
            // Detectamos dirección
            if (Engine.OnKeyDown(Keys.Left)) velocityX -= ACCEL * Program.deltaTime;
            else if (Engine.OnKeyDown(Keys.Right)) velocityX += ACCEL * Program.deltaTime;
            else velocityX *= FRICTION; // Deslizamiento cuando no presionas nada

            // Limitamos velocidad máxima
            if (velocityX > MAX_SPEED) velocityX = MAX_SPEED;
            if (velocityX < -MAX_SPEED) velocityX = -MAX_SPEED;

            PosX += velocityX * Program.deltaTime;

            // Límites de pantalla
            if (PosX < 0) { PosX = 0; velocityX = 0; }
            if (PosX > 800 - 80) { PosX = 800 - 80; velocityX = 0; }
        }

        public void Update(float deltaTime)
        {
            runAnimation.Update(deltaTime);
        }

        public void Render()
        {
            Engine.Draw(runAnimation.CurrentSprite, PosX, PosY, SCALE, SCALE, 0, 0f, 0f);
        }
    }
}