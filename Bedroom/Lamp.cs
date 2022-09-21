using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RStudio.Bedroom
{
    public class Lamp : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Animator _lampAnimator;

        [SerializeField]
        private GameObject _lampLight;

        [SerializeField]
        private AudioSource _lampAudioSource;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _lampOnSound;

        [SerializeField]
        private AudioClip _lampOffSound;

        [SerializeField]
        private AudioClip _lampSwitchSound;

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            ToggleLamp();
        }

        private void ToggleLamp()
        {
            _lampAnimator.SetBool("IsOn", !_lampAnimator.GetBool("IsOn"));

            if (_lampAnimator.GetBool("IsOn"))
            {
                _lampLight.SetActive(true);
                if (_lampAnimator.GetInteger("LampLevel") == 2)
                {
                    _audioSource.PlayOneShot(_lampSwitchSound);
                    return;
                }
                _audioSource.PlayOneShot(_lampOnSound, 0.25f);
                HandleLampAmbientSound(_lampAnimator.GetBool("IsOn"));
            }
            else
            {
                _lampLight.SetActive(false);
                if (_lampAnimator.GetInteger("LampLevel") == 2)
                {
                    _audioSource.PlayOneShot(_lampSwitchSound);
                    return;
                }
                _audioSource.PlayOneShot(_lampOffSound, 0.5f);
                HandleLampAmbientSound(_lampAnimator.GetBool("IsOn"));
            }
        }

        private void HandleLampAmbientSound(bool IsOn)
        {
            if (_lampAnimator.GetInteger("LampLevel") == 2) return;

            if (IsOn)
            {
                _lampAudioSource.Play();
            }
            else
            {
                _lampAudioSource.Stop();
            }
        }

        public void SetLampLevel(int value)
        {
            _lampAnimator.SetInteger("LampLevel", value);
            _lampAnimator.SetTrigger("LampLevelChanged");
        }
    }
}
