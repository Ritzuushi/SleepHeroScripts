using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RStudio.Utils.JsonFileSystem;
using RStudio.LevelSystem;

namespace RStudio.QuestSystem
{
    public class Quest : MonoBehaviour
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int ExpReward { get; private set; }
        [field: SerializeField] public int GoldReward { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public int Difficulty { get; private set; }

        public Button _acceptButton;

        private DateTime _startTime => DateTime.UtcNow;
        private DateTime _endTime => _startTime.AddMinutes(Duration);

        [field: SerializeField] public GameManager GameManager;
        [field: SerializeField] public LevelData LevelData;
        [SerializeField]
        private GameDataManager GameDataManager;

        private void Awake()
        {
            _acceptButton = transform.Find("AcceptQuestButton").GetComponent<Button>();

            _acceptButton.onClick.AddListener(StartQuest);

            GameDataManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameDataManager>();
        }

        public void SetQuestValue(string name, int expReward, int goldReward, float duration, int difficulty)
        {
            Name = name;
            ExpReward = expReward;
            GoldReward = goldReward;
            Duration = duration;
            Difficulty = difficulty;
        }

        public void StartQuest()
        {
            GameManager.SetGameState(GameState.Questing);

            GameManager.QuestEndTimeString = _endTime.ToString();

            NotificationManager.CreateQuestChannelNotification("Quest Complete!", Name, _endTime);

            GameManager.CurrentQuest = this;

            GameManager.CurrentQuestObject = gameObject;
            GameDataManager.SetShit();
            GameDataManager.StartMinuteTicker();
            GameDataManager.PlayQuestAcceptSound();
            Destroy(gameObject);
        }
    }
}
