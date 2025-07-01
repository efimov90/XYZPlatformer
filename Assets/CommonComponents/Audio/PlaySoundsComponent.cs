using System.Linq;
using UnityEngine;

namespace Assets.CommonComponents.Audio
{
    public class PlaySoundsComponent : MonoBehaviour
    {
        private AudioSource _audioSource;

        [SerializeField]
        private AudioData[] _sounds;

        public void Play(string id)
        {
            if (_audioSource == null)
            {
                _audioSource = GameObject
                    .FindWithTag("SfxAudioSource")
                    ?.GetComponent<AudioSource>();
            }

            if (_audioSource == null)
            {
                Debug.LogWarning("AudioSource not found with tag 'SfxAudioSource'.");
                return;
            }

            if (_sounds.FirstOrDefault(x => x.Id == id) is AudioData audioData)
            {
                if (audioData.Clip != null)
                {
                    _audioSource?.PlayOneShot(audioData.Clip);
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