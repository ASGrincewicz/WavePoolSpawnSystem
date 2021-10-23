// Aaron Grincewicz ASGrincewicz@icloud.com 10/18/2021
using UnityEngine;
using System.Collections.Generic;
namespace Grincewicz.WaveSystem
{
    [System.Serializable]
    public class Wave
    {
        [SerializeField] private string _waveName;
        [SerializeField] private List<GameObject> _spawnableObjects;
        [SerializeField] private bool _isRandom;
        [SerializeField] private bool _is3D;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private WaitForSeconds _spawnInterval;
        public string WaveName { get => _waveName.ToLower(); private set => _waveName = value.ToLower(); }
        public List<GameObject> SpawnableObjects { get => _spawnableObjects; private set => _spawnableObjects = value; }
        public bool IsRandom { get => _isRandom; private set => _isRandom = value; }
        public bool Is3D { get => _is3D; private set => _is3D = value; }
        public float SpawnDelay { get => _spawnDelay; private set => _spawnDelay = value; }
        public WaitForSeconds SpawnInterval { get => _spawnInterval; set => _spawnInterval = value; }
    }
}