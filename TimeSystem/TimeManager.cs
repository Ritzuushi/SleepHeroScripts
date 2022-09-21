using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using RStudio.Utils.Events;

namespace RStudio.TimeSystem
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField]
        private Camera _mainCamera;

        [SerializeField]
        private SpriteRenderer _timeSpriteRenderer;

        [SerializeField]
        private MusicManager _musicManager;

        [SerializeField]
        private Sprite[] _timeSprites;

        [SerializeField]
        private Color[] _backgroundColors;

        [SerializeField]
        private Light2D _outsideLight;

        [SerializeField]
        private Color[] _lightColors;

        private int _currentHour => DateTime.Now.Hour;

        public void CheckTime(object arg)
        {
            if (_currentHour <= 6 && _currentHour >= 3)
            {
                UpdateTimeSprite(_timeSprites[0]);
                _outsideLight.intensity = 0.75f;
                UpdateBackgroundColor(_backgroundColors[0]);
                _musicManager.SetMusicPlaying(0);
            }
            else if (_currentHour >= 7 && _currentHour <= 16)
            {
                _outsideLight.intensity = 1f;
                UpdateTimeSprite(_timeSprites[1]);
                UpdateBackgroundColor(_backgroundColors[1]);
                _musicManager.SetMusicPlaying(1);
            }
            else if (_currentHour >= 17 && _currentHour <= 19)
            {
                _outsideLight.intensity = 0.85f;
                UpdateTimeSprite(_timeSprites[2]);
                UpdateBackgroundColor(_backgroundColors[2]);
                _musicManager.SetMusicPlaying(2);
            }
            else
            {
                _outsideLight.intensity = 0.55f;
                UpdateTimeSprite(_timeSprites[3]);
                UpdateBackgroundColor(_backgroundColors[3]);
                _musicManager.SetMusicPlaying(3);
            }
        }

        private void UpdateTimeSprite(Sprite timeSprite)
        {
            _timeSpriteRenderer.sprite = timeSprite;
        }

        private void UpdateBackgroundColor(Color timeColor)
        {
            _mainCamera.backgroundColor = timeColor;
        }
    }
}
