using System;
using System.Collections.Generic;

namespace EngineGDI
{
    // Consigna 4: Implementación de un Pool GENÉRICO
    public class GenericPool<T> where T : class
    {
        private List<T> pool = new List<T>();
        private Func<T> objectGenerator;

        public GenericPool(Func<T> objectGenerator)
        {
            this.objectGenerator = objectGenerator;
        }

        public T Get()
        {
            if (pool.Count > 0)
            {
                T item = pool[pool.Count - 1];
                pool.RemoveAt(pool.Count - 1);
                return item;
            }
            return objectGenerator();
        }

        public void ReturnToPool(T item)
        {
            pool.Add(item);
        }
    }
}
