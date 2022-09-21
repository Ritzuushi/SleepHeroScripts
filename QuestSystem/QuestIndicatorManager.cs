using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RStudio
{
    public class QuestIndicatorManager : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private TextMeshProUGUI _questIndicatorText;

        private void Awake()
        {
            _gameManager.GameStateChanged += UpdateQuestIndicatorText;
        }

        private void UpdateQuestIndicatorText(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Awake:
                    _questIndicatorText.SetText("Awake");
                    break;
                case GameState.Sleeping:
                    _questIndicatorText.SetText("Sleeping");
                    break;
                case GameState.Questing:
                    _questIndicatorText.SetText("Questing");
                    break;
            }
        }
    }
}
