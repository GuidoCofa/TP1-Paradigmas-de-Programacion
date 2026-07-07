namespace EngineGDI
{
    // Consigna 7: 
    public interface IRenderable
    {
        void Render();
    }

    public interface ICollidable
    {
        Hitbox Collider { get; }
    }

    public interface IUpdatable
    {
        void Update(float deltaTime);
    }
}
