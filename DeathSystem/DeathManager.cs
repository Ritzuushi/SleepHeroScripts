using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RStudio.LevelSystem;
using RStudio.StatsSystems;
using RStudio.CurrencySystem;

namespace RStudio.DeathSystem
{
    public class DeathManager : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private StatsData _statsData;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private CurrencyData _currencyData;
        [SerializeField] private CanvasGroup _deathScreen;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _deathSound;
        [SerializeField] private AudioClip _reviveSound;
        [SerializeField] private AudioClip _failedSound;

        private const int _goldRevivePrice = 499;
        private const int _expRevivePrice = 249;

        private void OnEnable()
        {
            _gameManager.GameStateChanged += ToggleDeathScreen;
            _statsData.Health.ValueChanged += HandleDeath;
        }

        private void OnDisable()
        {
            _gameManager.GameStateChanged -= ToggleDeathScreen;
            _statsData.Health.ValueChanged -= HandleDeath;
        }

        private void HandleDeath(float arg1, float arg2)
        {
            if (_statsData.Health.Value == 0)
            {
                _gameManager.SetGameState(GameState.Dead);
                _audioSource.PlayOneShot(_deathSound);
            }
        }

        private void ToggleDeathScreen(GameState gameState)
        {
            if (gameState == GameState.Dead)
            {
                _deathScreen.alpha = 1;
                _deathScreen.interactable = true;
                _deathScreen.blocksRaycasts = true;
            }
            else
            {
                _deathScreen.alpha = 0;
                _deathScreen.interactable = false;
                _deathScreen.blocksRaycasts = false;
            }
        }

        public void HandleGoldRevive()
        {
            if (_currencyData.IsEnoughCurrency(_goldRevivePrice))
            {
                _currencyData.DecreaseCurrency(_goldRevivePrice);
                FullHeal();
            }
            else
            {
                _audioSource.PlayOneShot(_failedSound);
            }
        }

        public void HandleExpRevive()
        {
            _levelData.DecreaseExperience(_expRevivePrice);
            FullHeal();
        }

        private void FullHeal()
        {
            _gameManager.SetGameState(GameState.Awake);
            _statsData.Health.SetValue(_statsData.Health.MaxValue);
            _statsData.Mana.SetValue(_statsData.Mana.MaxValue);
            _statsData.Stamina.SetValue(_statsData.Stamina.MaxValue);
            _audioSource.PlayOneShot(_reviveSound);
        }
    }
}
