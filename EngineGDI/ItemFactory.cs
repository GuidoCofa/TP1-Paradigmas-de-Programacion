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
                case "l1_itema": return new L1ItemA(x, y, speed);
                case "l1_itemb": return new L1ItemB(x, y, speed);
                case "l2_itema": return new L2ItemA(x, y, speed);
                case "l2_itemb": return new L2ItemB(x, y, speed);
                case "l3_itema": return new L3ItemA(x, y, speed);
                case "l3_itemb": return new L3ItemB(x, y, speed);
                case "golden_apple": return new GoldenApple(x, y, speed);
                default: throw new ArgumentException("Tipo de item inválido");
            }
        }
    }
}
