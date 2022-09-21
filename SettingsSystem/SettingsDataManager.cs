using System;
using System.Collections.Generic;
using UnityEngine;
using RStudio.Utils.JsonFileSystem;

namespace RStudio.SettingsSystem
{
    public class SettingsDataManager : MonoBehaviour
    {
        [SerializeField]
        private SettingsData _settingsData;

        [SerializeField]
        private CanvasGroup _settings;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _settingsButtonSound;

        private void Awake()
        {
            JsonFileManager.Load.Persistent(_settingsData, _settingsData.name);
        }

        private void OnApplicationPause(bool pauseState)
        {
            JsonFileManager.Save.Persistent(JsonUtility.ToJson(_settingsData, true), _settingsData.name);
        }

        public void OpenSettings()
        {
            _audioSource.PlayOneShot(_settingsButtonSound, 1.25f);
            _settings.alpha = 1;
            _settings.interactable = true;
            _settings.blocksRaycasts = true;
        }

        public void CloseSettings()
        {
            _settings.alpha = 0;
            _settings.interactable = false;
            _settings.blocksRaycasts = false;
        }
    }
}
