using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

namespace RStudio
{
    public class NotificationManager : MonoBehaviour
    {
        public static AndroidNotificationChannel SleepChannel;
        public static AndroidNotificationChannel QuestChannel;

        private void Awake()
        {
            SleepChannel = new AndroidNotificationChannel()
            {
                Id = "0",
                Name = "SleepChannel",
                Importance = Importance.Default,
                Description = "Sleep Notifications",
            };

            QuestChannel = new AndroidNotificationChannel()
            {
                Id = "1",
                Name = "QuestChannel",
                Importance = Importance.Default,
                Description = "Quest Notifications",
            };

            AndroidNotificationCenter.CancelAllDisplayedNotifications();
        }

        private void Start()
        {
            AndroidNotificationCenter.RegisterNotificationChannel(SleepChannel);
            AndroidNotificationCenter.RegisterNotificationChannel(QuestChannel);
        }

        public static void CreateSleepChannelNotification(string notifTitle, string notifText, DateTime notifFireTime)
        {
            SleepChannel.Importance = Importance.Default;

            var notification = new AndroidNotification()
            {
                Title = notifTitle,
                Text = notifText,
                FireTime = notifFireTime,
            };

            AndroidNotificationCenter.SendNotification(notification, "0");
        }

        public static void CreateQuestChannelNotification(string notifTitle, string notifText, DateTime notifFireTime)
        {
            var notification = new AndroidNotification()
            {
                Title = notifTitle,
                Text = notifText,
                FireTime = notifFireTime,
            };

            AndroidNotificationCenter.SendNotification(notification, "1");
        }
    }
}
