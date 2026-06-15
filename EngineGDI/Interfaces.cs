namespace EngineGDI
{
    // Consigna 7: Implementar al menos tres interfaces diferentes que tengan sentido en el juego.
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
