// Aaron Grincewicz ASGrincewicz@icloud.com 10/18/2021
using UnityEngine;
using System.Collections.Generic;
namespace Grincewicz.WaveSystem
{
    [System.Serializable]
    public class WaveSequence
    {
        [Tooltip("Name your Sequence for better organization. (Example: Level One)")]
        [SerializeField] private string _sequenceName;
        [Tooltip("How much time between sequences?")]
        [SerializeField] private float _sequenceDelay;
        [Tooltip("Place your WaveAssets in this list.")]
        [SerializeField] private List<WaveAsset> _sequence;
        private WaitForSeconds _sequenceInterval;
        public string SequenceName { get => _sequenceName; }
        public float SequenceDelay { get => _sequenceDelay; private set => _sequenceDelay = value; }
        public WaitForSeconds SequenceInterval { get => _sequenceInterval; set => _sequenceInterval = value; }
        public List<WaveAsset> Sequence { get => _sequence; }
    }
}