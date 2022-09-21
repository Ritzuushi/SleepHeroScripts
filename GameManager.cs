using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RStudio.QuestSystem;

namespace RStudio
{
    public enum GameState
    {
        Awake,
        Sleeping,
        Questing,
        Dead,
    }

    [CreateAssetMenu]
    public class GameManager : ScriptableObject
    {
        [field: SerializeField]
        public GameState GameState;

        public DateTime QuestEndTime { get { return !String.IsNullOrWhiteSpace(QuestEndTimeString) ? DateTime.Parse(QuestEndTimeString) : DateTime.UtcNow; } }
        public string QuestEndTimeString;

        public event Action<GameState> GameStateChanged;

        public event Action QuestComplete;

        public Quest CurrentQuest { get; set; }

        public GameObject CurrentQuestObject { get; set; }

        public int CurrentExpReward;

        public int CurrentGoldReward;

        public int CurrentDifficulty;

        public void Initialize()
        {
            GameStateChanged?.Invoke(GameState);
        }

        public void HandleQuestEnd()
        {
            SetGameState(GameState.Awake);

            Destroy(CurrentQuestObject);

            QuestComplete?.Invoke();

            CurrentExpReward = 0;
            CurrentGoldReward = 0;
            CurrentDifficulty = 0;
        }

        public void SetGameState(GameState newGameState)
        {
            GameState = newGameState;

            GameStateChanged?.Invoke(GameState);
        }
    }
}
