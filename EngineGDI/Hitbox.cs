namespace EngineGDI
{
    public class Hitbox
    {
        
        private float offsetX;
        private float offsetY;
        private float width;
        private float height;
        private float worldX;
        private float worldY;

        public Hitbox(float width, float height, float offsetX = 0, float offsetY = 0)
        {
            this.width = width;
            this.height = height;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }

        public void UpdatePosition(float ownerX, float ownerY)
        {
            this.worldX = ownerX + this.offsetX;
            this.worldY = ownerY + this.offsetY;
        }


        public bool CheckCollision(Hitbox otherHitbox)
        {
            return this.worldX < otherHitbox.worldX + otherHitbox.width &&
                   this.worldX + this.width > otherHitbox.worldX &&
                   this.worldY < otherHitbox.worldY + otherHitbox.height &&
                   this.worldY + this.height > otherHitbox.worldY;
        }
    }
}