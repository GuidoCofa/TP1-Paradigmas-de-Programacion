using System;
using System.Collections.Generic;

namespace EngineGDI
{
    public class Spawner
    {
        private List<FallingObject> targetList;
        private Random rng;
        private float spawnTimer;

        // Consigna 4: Uso de GenericPool
        private GenericPool<GoodItem> goodPool;
        private GenericPool<BadItem> badPool;

        public Spawner(List<FallingObject> listToPopulate)
        {
          
            targetList = listToPopulate;
            rng = new Random();
            spawnTimer = 0f;
            
            // Consigna 2: Uso del Factory en la inicialización del Pool
            goodPool = new GenericPool<GoodItem>(() => (GoodItem)ItemFactory.CreateItem("good", 0, 0, 0));
            badPool = new GenericPool<BadItem>(() => (BadItem)ItemFactory.CreateItem("bad", 0, 0, 0));
        }

        public void ReturnItem(FallingObject item)
        {
            if (item is GoodItem good) goodPool.ReturnToPool(good);
            else if (item is BadItem bad) badPool.ReturnToPool(bad);
        }

        public void Update(float deltaTime)
        {
            spawnTimer += deltaTime;
            if (spawnTimer >= 1.0f)
            {
                spawnTimer = 0f;
                float randomX = rng.Next(0, 750);

                if (rng.NextDouble() > 0.3)
                {
                    var item = goodPool.Get();
                    item.Reset(randomX, -50, 150f);
                    targetList.Add(item);
                }
                else
                {
                    var item = badPool.Get();
                    item.Reset(randomX, -50, 200f);
                    targetList.Add(item);
                }
            }
        }
    }
}