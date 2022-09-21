using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RStudio.SleepSystem
{
    public class SleepUi : MonoBehaviour
    {
        [SerializeField]
        private Button _sleepButton;

        [SerializeField]
        private TextMeshProUGUI _sleepText;

        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private SleepManager _sleepManager;

        private void Awake()
        {
            _gameManager.GameStateChanged += ChangeButtonInteractabilityByGameState;
            _gameManager.GameStateChanged += ChangeSleepText;
        }

        private void OnDisable()
        {
            _gameManager.GameStateChanged -= ChangeButtonInteractabilityByGameState;
            _gameManager.GameStateChanged -= ChangeSleepText;
        }

        private void ChangeButtonInteractabilityByGameState(GameState gameState)
        {
            if (gameState == GameState.Questing)
            {
                _sleepButton.interactable = false;
            }
            else if (gameState == GameState.Awake && !_sleepManager.CanSleep)
            {
                _sleepButton.interactable = false;
            }
            else if (gameState == GameState.Awake)
            {
                _sleepButton.interactable = true;
            }
            else if (gameState == GameState.Sleeping)
            {
                _sleepButton.interactable = true;
            }
        }

        public void ChangeSleepText(GameState gameState)
        {
            if (gameState == GameState.Sleeping)
            {
                _sleepText.SetText("Wake");
            }
            else
            {
                _sleepText.SetText("Sleep");
            }
        }
    }
}
