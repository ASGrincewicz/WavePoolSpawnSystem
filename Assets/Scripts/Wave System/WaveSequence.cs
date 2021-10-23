// Aaron Grincewicz ASGrincewicz@icloud.com 10/18/2021
using UnityEngine;
using System.Collections.Generic;
namespace Grincewicz.WaveSystem
{
    [System.Serializable]
    public class WaveSequence
    {
        [SerializeField] private string _sequenceName;
        [SerializeField] private List<WaveAsset> _sequence;
        public string SequenceName { get => _sequenceName; }
        public List<WaveAsset> Sequence { get => _sequence; }
    }
}