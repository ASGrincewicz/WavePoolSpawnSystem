// Aaron Grincewicz ASGrincewicz@icloud.com 10/18/2021
using UnityEngine;
using System.Collections.Generic;
namespace Grincewicz.WaveSystem
{
    [System.Serializable]
    public class Wave
    {
        [Tooltip("Name your wave for better organization")]
        [SerializeField] private string _waveName;
        [Tooltip("Place the objects you want to spawn in this list.")]
        [SerializeField] private List<GameObject> _spawnableObjects;
        [Tooltip("Check the box if you'd like to use SpawnBounds3D.")]
        [SerializeField] private bool _is3D;
        [Tooltip("How much time between spawns?")]
        [SerializeField] private float _spawnDelay;
        private WaitForSeconds _spawnInterval;
        public string WaveName { get => _waveName.ToLower(); private set => _waveName = value.ToLower(); }
        public List<GameObject> SpawnableObjects { get => _spawnableObjects; private set => _spawnableObjects = value; }
        public bool Is3D { get => _is3D; private set => _is3D = value; }
        public float SpawnDelay { get => _spawnDelay; private set => _spawnDelay = value; }
        public WaitForSeconds SpawnInterval { get => _spawnInterval; set => _spawnInterval = value; }
    }
}