// Aaron Grincewicz ASGrincewicz@icloud.com 10/20/2021
using UnityEngine;
namespace Grincewicz.WaveSystem
{
    [CreateAssetMenu(menuName = "Wave Asset", fileName = "WaveAsset.asset")]
    public class WaveAsset : ScriptableObject
    {
        [SerializeField] private Wave _wave;
        public Wave GetWave { get => _wave; }
    }
}
