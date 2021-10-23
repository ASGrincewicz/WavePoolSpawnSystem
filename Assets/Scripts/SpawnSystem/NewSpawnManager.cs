// Aaron Grincewicz ASGrincewicz@icloud.com 10/18/2021
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Grincewicz.WaveSystem;
using Grincewicz.PoolSystem;
namespace Grincewicz.SpawnSystem
{
    public class NewSpawnManager : MonoBehaviour
    {
        public bool isSingle = true;
        [SerializeField] private Transform _spawnContainer;
        [SerializeField] private SpawnBounds2D _spawnBound2D;
        [SerializeField] private SpawnBounds3D _spawnBounds3D;
        [SerializeField] private List<GameObject> _pooledObjects;
        private WaveManager _waveManager;
        private NewPoolManager _poolManager;
        private int CurrentWave { get => _waveManager.CurrentWave;
                                  set => _waveManager.CurrentWave = value; }

        private void Start()
        {
            _waveManager = WaveManager.Instance;
            _poolManager = NewPoolManager.Instance;
            if (isSingle)
            {
                var singleWave = _waveManager.GetSingleWave("one");
                StartCoroutine(SpawnRoutineSingle(singleWave));
            }
            else
            {
                var firstSequence = _waveManager.GetWaveFromSequence(_waveManager.FirstWaveSequence);
                StartCoroutine(SpawnRoutineSequence(firstSequence));
            }
        }
        #region Get Bounds
        /// <summary>
        /// This method returns the current boundaries.
        /// Pass in 'true' for 3D bounds, or 'false' for
        /// 2D bounds.
        /// </summary>
        /// <param name="is3D"></param>
        /// <returns></returns>
        private Vector3 GetBounds(bool is3D)
        {
            if (is3D)
            {
                var bounds = _spawnBounds3D;
                return new Vector3(
                        Random.Range(bounds.xBounds.x, bounds.xBounds.y),
                        Random.Range(bounds.yBounds.x, bounds.yBounds.y),
                        Random.Range(bounds.zBounds.x, bounds.zBounds.y));
            }
            else
            {
                var bounds = _spawnBound2D;
                return new Vector3(
               Random.Range(bounds.leftBoundary, bounds.rightBoundary),
               Random.Range(bounds.topBoundary, bounds.bottomBoundary), bounds.zPosition);
            }
        }
        #endregion

        #region Spawn Routines
        /// <summary>
        /// Start this Coroutine to spawn a single wave in a 3D space.
        /// </summary>
        /// <returns></returns>
        public IEnumerator SpawnRoutineSingle(WaveAsset waveAsset)
        {
            var wave = waveAsset.GetWave;
            _pooledObjects = _poolManager.GenerateObjects(wave,
                                                        _spawnContainer,
                                                        wave.SpawnableObjects.Count);
            waveAsset.GetWave.SpawnInterval = new WaitForSeconds(wave.SpawnDelay);
            for(int i = 0; i < wave.SpawnableObjects.Count; i++)
            {
                yield return wave.SpawnInterval;
                SpawnObject(wave, i);
            }
            Debug.Log("Wave Complete");
        }
        /// <summary>
        /// Start this Coroutine to spawn multiple waves.
        /// </summary>
        /// <returns></returns>
        public IEnumerator SpawnRoutineSequence(WaveSequenceAsset waveSequence)
        {
            List<WaveAsset> sequence = waveSequence.GetWaveSequence.Sequence;
            Wave wave = sequence[CurrentWave].GetWave;
            int Count = wave.SpawnableObjects.Count;
            _pooledObjects = _poolManager.GenerateObjects(wave, _spawnContainer, Count);
            wave.SpawnInterval = new WaitForSeconds(wave.SpawnDelay);

            for (int i = 0; i < Count; i++)
            {
                yield return wave.SpawnInterval;
                SpawnObject(wave, i);
            }

            if (CurrentWave < sequence.Count -1)
            {
                CurrentWave++;
                StartCoroutine(SpawnRoutineSequence(waveSequence));
            }
            else
                Debug.Log("Sequence Complete");
        }
        /// <summary>
        /// Takes the current wave and index from the Coroutine in which it's called
        /// and spawns an object.
        /// </summary>
        /// <param name="wave"></param>
        /// <param name="i"></param>
        private void SpawnObject(Wave wave, int i)
        {
            GameObject spawnedObject = null;
                if (wave.IsRandom)
                spawnedObject = _poolManager.RequestObject(_pooledObjects,
                                            Random.Range(0, _pooledObjects.Count - 1),
                                            _spawnContainer);
                else
                spawnedObject = _poolManager.RequestObject(_pooledObjects,i, _spawnContainer);

                if (wave.Is3D)
                spawnedObject.transform.position = GetBounds(true);
                else
                spawnedObject.transform.position = GetBounds(false);
        }
        #endregion
    }
}