namespace EngineGDI
{
    public class Hitbox
    {
        public float OffsetX { get; private set; }
        public float OffsetY { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }

        public Hitbox(float width, float height, float offsetX = 0, float offsetY = 0)
        {
            Width = width;
            Height = height;
            OffsetX = offsetX;
            OffsetY = offsetY;
        }

        public bool CheckCollision(float myX, float myY, float otherX, float otherY, Hitbox otherHitbox)
        {
            float myActualX = myX + OffsetX;
            float myActualY = myY + OffsetY;
            float otherActualX = otherX + otherHitbox.OffsetX;
            float otherActualY = otherY + otherHitbox.OffsetY;

            return myActualX < otherActualX + otherHitbox.Width &&
                   myActualX + Width > otherActualX &&
                   myActualY < otherActualY + otherHitbox.Height &&
                   myActualY + Height > otherActualY;
        }
    }
}