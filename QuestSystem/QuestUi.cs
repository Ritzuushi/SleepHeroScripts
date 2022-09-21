using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RStudio.QuestSystem
{
    public class QuestUi : MonoBehaviour
    {
        [SerializeField]
        private Button _questButton;

        [SerializeField]
        private CanvasGroup _questView;

        [SerializeField]
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager.GameStateChanged += ChangeButtonInteractabilityByGameState;

            CloseQuestView();
        }

        private void OnDisable()
        {
            _gameManager.GameStateChanged -= ChangeButtonInteractabilityByGameState;
        }

        private void ChangeButtonInteractabilityByGameState(GameState gameState)
        {
            if (gameState == GameState.Questing)
            {
                CloseQuestView();
                _questButton.interactable = false;
            }
            else if (gameState == GameState.Awake)
            {
                _questButton.interactable = true;
            }
            else if (gameState == GameState.Sleeping)
            {
                _questButton.interactable = false;
            }
        }

        public void OpenQuestView()
        {
            _questView.alpha = 1;
            _questView.interactable = true;
            _questView.blocksRaycasts = true;
        }

        public void CloseQuestView()
        {
            _questView.alpha = 0;
            _questView.interactable = false;
            _questView.blocksRaycasts = false;
        }
    }
}
