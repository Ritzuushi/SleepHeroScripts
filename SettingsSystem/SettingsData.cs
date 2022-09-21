using System;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio.SettingsSystem
{
    [CreateAssetMenu]
    public class SettingsData : ScriptableObject
    {
        public string PlayerName;
        public float MasterVolume;
        public float MusicVolume;
        public float SoundVolume;
        public int Fps;
    }
}
