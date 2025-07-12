using Assets.Model.Data.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Widgets
{
    public class AudioSettingsWidget : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private Text _value;

        private FloatPersistentProperty _persistentProperty;

        public void SetModel(FloatPersistentProperty floatPersistentProperty)
        {
            _persistentProperty = floatPersistentProperty;

            _persistentProperty.PropertyChanged += OnPropertyChanged;

            _slider.onValueChanged.AddListener(OnSliderValueChanged);

            _value.text = $"{_persistentProperty.Value * 100:F0}";
            _slider.normalizedValue = _persistentProperty.Value;
        }

        private void OnSliderValueChanged(float value)
        {
            _persistentProperty.Value = value;
        }

        private void OnPropertyChanged(float newValue, float oldValue)
        {
            _value.text = $"{newValue * 100:F0}";
            _slider.normalizedValue = newValue;
        }

        public void OnDestroy()
        {
            if (_persistentProperty != null)
            {
                _persistentProperty.PropertyChanged -= OnPropertyChanged;
            }

            if (_slider != null)
            {
                _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
            }
        }
    }
}
