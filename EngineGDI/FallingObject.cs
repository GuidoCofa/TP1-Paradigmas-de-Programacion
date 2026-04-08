namespace EngineGDI
{
    public abstract class FallingObject
    {
        public float PosX { get; protected set; }
        public float PosY { get; protected set; }
        public bool IsActive { get; protected set; }
        public Hitbox Collider { get; protected set; } // Cambiado a protected para editarlo en los hijos

        protected float speed;
        protected string texturePath;
        protected float scale;

        public FallingObject(float startX, float startY, float speed)
        {
            PosX = startX;
            PosY = startY;
            this.speed = speed;
            IsActive = true;
        }

        public void Update(float deltaTime)
        {
            if (!IsActive) return;
            PosY += speed * deltaTime;
            if (PosY > 500f) IsActive = false;
        }

        public void Render()
        {
            if (IsActive) Engine.Draw(texturePath, PosX, PosY, scale, scale, 0, 0f, 0f);
        }

        public void Destroy() => IsActive = false;
        public abstract void ApplyEffect();
    }

    public class GoodItem : FallingObject
    {
        public GoodItem(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            texturePath = "Textures\\good.png";
            scale = 0.07f; // MANZANA MÁS CHICA
            // Hitbox pequeña para que cuente solo si cae en el medio
            Collider = new Hitbox(20f, 20f, 5f, 5f);
        }
        public override void ApplyEffect() => GameManager.Instance.AddScore(10);
    }

    public class BadItem : FallingObject
    {
        public BadItem(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            texturePath = "Textures\\bad.png";
            scale = 0.18f; // BOMBA MÁS GRANDE
            Collider = new Hitbox(50f, 50f);
        }
        public override void ApplyEffect() => GameManager.Instance.LoseLife();
    }
}