using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.Audio;

namespace GameMaker.Sound.Runtime
{
    [System.Serializable]
    public class SoundDefinition : BaseDefinition
    {
        [UnityEngine.SerializeField]
        AudioClip _clip;
        [UnityEngine.SerializeField]
        private string _mixerGroup;
        [UnityEngine.SerializeField]
        private float _volumeScale;
        public AudioClip Clip => _clip;
        public string MixerGroup => _mixerGroup;
        public float VolumeScale => _volumeScale;
        public override object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}
