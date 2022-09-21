using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RStudio.SettingsSystem;

namespace RStudio
{
    public class SoundVolumeSetting : MonoBehaviour
    {
        [SerializeField]
        private SettingsData _settingsData;

        [SerializeField]
        private Slider _soundVolumeSlider;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioSource _lampAudioSource;

        private void Start()
        {
            if (_settingsData.SoundVolume == 0)
            {
                _settingsData.SoundVolume = 1;
            }

            _soundVolumeSlider.value = _settingsData.SoundVolume;
        }

        public void SetSoundVolume(float value)
        {
            _settingsData.SoundVolume = value;
            _audioSource.volume = value;
            _lampAudioSource.volume = value;
        }
    }
}
