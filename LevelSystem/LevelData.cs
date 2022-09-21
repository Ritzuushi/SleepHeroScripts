using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RStudio.Utils.Events;

namespace RStudio.LevelSystem
{
    [CreateAssetMenu]
    public class LevelData : ScriptableObject
    {
        [SerializeField]
        private float _level;
        public int Level => (int)_level;

        [SerializeField]
        private float _prevLevel;
        public int PrevLevel => (int)_prevLevel;

        [SerializeField]
        private int _experience;
        public int Experience { get { return _experience; } set { _experience = value; _level = _levelProgressionCurve.Evaluate(_experience); } }

        [SerializeField]
        private AnimationCurve _levelProgressionCurve;

        private const int _minLevel = 0;
        private const int _maxLevel = 99;

        private const int _minExperience = 0;
        private const int _maxExperience = 14999;

        private float _initLevelProgress;

        private float _levelProgress => _level == _maxLevel ? _maxLevelProgress : Convert.ToSingle(_level - Math.Truncate(_level));
        public float LevelProgress => _levelProgress;

        private const int _maxLevelProgress = 1;

        public event Action<float, float> ExperienceChanged;

        public event Action<int, int> LevelChanged;

        public void Initialize()
        {
            _level = _minLevel;
            Experience = _minExperience;
        }

        public void IncreaseExperience(int amount)
        {
            if (Experience == _maxExperience) return;

            _prevLevel = Level;

            _initLevelProgress = _levelProgress;
            Experience += amount;

            if (Experience >= _maxExperience) Experience = _maxExperience;

            LevelChanged?.Invoke(PrevLevel, Level);
            ExperienceChanged?.Invoke(_initLevelProgress, _levelProgress);
        }

        public void DecreaseExperience(int amount)
        {
            if (Experience == _minExperience) return;

            _prevLevel = Level;

            _initLevelProgress = _levelProgress;
            Experience -= amount;

            if (Experience <= _minExperience) Experience = _minExperience;

            LevelChanged?.Invoke(PrevLevel, Level);
            ExperienceChanged?.Invoke(_initLevelProgress, _levelProgress);
        }
    }
}
