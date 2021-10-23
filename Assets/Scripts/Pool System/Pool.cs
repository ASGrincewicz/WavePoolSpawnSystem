using System.Collections.Generic;
using UnityEngine;
namespace Grincewicz.PoolSystem
{
    [System.Serializable]
    public struct Pool
    {
        public GameObject poolableObject;
        public Transform objectContainer;
        public int initialPoolSize;
        public List<GameObject> objectPool;

        public Pool(GameObject poolableObject, Transform container)
        {
            this.poolableObject = poolableObject;
            objectContainer = container;
            initialPoolSize = 0;
            objectPool = new List<GameObject>();
        }
        public Pool(GameObject poolableObject, Transform container, int initialPoolSize)
        {
            this.poolableObject = poolableObject;
            objectContainer = container;
            this.initialPoolSize = initialPoolSize;
            objectPool = new List<GameObject>();
        }
    }
}
