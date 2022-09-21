using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RStudio.SettingsSystem
{
    public class NameSetting : MonoBehaviour
    {
        [SerializeField]
        private SettingsData _settingsData;

        [SerializeField]
        private TMP_InputField _nameInputField;

        [SerializeField]
        private TextMeshProUGUI _playerNameText;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _changeNameSound;

        private void Start()
        {
            SetPlayerNameInit();
        }

        private void SetPlayerNameInit()
        {
            if (!String.IsNullOrWhiteSpace(_settingsData.PlayerName))
            {
                _playerNameText.SetText(_settingsData.PlayerName);
            }

        }

        public void PlaySound()
        {
            _audioSource.PlayOneShot(_changeNameSound);
        }

        public void SetPlayerName()
        {
            if (!String.IsNullOrWhiteSpace(_nameInputField.text))
            {
                _settingsData.PlayerName = _nameInputField.text;
                _playerNameText.SetText(_nameInputField.text);
            }
        }
    }
}
