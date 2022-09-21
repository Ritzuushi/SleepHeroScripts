using System;
using System.Collections.Generic;
using UnityEngine;
using RStudio.Utils.JsonFileSystem;
using RStudio.LevelSystem;

namespace RStudio.StatsSystems
{
    public class StatsDataManager : MonoBehaviour
    {
        [SerializeField]
        private StatsData _statsData;
        public StatsData StatsData => _statsData;

        [SerializeField]
        private LevelData _levelData;

        private void Awake()
        {
            JsonFileManager.Load.Persistent(_statsData, _statsData.name);

            _levelData.LevelChanged += HandleLevelUp;
            _levelData.LevelChanged += HandleLevelDown;
        }

        private void Start()
        {
            _statsData.InitializeStats();
        }

        private void OnApplicationPause(bool pauseState)
        {
            JsonFileManager.Save.Persistent(JsonUtility.ToJson(_statsData, true), _statsData.name);
        }

        private void HandleLevelUp(int prevLevel, int level)
        {
            if (prevLevel == level) return;

            var amountOfLevelUp = level - prevLevel;

            for (int i = 0; i < amountOfLevelUp; i++)
            {
                _statsData.Health.IncreaseMaxValue(3);
                _statsData.Stamina.IncreaseMaxValue(3);
                _statsData.Mana.IncreaseMaxValue(3);
            }
        }

        private void HandleLevelDown(int prevLevel, int level)
        {
            if (prevLevel == level) return;

            var amountOfLevelsDown = prevLevel - level;

            for (int i = 0; i < amountOfLevelsDown; i++)
            {
                _statsData.Health.DecreaseMaxValue(3);
                _statsData.Stamina.DecreaseMaxValue(3);
                _statsData.Mana.DecreaseMaxValue(3);
            }
        }
    }
}
