// Aaron Grincewicz ASGrincewicz@icloud.com 10/20/2021
using UnityEngine;
using System.Collections.Generic;
namespace Grincewicz.WaveSystem
{
    public class WaveManager : MonoBehaviour
    {
        private static WaveManager _instance;
        public static WaveManager Instance { get => _instance; }
        
        [Tooltip("Use this for a continous sequence.")]
        [SerializeField] private List<WaveSequenceAsset> _waveSequences;
        [Tooltip("Use this list for standalone waves not in a sequence.")]
        [SerializeField] private List<WaveAsset> _singleWaves;
        [SerializeField] private int _currentWave = 0;
        [SerializeField] private int _currentSequence = 0;
        public int CurrentWave { get => _currentWave; set => _currentWave = value; }
        public int CurrentSequence { get => _currentSequence; set => _currentSequence = value; }
        public List<WaveSequenceAsset> WaveSequences { get => _waveSequences; }

        private void Awake() => _instance = this;

        public WaveAsset GetSingleWave(string waveName)
        {
            WaveAsset requestedWave = null;
            foreach (WaveAsset asset in _singleWaves)
            {
                if (!asset.GetWave.WaveName.Contains(waveName)) return null;

                requestedWave = asset;
                break;
            }
            return requestedWave;
        }
        public WaveSequenceAsset GetWaveFromSequence(WaveSequenceAsset sequence) => sequence;
    }
}
