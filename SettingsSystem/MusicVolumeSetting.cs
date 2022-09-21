using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RStudio.SettingsSystem;

namespace RStudio
{
    public class MusicVolumeSetting : MonoBehaviour
    {
        [SerializeField]
        private SettingsData _settingsData;

        [SerializeField]
        private Slider _musicVolumeSlider;

        [SerializeField]
        private AudioSource _musicAudioSource;

        private void Start()
        {
            if (_settingsData.MusicVolume == 0)
            {
                _settingsData.MusicVolume = 1;
            }

            _musicVolumeSlider.value = _settingsData.MusicVolume;
        }

        public void SetMusicVolume(float value)
        {
            _settingsData.MusicVolume = value;
            _musicAudioSource.volume = value;
        }
    }
}
