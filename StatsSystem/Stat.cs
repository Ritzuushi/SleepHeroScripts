using System;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio
{
    [Serializable]
    public struct Stat
    {
        [SerializeField]
        private int _value;
        public int Value => _value;

        [SerializeField]
        private int _maxValue;
        public int MaxValue => _maxValue;

        [SerializeField]
        private bool _isInitial;

        public event Action<float, float> ValueChanged;

        private float _valuePercentage => (float)_value / (float)_maxValue;
        public float ValuePercentage => _valuePercentage;

        private const int _minValue = 0;

        private const int _initialMaxValue = 15;

        public void InitializeValue()
        {
            ValueChanged?.Invoke(1, _valuePercentage);

            if (_isInitial == true) return;

            _maxValue = _initialMaxValue;

            _value = _maxValue;

            _isInitial = true;
        }

        public void SetValue(int amount)
        {
            _value = amount;

            if (_value < 0) _value = 0;
            if (_value > _maxValue) _value = _maxValue;

            ValueChanged?.Invoke(0, _valuePercentage);
        }

        public void IncreaseMaxValue(int amount)
        {
            _maxValue += amount;

            ValueChanged?.Invoke(1, _valuePercentage);
        }

        public void DecreaseMaxValue(int amount)
        {
            _maxValue -= amount;

            if (_value > _maxValue) _value = _maxValue;

            ValueChanged?.Invoke(1, _valuePercentage);
        }

        public void IncreaseValue(int amount)
        {
            if (_value == _maxValue) return;

            var prevValuePercentage = _valuePercentage;
            _value += amount;

            if (_value >= _maxValue) _value = _maxValue;

            ValueChanged?.Invoke(prevValuePercentage, _valuePercentage);
        }

        public void DecreaseValue(int amount)
        {
            if (_value == _minValue) return;

            var prevValuePercentage = _valuePercentage;
            _value -= amount;

            if (_value <= _minValue) _value = _minValue;

            ValueChanged?.Invoke(prevValuePercentage, _valuePercentage);
        }
    }
}
