using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using RStudio.TimeSystem;

namespace RStudio.Bedroom
{
    public class Window : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Animator _windowAnimator;

        [SerializeField]
        private OutsideTimeManager _outsideTimeManager;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _windowSound;

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            ToggleWindow();
        }

        private void ToggleWindow()
        {
            if (_windowAnimator.GetInteger("WindowLevel") == 2) return;
            _audioSource.PlayOneShot(_windowSound, 0.5f);
            _windowAnimator.SetBool("IsOpen", !_windowAnimator.GetBool("IsOpen"));
        }

        public void SetWindowLevel(int value)
        {
            _windowAnimator.SetInteger("WindowLevel", value);
            _windowAnimator.SetTrigger("WindowLevelChanged");

            _outsideTimeManager.SetOutsideTransform(value);
        }
    }
}
