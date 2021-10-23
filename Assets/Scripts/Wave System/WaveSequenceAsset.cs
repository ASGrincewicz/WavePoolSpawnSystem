// Aaron Grincewicz ASGrincewicz@icloud.com 10/20/2021
using UnityEngine;
namespace Grincewicz.WaveSystem
{
    [CreateAssetMenu(menuName = "Wave Sequence Asset", fileName = "WaveSequenceAsset.asset")]
    public class WaveSequenceAsset : ScriptableObject
    {
        [SerializeField] private WaveSequence _waveSequence;
        public WaveSequence GetWaveSequence { get => _waveSequence; }

        private void OnValidate()
        {
            if (_waveSequence.Sequence.Count < 2)
                Debug.LogWarning("A sequence must have more than one WAVE.");
        }
    }
}
