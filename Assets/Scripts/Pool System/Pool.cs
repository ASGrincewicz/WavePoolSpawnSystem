using System.Collections.Generic;
using UnityEngine;
namespace Grincewicz.PoolSystem
{
    [System.Serializable]
    public struct Pool
    {
        [Tooltip("Name the pool for better organization.")]
        public string poolName;
        [Tooltip("Which game object to you want to pool?")]
        public GameObject poolableObject;
        [Tooltip("How many objects should the pool have to start?")]
        public int initialPoolSize;
        public List<GameObject> objectPool;

        public Pool(string poolName, GameObject poolableObject)
        {
            this.poolName = poolName;
            this.poolableObject = poolableObject;
            initialPoolSize = 0;
            objectPool = new List<GameObject>();
        }
        public Pool(string poolName, GameObject poolableObject, int initialPoolSize)
        {
            this.poolName = poolName;
            this.poolableObject = poolableObject;
            this.initialPoolSize = initialPoolSize;
            objectPool = new List<GameObject>();
        }
    }
}
