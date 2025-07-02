using Assets.Utils.Disposables;
using System;
using UnityEngine;

namespace Assets.Model.Data.Properties
{
    [Serializable]
    public class ObservableProperty<TPropertyType>
    {
        [SerializeField]
        protected TPropertyType _value;

        public delegate void OnPropertyChanged(TPropertyType newValue, TPropertyType oldValue);
        public event OnPropertyChanged PropertyChanged;


        public TPropertyType Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value))
                {
                    return;
                }

                var oldValue = _value;
                _value = value;
                PropertyChanged?.Invoke(_value, oldValue);
            }
        }

        public IDisposable Subscribe(OnPropertyChanged propertyChangedHandler)
        {
            PropertyChanged += propertyChangedHandler;
            return new ActionDisposable(() => PropertyChanged -= propertyChangedHandler);
        }

        public IDisposable SubscribeAndInvoke(OnPropertyChanged propertyChangedHandler)
        {
            PropertyChanged += propertyChangedHandler;
            var disposableAction = new ActionDisposable(() => PropertyChanged -= propertyChangedHandler);

            propertyChangedHandler.Invoke(_value, _value);

            return disposableAction;
        }
    }
}
