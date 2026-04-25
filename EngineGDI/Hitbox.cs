namespace EngineGDI
{
    public class Hitbox
    {
        // 1. Encapsulamiento Estricto: Las variables de tamaño y offset son privadas.
        private float offsetX;
        private float offsetY;
        private float width;
        private float height;

        // Variables de posición absolutas en el mundo (actualizadas por el dueño de la Hitbox).
        private float worldX;
        private float worldY;

        public Hitbox(float width, float height, float offsetX = 0, float offsetY = 0)
        {
            this.width = width;
            this.height = height;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }

        // Método para que la entidad dueña actualice la posición espacial de la Hitbox.
        public void UpdatePosition(float ownerX, float ownerY)
        {
            this.worldX = ownerX + this.offsetX;
            this.worldY = ownerY + this.offsetY;
        }

        // 1. Refactorización de Colisiones: Hitbox es la única encargada de la matemática espacial.
        // Ahora solo recibe otra Hitbox, ocultando por completo las coordenadas al exterior (GameLevel).
        public bool CheckCollision(Hitbox otherHitbox)
        {
            return this.worldX < otherHitbox.worldX + otherHitbox.width &&
                   this.worldX + this.width > otherHitbox.worldX &&
                   this.worldY < otherHitbox.worldY + otherHitbox.height &&
                   this.worldY + this.height > otherHitbox.worldY;
        }
    }
}