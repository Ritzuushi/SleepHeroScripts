using System;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio.CurrencySystem
{
    [CreateAssetMenu]
    public class CurrencyData : ScriptableObject
    {
        [SerializeField]
        private int _currency;
        public int Currency => _currency;

        public event Action CurrencyChanged;

        public void SetCurrency(int currency)
        {
            _currency = currency;

            CurrencyChanged?.Invoke();
        }

        public void IncreaseCurrency(int amount)
        {
            _currency += amount;

            CurrencyChanged?.Invoke();
        }


        public void DecreaseCurrency(int amount)
        {
            _currency -= amount;

            if (_currency <= 0) _currency = 0;

            CurrencyChanged?.Invoke();
        }

        public bool IsEnoughCurrency(int amount) => _currency >= amount;
    }
}
