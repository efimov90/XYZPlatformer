using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.CommonComponents.UI.Widgets
{
    public class ButtonSound : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private AudioClip _clickSound;

        private AudioSource _audioSource;

        public void OnPointerClick(PointerEventData eventData)
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

            _audioSource?.PlayOneShot(_clickSound);
        }
    }
}
