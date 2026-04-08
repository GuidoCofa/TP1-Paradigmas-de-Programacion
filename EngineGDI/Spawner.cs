using System;
using System.Collections.Generic;

namespace EngineGDI
{
    public class Spawner
    {
        private List<FallingObject> targetList;
        private Random rng;
        private float spawnTimer;

        public Spawner(List<FallingObject> listToPopulate)
        {
            targetList = listToPopulate;
            rng = new Random();
            spawnTimer = 0f;
        }

        public void Update(float deltaTime)
        {
            spawnTimer += deltaTime;
            if (spawnTimer >= 1.0f)
            {
                spawnTimer = 0f;
                float randomX = rng.Next(0, 750);

                if (rng.NextDouble() > 0.3)
                    targetList.Add(new GoodItem(randomX, -50, 150f));
                else
                    targetList.Add(new BadItem(randomX, -50, 200f));
            }
        }
    }
}