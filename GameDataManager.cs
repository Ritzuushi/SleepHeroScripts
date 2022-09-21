using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RStudio.Utils.JsonFileSystem;
using RStudio.LevelSystem;
using RStudio.StatsSystems;
using RStudio.CurrencySystem;

namespace RStudio
{
    public class GameDataManager : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private LevelData _levelData;

        [SerializeField]
        private StatsData _statsData;

        [SerializeField]
        private CurrencyData _currencyData;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _questAcceptSound;

        [SerializeField]
        private AudioClip _questCompleteSound;

        [SerializeField]
        private AudioClip _exitSound;

        private WaitForSeconds _minuteTickerTime = new WaitForSeconds(3f);

        public void PlayQuestAcceptSound()
        {
            _audioSource.PlayOneShot(_questAcceptSound);
        }

        public void PlayExitSound()
        {
            _audioSource.PlayOneShot(_exitSound);
        }

        private void Awake()
        {
            JsonFileManager.Load.Persistent(_gameManager, _gameManager.name);

            _gameManager.QuestComplete += HandleQuestEnd;
        }

        private void Start()
        {
            _gameManager.Initialize();

            SetShit();

            if (_gameManager.GameState == GameState.Questing)
            {
                StartCoroutine(MinuteTicker());
            }
        }

        public void StartMinuteTicker()
        {
            StartCoroutine(MinuteTicker());
        }

        public IEnumerator MinuteTicker()
        {
            while (true)
            {
                if (DateTime.UtcNow.CompareTo(_gameManager.QuestEndTime) > 0)
                {
                    HandleQuestEnd();
                    yield break;
                }
                yield return _minuteTickerTime;
            }
        }

        public void SetShit()
        {
            if (_gameManager.CurrentExpReward == 0 && _gameManager.CurrentQuest != null) _gameManager.CurrentExpReward = _gameManager.CurrentQuest.ExpReward;
            if (_gameManager.CurrentGoldReward == 0 && _gameManager.CurrentQuest != null) _gameManager.CurrentGoldReward = _gameManager.CurrentQuest.GoldReward;
            if (_gameManager.CurrentDifficulty == 0 && _gameManager.CurrentQuest != null) _gameManager.CurrentDifficulty = _gameManager.CurrentQuest.Difficulty;
        }

        private void HandleQuestEnd()
        {
            _gameManager.SetGameState(GameState.Awake);

            _levelData.IncreaseExperience(_gameManager.CurrentExpReward);
            _statsData.HandleQuestDamage(_gameManager.CurrentDifficulty);
            _currencyData.IncreaseCurrency(_gameManager.CurrentGoldReward);

            _audioSource.PlayOneShot(_questCompleteSound);
        }

        private void OnApplicationPause(bool pauseState)
        {
            JsonFileManager.Save.Persistent(JsonUtility.ToJson(_gameManager, true), _gameManager.name);
        }
    }
}
