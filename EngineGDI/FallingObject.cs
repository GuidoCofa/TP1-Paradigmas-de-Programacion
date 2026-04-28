namespace EngineGDI
{
    public abstract class FallingObject
    {
        
        protected float posX;
        protected float posY;
        public bool IsActive { get; protected set; }
        public Hitbox Collider { get; protected set; } 

        protected float speed;
        protected string texturePath;
        protected float scale;

        public FallingObject(float startX, float startY, float speed)
        {
            posX = startX;
            posY = startY;
            this.speed = speed;
            IsActive = true;
        }

        public void Update(float deltaTime)
        {
            if (!IsActive) return;
            posY += speed * deltaTime;
            if (posY > 500f) IsActive = false;

            
            if (Collider != null)
                Collider.UpdatePosition(posX, posY);
        }

        public void Render()
        {
            if (IsActive) Engine.Draw(texturePath, posX, posY, scale, scale, 0, 0f, 0f);
        }

        public void Destroy() => IsActive = false;
        public abstract void ApplyEffect();
    }

    public class GoodItem : FallingObject
    {
        public GoodItem(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            texturePath = "Textures\\good.png";
            scale = 1f; 
            Collider = new Hitbox(20f, 20f, 5f, 5f);
        }
        public override void ApplyEffect()
        {
            Engine.PlaySound(@"Sounds\score.wav");
            GameManager.Instance.AddScore(10);
        }
    }

    public class BadItem : FallingObject
    {
        public BadItem(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            texturePath = "Textures\\bad.png";
            scale = 1f;
            Collider = new Hitbox(50f, 50f);
        }
        public override void ApplyEffect()
        {
            GameManager.Instance.LoseLife();
        }
    }
}