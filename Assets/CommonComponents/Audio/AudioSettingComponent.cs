using Assets.Model.Data;
using Assets.Model.Data.Properties;
using System;
using UnityEngine;
using static Assets.Model.Data.GameSettings;

namespace Assets.CommonComponents.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSettingComponent : MonoBehaviour
    {
        [SerializeField]
        private SoundSetting _mode;

        private AudioSource _audioSource;

        private FloatPersistentProperty _model;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _model = FindProperty();
            _model.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(float newValue, float oldValue)
        {
            _audioSource.volume = newValue;
        }

        private FloatPersistentProperty FindProperty()
        {
            switch (_mode)
            {
                case SoundSetting.Music:
                    return GameSettings.Instance.Music;
                case SoundSetting.Sfx:
                    return GameSettings.Instance.Sfx;
            }

            throw new ArgumentException($"Unknown sound setting mode: {_mode}");
        }

        private void OnDestroy()
        {
            if (_model != null)
            {
                _model.PropertyChanged -= OnPropertyChanged;
            }
        }
    }
}
