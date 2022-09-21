using System;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio.SleepSystem
{
    [CreateAssetMenu]
    public class SleepData : ScriptableObject
    {
        public bool IsSleeping;
        public string SleepStartTimeText;
        public string ForcedWakeTimeText;
    }
}
