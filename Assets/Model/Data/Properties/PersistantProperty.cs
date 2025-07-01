using UnityEngine;

namespace Assets.Model.Data.Properties
{
    public abstract class PersistantProperty<TPropertyType>
    {
        [SerializeField]
        protected TPropertyType _value;

        protected TPropertyType _storedValue;
        private TPropertyType _defaultValue;

        public delegate void OnPropertyChanged(TPropertyType newValue, TPropertyType oldValue);
        public event OnPropertyChanged PropertyChanged;

        protected PersistantProperty(TPropertyType defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public TPropertyType Value
        {
            get => _storedValue;
            set
            {
                if (_storedValue.Equals(value))
                {
                    return;
                }

                var oldValue = _value;
                Save(value);
                _value = value;
                _storedValue = value;

                PropertyChanged?.Invoke(_value, oldValue);
            }
        }

        public void Validate()
        {
            if(!_storedValue.Equals(_value))
            {
                Value = _value;
            }
        }

        protected void Init()
        {
            var loadedValuue = Load(_defaultValue);
            _storedValue = loadedValuue;
            _value = loadedValuue;
        }

        protected abstract void Save(TPropertyType propertyValue);
        protected abstract TPropertyType Load(TPropertyType defaultValue);
    }
}
