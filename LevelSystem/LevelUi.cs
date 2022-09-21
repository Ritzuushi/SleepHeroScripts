using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace RStudio.LevelSystem
{
    public class LevelUi : MonoBehaviour
    {
        [SerializeField]
        private LevelData _levelData;

        [SerializeField]
        private Image _experienceBar;

        [SerializeField]
        private TextMeshProUGUI _levelText;

        private Sequence _experienceBarUpdateSequence;

        private const float _experienceBarUpdateDuration = 0.5f;


        private void Awake()
        {
            _levelData.ExperienceChanged += UpdateExperienceBar;

            _levelData.LevelChanged += SetLevelText;
        }

        private void Start()
        {
            SetExperienceBar(_levelData.LevelProgress);
            SetLevelText(0, _levelData.Level);
        }

        private void SetLevelText(int prevLevel, int level)
        {
            _levelText.SetText(level.ToString());
        }

        private void SetExperienceBar(float levelProgress)
        {
            _experienceBar.fillAmount = levelProgress;
        }

        private void UpdateExperienceBar(float initLevelProgress, float targetLevelProgress)
        {
            _experienceBarUpdateSequence = DOTween.Sequence();

            if (_levelData.Level > _levelData.PrevLevel)
            {
                _experienceBarUpdateSequence.Append(DOTween.To(currentLevelProgress => _experienceBar.fillAmount = currentLevelProgress, initLevelProgress, 1f, _experienceBarUpdateDuration))
                                            .Append(DOTween.To(currentLevelProgress => _experienceBar.fillAmount = currentLevelProgress, 0f, targetLevelProgress, _experienceBarUpdateDuration))
                                            .Play();
            }
            else if (_levelData.Level < _levelData.PrevLevel)
            {
                _experienceBarUpdateSequence.Append(DOTween.To(currentLevelProgress => _experienceBar.fillAmount = currentLevelProgress, initLevelProgress, 0f, _experienceBarUpdateDuration))
                                            .Append(DOTween.To(currentLevelProgress => _experienceBar.fillAmount = currentLevelProgress, 0f, 1f, 0.25f))
                                            .Append(DOTween.To(currentLevelProgress => _experienceBar.fillAmount = currentLevelProgress, 1f, targetLevelProgress, _experienceBarUpdateDuration))
                                            .Play();
            }
            else
            {
                DOTween.To(currentLevelProgress => _experienceBar.fillAmount = currentLevelProgress, initLevelProgress, targetLevelProgress, _experienceBarUpdateDuration);
            }
        }
    }
}
