using System.Windows.Forms;

namespace EngineGDI
{
    public class Player
    {
        // 1. Encapsulamiento: PosX y PosY son completamente privadas.
        // Nadie fuera de Player puede leerlas ni escribirlas.
        private float posX;
        private float posY;
        public Hitbox Collider { get; private set; }

        // --- CAMBIOS PARA MOVIMIENTO FLUIDO ---
        private float velocityX = 0f;
        private const float ACCEL = 10000f;  // Qué tan rápido arranca
        private const float MAX_SPEED = 2000f;
        private const float SCALE = 0.12f; // Un poco más chico como pediste

        private Animation runAnimation;

        public Player(float startX, float startY)
        {
            posX = startX;
            posY = startY;

            // 2. Composición: El Player CREA su propio Hitbox.
            // El ciclo de vida de este Hitbox está estrictamente ligado al del Player.
            // Si el Player es destruido (o recolectado por el Garbage Collector),
            // el Hitbox también lo será.
            Collider = new Hitbox(50f, 10f, 15f, 0f);
            Collider.UpdatePosition(posX, posY);

            string[] frames = { "Textures\\player_1.png", "Textures\\player_2.png", "Textures\\player_3.png", "Textures\\player_4.png" };
            runAnimation = new Animation(frames, 10f, true);
        }

        public void Input()
        {
            // Detectamos dirección de forma continua al mantener la tecla presionada
            if (Engine.IsKeyDown(Keys.Left)) velocityX -= ACCEL * Program.deltaTime;
            else if (Engine.IsKeyDown(Keys.Right)) velocityX += ACCEL * Program.deltaTime;
            else velocityX = 0; // Se detiene de inmediato cuando no se presiona nada

            // Limitamos velocidad máxima
            if (velocityX > MAX_SPEED) velocityX = MAX_SPEED;
            if (velocityX < -MAX_SPEED) velocityX = -MAX_SPEED;

            posX += velocityX * Program.deltaTime;

            // Límites de pantalla
            if (posX < 0) { posX = 0; velocityX = 0; }
            if (posX > 800 - 80) { posX = 800 - 80; velocityX = 0; }
        }

        public void Update(float deltaTime)
        {
            runAnimation.Update(deltaTime);
            // Sincronizamos la posición de la Hitbox con la posición interna del Player.
            Collider.UpdatePosition(posX, posY);
        }

        public void Render()
        {
            Engine.Draw(runAnimation.CurrentSprite, posX, posY, SCALE, SCALE, 0, 0f, 0f);
        }
    }
}