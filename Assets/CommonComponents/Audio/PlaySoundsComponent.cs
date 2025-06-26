using System.Linq;
using UnityEngine;

namespace Assets.CommonComponents.Audio
{
    public class PlaySoundsComponent : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioData[] _sounds;

        public void Play(string id)
        {
            if(_sounds.FirstOrDefault(x => x.Id == id) is AudioData audioData)
            {
                if (audioData.Clip != null)
                {
                    _audioSource.PlayOneShot(audioData.Clip);
                }
                else
                {
                    Debug.LogWarning($"Audio clip for ID '{id}' is null.");
                }
            }
            else
            {
                Debug.LogWarning($"No audio data found for ID '{id}'.");
            }
        }
    }
}