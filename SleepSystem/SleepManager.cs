using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RStudio.Utils.Events;
using RStudio.Utils.JsonFileSystem;
using RStudio.StatsSystems;
using Unity.Notifications.Android;

namespace RStudio.SleepSystem
{
    public class SleepManager : MonoBehaviour
    {
        [SerializeField]
        private StatsData _statsData;

        [SerializeField]
        private SleepData _sleepData;

        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private RSEvent SleepManagerHourTick;

        [SerializeField]
        private Animator _bedAnimator;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _sleepButtonSound;

        private DateTime _sleepStartTime => DateTime.Parse(_sleepData.SleepStartTimeText);

        private DateTime _forcedWakeTime => DateTime.Parse(_sleepData.ForcedWakeTimeText);

        private const int _minutesInHour = 60;
        private const int _secondsInMinute = 60;
        private const int _totalHoursInDay = 23;
        private const int _canSleepMinHour = 18;
        private const int _canSleepMaxHour = 2;
        private const int _hoursBeforeForcedWake = 12;

        private DateTime _currentTime => DateTime.UtcNow;

        private int _totalSleepHours => _currentTime.Subtract(_sleepStartTime).Hours;

        private bool _canSleep => _currentTime.ToLocalTime().Hour >= _canSleepMinHour || _currentTime.ToLocalTime().Hour <= _canSleepMaxHour;
        public bool CanSleep => _canSleep;

        private void Awake()
        {
            JsonFileManager.Load.Persistent(_sleepData, _sleepData.name);

            if (_sleepData.IsSleeping)
            {
                _gameManager.SetGameState(GameState.Sleeping);
            }
        }

        private void Start()
        {
            StartCoroutine(TickHour());
        }

        private void OnApplicationPause(bool pauseState)
        {
            JsonFileManager.Save.Persistent(JsonUtility.ToJson(_sleepData, true), _sleepData.name);
        }

        private IEnumerator TickHour()
        {
            HandleTickHour();

            yield return new WaitForSecondsRealtime(MinuteToSeconds(_minutesInHour - _currentTime.Minute));

            StartCoroutine(TickHour());

            float MinuteToSeconds(float minute)
            {
                return (minute * _secondsInMinute) - (_secondsInMinute - _currentTime.Second);
            }
        }

        private void HandleTickHour()
        {
            SleepManagerHourTick.Raise(new Dictionary<string, object> { { "CanSleep", _canSleep }, { "IsSleeping", _sleepData.IsSleeping } });
        }

        private void HandleHeal(int amount)
        {
            _statsData.Health.IncreaseValue(amount);
            _statsData.Mana.IncreaseValue(amount);
            _statsData.Stamina.IncreaseValue(amount);
        }

        public void PlaySleepButtonSound()
        {
            _audioSource.PlayOneShot(_sleepButtonSound);
        }

        public void ToggleSleep()
        {
            if (_canSleep && !_sleepData.IsSleeping)
            {
                _sleepData.IsSleeping = true;

                HandleSleep();
            }
            else
            {
                _sleepData.IsSleeping = false;

                HandleWake();
            }
        }

        public void HandleWake()
        {
            _bedAnimator.SetBool("IsSleeping", false);

            _sleepData.ForcedWakeTimeText = DateTime.UtcNow.ToString();

            if (_totalSleepHours == 6) HandleHeal((int)(_statsData.Health.MaxValue * 0.5f));
            else if (_totalSleepHours == 7) HandleHeal((int)(_statsData.Health.MaxValue * 0.65f));
            else if (_totalSleepHours == 8) HandleHeal((int)(_statsData.Health.MaxValue * 0.85f));
            else if (_totalSleepHours >= 9) HandleHeal((int)(_statsData.Health.MaxValue));

            _gameManager.SetGameState(GameState.Awake);

            AndroidNotificationCenter.CancelAllScheduledNotifications();
        }

        public void HandleSleep()
        {
            _bedAnimator.SetBool("IsSleeping", true);

            _sleepData.SleepStartTimeText = DateTime.UtcNow.ToString();
            _sleepData.ForcedWakeTimeText = DateTime.UtcNow.AddHours(_hoursBeforeForcedWake).ToString();

            _gameManager.SetGameState(GameState.Sleeping);

            NotificationManager.CreateSleepChannelNotification("Your Hero has woken up!", "All stats have been healed.", _forcedWakeTime);
        }
    }
}
