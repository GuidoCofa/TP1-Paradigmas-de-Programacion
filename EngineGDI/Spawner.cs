using System;
using System.Collections.Generic;

namespace EngineGDI
{
    public class Spawner
    {
        private List<FallingObject> targetList;
        private Random rng;
        private float spawnTimer;

        private GenericPool<FallingObject> item1Pool;
        private GenericPool<FallingObject> item2Pool;
        private GenericPool<FallingObject> goldenApplePool;
        private GenericPool<FallingObject> deadApplePool;
        private Type item1ClassType;
        private Type goldenAppleClassType;
        private Type deadAppleClassType;

        public Spawner(List<FallingObject> listToPopulate, string item1Type, string item2Type)
        {
            targetList = listToPopulate;
            rng = new Random();
            spawnTimer = 0f;
            
            item1Pool = new GenericPool<FallingObject>(() => ItemFactory.CreateItem(item1Type, 0, 0, 0));
            item2Pool = new GenericPool<FallingObject>(() => ItemFactory.CreateItem(item2Type, 0, 0, 0));
            goldenApplePool = new GenericPool<FallingObject>(() => ItemFactory.CreateItem("golden_apple", 0, 0, 0));
            deadApplePool = new GenericPool<FallingObject>(() => ItemFactory.CreateItem("dead_apple", 0, 0, 0));

            var temp1 = item1Pool.Get();
            item1ClassType = temp1.GetType();
            item1Pool.ReturnToPool(temp1);

            var tempGolden = goldenApplePool.Get();
            goldenAppleClassType = tempGolden.GetType();
            goldenApplePool.ReturnToPool(tempGolden);

            var tempDead = deadApplePool.Get();
            deadAppleClassType = tempDead.GetType();
            deadApplePool.ReturnToPool(tempDead);
        }

        public void ReturnItem(FallingObject item)
        {
            if (item.GetType() == goldenAppleClassType)
            {
                goldenApplePool.ReturnToPool(item);
            }
            else if (item.GetType() == deadAppleClassType)
            {
                deadApplePool.ReturnToPool(item);
            }
            else if (item.GetType() == item1ClassType) 
            {
                item1Pool.ReturnToPool(item);
            }
            else
            {
                item2Pool.ReturnToPool(item);
            }
        }

        public void Update(float deltaTime)
        {
            spawnTimer += deltaTime;
            if (spawnTimer >= 1.0f)
            {
                spawnTimer = 0f;
                float randomX = rng.Next(0, 750);
                double rand = rng.NextDouble();
                float speedVariation = (float)(rng.Next(-20, 31)); // Variación de -20 a +30

                if (rand > 0.95) // 5% de probabilidad
                {
                    var item = goldenApplePool.Get();
                    item.Reset(randomX, -50, 250f + speedVariation);
                    targetList.Add(item);
                }
                else if (rand > 0.90) // 5% de probabilidad (90% a 95%)
                {
                    var item = deadApplePool.Get();
                    item.Reset(randomX, -50, 250f + speedVariation);
                    targetList.Add(item);
                }
                else if (rand > 0.45) // 45% de probabilidad
                {
                    var item = item1Pool.Get();
                    item.Reset(randomX, -50, 150f + speedVariation);
                    targetList.Add(item);
                }
                else // 45% de probabilidad
                {
                    var item = item2Pool.Get();
                    item.Reset(randomX, -50, 200f + speedVariation);
                    targetList.Add(item);
                }
            }
        }
    }
}