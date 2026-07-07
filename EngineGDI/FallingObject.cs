namespace EngineGDI
{
    // Consigna 1: Caso de herencia (GoodItem y BadItem heredan de FallingObject)
    // Consigna 7: Uso de interfaces
    public abstract class FallingObject : IUpdatable, IRenderable, ICollidable
    {
        public bool IsActive { get; protected set; }
        public Hitbox Collider { get; protected set; } 

        protected float speed;

        // Consigna 5 y 6: Componente Transform y Renderer
        public Transform TransformComp { get; protected set; }
        public Renderer RendererComp { get; protected set; }

        public FallingObject(float startX, float startY, float speed)
        {
            TransformComp = new Transform(startX, startY);
            this.speed = speed;
            IsActive = true;
        }

        public virtual void Reset(float startX, float startY, float speed)
        {
            TransformComp.Position = new Vector2(startX, startY);
            this.speed = speed;
            IsActive = true;
        }

        public void Update(float deltaTime)
        {
            if (!IsActive) return;
            var pos = TransformComp.Position;
            pos.Y += speed * deltaTime;
            TransformComp.Position = pos;

            if (TransformComp.Position.Y > 500f) IsActive = false;

            if (Collider != null)
                Collider.UpdatePosition(TransformComp.Position.X, TransformComp.Position.Y);
        }

        public void Render()
        {
            if (IsActive && RendererComp != null) 
                RendererComp.Draw(TransformComp);
        }

        public void Destroy() => IsActive = false;
        public abstract void ApplyEffect();
    }

    public class GoodItem : FallingObject
    {
        public GoodItem(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            RendererComp = new Renderer("Textures\\good.png", 0, 0);
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
            RendererComp = new Renderer("Textures\\bad.png", 0, 0);
            Collider = new Hitbox(50f, 50f);
        }
        public override void ApplyEffect()
        {
            GameManager.Instance.LoseLife();
        }
    }

    public class L1ItemA : FallingObject
    {
        public L1ItemA(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            RendererComp = new Renderer("Textures\\l1_itemA.png", 0, 0);
            Collider = new Hitbox(30f, 30f, 5f, 5f);
        }
        public override void ApplyEffect()
        {
            Engine.PlaySound(@"Sounds\score.wav");
            GameManager.Instance.AddScore(10);
        }
    }

    public class L1ItemB : FallingObject
    {
        public L1ItemB(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            RendererComp = new Renderer("Textures\\l1_itemB.png", 0, 0);
            Collider = new Hitbox(30f, 30f, 5f, 5f);
        }
        public override void ApplyEffect()
        {
            GameManager.Instance.LoseLife();
        }
    }

    public class L2ItemA : FallingObject
    {
        public L2ItemA(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            RendererComp = new Renderer("Textures\\l2_itemA.png", 0, 0);
            Collider = new Hitbox(40f, 40f, 5f, 5f);
        }
        public override void ApplyEffect()
        {
            Engine.PlaySound(@"Sounds\score.wav");
            GameManager.Instance.AddScore(15);
        }
    }

    public class L2ItemB : FallingObject
    {
        public L2ItemB(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            RendererComp = new Renderer("Textures\\l2_itemB.png", 0, 0);
            Collider = new Hitbox(40f, 40f, 5f, 5f);
        }
        public override void ApplyEffect()
        {
            GameManager.Instance.LoseLife();
        }
    }

    public class L3ItemA : FallingObject
    {
        public L3ItemA(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            RendererComp = new Renderer("Textures\\l3_itemA.png", 0, 0);
            Collider = new Hitbox(35f, 35f, 5f, 5f);
        }
        public override void ApplyEffect()
        {
            Engine.PlaySound(@"Sounds\score.wav");
            GameManager.Instance.AddScore(25);
        }
    }

    public class L3ItemB : FallingObject
    {
        public L3ItemB(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            RendererComp = new Renderer("Textures\\l3_itemB.png", 0, 0);
            Collider = new Hitbox(35f, 35f, 5f, 5f);
        }
        public override void ApplyEffect()
        {
            GameManager.Instance.LoseLife();
        }
    }

    public class GoldenApple : FallingObject
    {
        public GoldenApple(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            RendererComp = new Renderer("Textures\\golden_apple.png", 0, 0);
            Collider = new Hitbox(30f, 30f, 5f, 5f);
        }
        public override void ApplyEffect()
        {
            Engine.PlaySound(@"Sounds\score.wav");
            GameManager.Instance.AddScore(30); // Balanceado: Suma 30 puntos
        }
    }

    public class DeadApple : FallingObject
    {
        public DeadApple(float startX, float startY, float speed) : base(startX, startY, speed)
        {
            RendererComp = new Renderer("Textures\\dead_apple.png", 0, 0);
            Collider = new Hitbox(30f, 30f, 5f, 5f);
        }
        public override void ApplyEffect()
        {
            GameManager.Instance.AddScore(-15);
        }
    }
}