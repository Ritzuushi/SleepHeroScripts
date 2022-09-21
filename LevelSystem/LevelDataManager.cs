using System;
using System.Collections.Generic;
using UnityEngine;
using RStudio.Utils.JsonFileSystem;

namespace RStudio.LevelSystem
{
    public class LevelDataManager : MonoBehaviour
    {
        [SerializeField]
        private LevelData _levelData;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _levelUpSound;

        [SerializeField]
        private AudioClip _levelDownSound;

        [SerializeField]
        private AudioClip _expSound;

        private void Awake()
        {
            _levelData.Initialize();

            JsonFileManager.Load.Persistent(_levelData, _levelData.name);

            _levelData.LevelChanged += HandleLevelSounds;
            _levelData.ExperienceChanged += HandleExperienceSounds;
        }

        private void OnApplicationPause(bool pauseState)
        {
            if (pauseState)
            {
                JsonFileManager.Save.Persistent(JsonUtility.ToJson(_levelData, true), _levelData.name);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _levelData.IncreaseExperience(100);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                _levelData.DecreaseExperience(100);
            }
        }

        private void HandleExperienceSounds(float a, float b)
        {
            _audioSource.PlayOneShot(_expSound);
        }

        private void HandleLevelSounds(int prevLevel, int level)
        {
            if (prevLevel == level) return;

            if (prevLevel > level)
            {
                _audioSource.PlayOneShot(_levelDownSound);
            }
            else
            {
                _audioSource.PlayOneShot(_levelUpSound);
            }
        }
    }
}
