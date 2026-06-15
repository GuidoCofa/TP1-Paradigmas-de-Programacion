namespace EngineGDI
{
    // Consigna 5: Un componente Transform que tenga las propiedades de Posición, Rotación y Escala (Vector2).
    public class Transform
    {
        public Vector2 Position { get; set; }
        public Vector2 Rotation { get; set; }
        public Vector2 Scale { get; set; }

        public Transform(float x, float y)
        {
            Position = new Vector2(x, y);
            Rotation = new Vector2(0, 0);
            Scale = new Vector2(1f, 1f);
        }
    }
}
