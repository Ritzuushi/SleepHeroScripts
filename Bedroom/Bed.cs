using System;
using System.Collections.Generic;
using UnityEngine;
using RStudio.SleepSystem;

namespace RStudio.Bedroom
{
    public class Bed : MonoBehaviour
    {
        [SerializeField]
        private Animator _bedAnimator;

        [SerializeField]
        private SleepData _sleepData;

        private void Start()
        {
            if (_sleepData.IsSleeping)
            {
                _bedAnimator.SetBool("IsSleeping", true);
            }
        }

        public void SetBedLevel(int value)
        {
            _bedAnimator.SetInteger("BedLevel", value);
            _bedAnimator.SetTrigger("BedLevelChanged");
        }
    }
}
