using System.Collections.Generic;
using Grincewicz.WaveSystem;
using UnityEngine;
namespace Grincewicz.PoolSystem
{
    public class NewPoolManager : MonoBehaviour
    {
        private static NewPoolManager _instance;
        public static NewPoolManager Instance { get => _instance; }
        [SerializeField] private List<Pool> _pools = new List<Pool>();
        public List<Pool> Pools { get => _pools; set => _pools = value; }

        private void Awake() => _instance = this;

        private void Start()
        {
            for(int i = 0; i < _pools.Count; i++)
                GenerateObjects(i, _pools[i].initialPoolSize);
        }
        /// <summary>
        /// This method can be called from any class to pool objects.
        /// </summary>
        /// <param name="poolIndex"></param>
        /// <param name="amount"></param>
        public void GenerateObjects(int poolIndex, int amount)
        {
            var pool = _pools[poolIndex].objectPool;
            var prefab = _pools[poolIndex].poolableObject;
            var container = _pools[poolIndex].objectContainer;

            for (int i = 0; i < amount; i++)
            {
                GameObject obj = Instantiate(prefab, container);
                obj.SetActive(false);
                pool.Add(obj);
            }
        }
        /// <summary>
        /// This Overloaded Method should be called from the Spawn Manager.
        /// </summary>
        /// <param name="wave"></param>
        /// <param name="container"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public List<GameObject> GenerateObjects(Wave wave, Transform container, int amount)
        {
            var pooledObjects = new List<GameObject>();
            var pool = wave.SpawnableObjects;
            for (int i = 0; i < amount; i++)
            {
                var prefab = pool[i];
                GameObject obj = Instantiate(prefab, container);
                pooledObjects.Add(obj);
                obj.SetActive(false);
            }
            return pooledObjects;
        }
        /// <summary>
        /// Creates a new pool during runtime.
        /// </summary>
        /// <param name="poolIndex"></param>
        /// <param name="pooledObject"></param>
        /// <param name="intialAmount"></param>
        /// <returns></returns>
        public Pool CreateNewPool(int poolIndex, GameObject pooledObject, int intialAmount)
        {
            var container = new GameObject($"{pooledObject.name}_container").transform;
            Instantiate(container, transform);
            var newPool = new Pool(pooledObject, container, intialAmount);
            if (poolIndex !> _pools.Count - 1)
                _pools[poolIndex] = newPool;
            else
                _pools.Add(newPool);
            return newPool;
        }
        public void DestroyPool(int poolIndex)
        {
            for(int i = 0; i < _pools[poolIndex].objectPool.Count; i++)
            {
                Destroy(_pools[poolIndex].objectPool[i]);
                Destroy(_pools[poolIndex].objectContainer);
                _pools.Remove(_pools[poolIndex]);
            }
        }
        /// <summary>
        /// Call this method to request an object from the specified pool.
        /// </summary>
        /// <param name="poolIndex"></param>
        /// <returns></returns>
        public GameObject RequestObject(int poolIndex)
        {
            var pool = _pools[poolIndex].objectPool;
            var prefab = _pools[poolIndex].poolableObject;
            var container = _pools[poolIndex].objectContainer;

            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    pool[i].SetActive(true);
                    return pool[i];
                }
            }
            GameObject newObject = Instantiate(prefab, container);
            newObject.SetActive(true);
            pool.Add(newObject);
            return newObject;
        }
        /// <summary>
        /// This Overloaded Method should be called from the Spawn Manager.
        /// </summary>
        /// <param name="pool"></param>
        /// <param name="objIndex"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public GameObject RequestObject(List<GameObject> pool ,int objIndex,Transform container)
        {
            GameObject prefab = pool[objIndex];

            if (!pool[objIndex].activeInHierarchy)
            {
                pool[objIndex].SetActive(true);
                return prefab;
            }
            else
            {
                prefab = Instantiate(prefab, container);
                return prefab;
            }
        }
    }
}
