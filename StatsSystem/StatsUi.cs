using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace RStudio.StatsSystems
{
    public class StatsUi : MonoBehaviour
    {
        [SerializeField]
        private Image _healthBar;

        [SerializeField]
        private Image _manaBar;

        [SerializeField]
        private Image _staminaBar;

        [SerializeField]
        private TextMeshProUGUI _healthText;
        [SerializeField]
        private TextMeshProUGUI _manaText;
        [SerializeField]
        private TextMeshProUGUI _staminaText;

        [SerializeField]
        private StatsData _statsData;

        private void Awake()
        {
            _statsData.Health.ValueChanged += UpdateHealthBar;
            _statsData.Mana.ValueChanged += UpdateManaBar;
            _statsData.Stamina.ValueChanged += UpdateStaminaBar;
        }

        private void UpdateHealthBar(float prevValue, float newValue)
        {
            DOTween.To(currentFillAmount => _healthBar.fillAmount = currentFillAmount, prevValue, newValue, 0.25f);

            _healthText.SetText($"{_statsData.Health.Value} / {_statsData.Health.MaxValue}");
        }

        private void UpdateManaBar(float prevValue, float newValue)
        {
            DOTween.To(currentFillAmount => _manaBar.fillAmount = currentFillAmount, prevValue, newValue, 0.25f);

            _manaText.SetText($"{_statsData.Mana.Value} / {_statsData.Mana.MaxValue}");
        }

        private void UpdateStaminaBar(float prevValue, float newValue)
        {
            DOTween.To(currentFillAmount => _staminaBar.fillAmount = currentFillAmount, prevValue, newValue, 0.25f);

            _staminaText.SetText($"{_statsData.Stamina.Value} / {_statsData.Stamina.MaxValue}");
        }
    }
}
