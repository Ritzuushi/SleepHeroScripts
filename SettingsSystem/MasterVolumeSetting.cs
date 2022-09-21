using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RStudio.SettingsSystem
{
    public class MasterVolumeSetting : MonoBehaviour
    {
        [SerializeField]
        private SettingsData _settingsData;

        [SerializeField]
        private Slider _masterVolumeSlider;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioSource _lampAudioSource;

        [SerializeField]
        private AudioSource _musicAudioSource;

        private void Start()
        {
            if (_settingsData.MasterVolume == 0)
            {
                _settingsData.MasterVolume = 1;
            }

            _masterVolumeSlider.value = _settingsData.MasterVolume;
        }

        public void SetMasterVolume(float value)
        {
            _settingsData.MasterVolume = value;
            _audioSource.volume = _settingsData.SoundVolume * value;
            _lampAudioSource.volume = _settingsData.SoundVolume * value;
            _musicAudioSource.volume = _settingsData.MusicVolume * value;
        }
    }
}
