namespace EngineGDI
{
    // Consigna 6: Un componente Renderer que tenga la textura, tamaño base y función de dibujar, recibe un Transform.
    public class Renderer
    {
        public string TexturePath { get; set; }
        public Vector2 BaseSize { get; set; }

        public Renderer(string texturePath, float baseWidth, float baseHeight)
        {
            TexturePath = texturePath;
            BaseSize = new Vector2(baseWidth, baseHeight);
        }

        public void Draw(Transform transform)
        {
            if (!string.IsNullOrEmpty(TexturePath) && transform != null)
            {
                Engine.Draw(TexturePath, transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, transform.Rotation.X, 0f, 0f);
            }
        }
    }
}
