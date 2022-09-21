using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RStudio.SettingsSystem
{
    public class FpsSetting : MonoBehaviour
    {
        [SerializeField]
        private SettingsData _settingsData;

        [SerializeField]
        private TMP_Dropdown _fpsDropdown;

        private int[] _fpsChoices = { 30, 45, 60 };

        private void Awake()
        {
            SetChoice();
            SetFps(_settingsData.Fps);
        }

        private void SetChoice()
        {
            _fpsDropdown.SetValueWithoutNotify(_settingsData.Fps);
        }

        public void SetFps(int choice)
        {
            if (choice != _settingsData.Fps) _settingsData.Fps = choice;
            Application.targetFrameRate = _fpsChoices[choice];
        }
    }
}
