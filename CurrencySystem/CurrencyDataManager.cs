using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RStudio.Utils.JsonFileSystem;

namespace RStudio.CurrencySystem
{
    public class CurrencyDataManager : MonoBehaviour
    {
        [SerializeField]
        private CurrencyData _currencyData;

        [SerializeField]
        private TextMeshProUGUI _currencyText;

        private void Awake()
        {
            JsonFileManager.Load.Persistent(_currencyData, _currencyData.name);

            _currencyData.CurrencyChanged += UpdateCurrency;

            UpdateCurrency();
        }

        private void OnDisable()
        {
            _currencyData.CurrencyChanged -= UpdateCurrency;
        }

        private void UpdateCurrency()
        {
            _currencyText.SetText(_currencyData.Currency.ToString());
        }

        private void OnApplicationPause(bool pauseState)
        {
            JsonFileManager.Save.Persistent(JsonUtility.ToJson(_currencyData, true), _currencyData.name);
        }
    }
}
