using System;

namespace EngineGDI
{
    // Consigna 2: Un Factory (por ejemplo, de ítems).
    public static class ItemFactory
    {
        public static FallingObject CreateItem(string type, float x, float y, float speed)
        {
            switch (type.ToLower())
            {
                case "good": return new GoodItem(x, y, speed);
                case "bad": return new BadItem(x, y, speed);
                default: throw new ArgumentException("Tipo de item inválido");
            }
        }
    }
}
