using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RStudio.Bedroom;

namespace RStudio.ShopSystem
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField]
        private ItemContainer _bedContainer;
        [SerializeField]
        private ItemContainer _tableContainer;
        [SerializeField]
        private ItemContainer _lampContainer;
        [SerializeField]
        private ItemContainer _rugContainer;
        [SerializeField]
        private ItemContainer _windowContainer;
        [SerializeField]
        private ItemContainer _curtainContainer;

        [SerializeField]
        private ShopData _shopData;

        [SerializeField]
        private Image _bedIcon;
        [SerializeField]
        private Image _tableIcon;
        [SerializeField]
        private Image _lampIcon;
        [SerializeField]
        private Image _rugIcon;
        [SerializeField]
        private Image _windowIcon;
        [SerializeField]
        private Image _curtainIcon;

        [SerializeField]
        private Bed _bed;
        [SerializeField]
        private Table _table;
        [SerializeField]
        private Lamp _lamp;
        [SerializeField]
        private Rug _rug;
        [SerializeField]
        private Window _window;
        [SerializeField]
        private Curtain _curtain;

        [SerializeField]
        private Sprite[] _bedIcons;

        [SerializeField]
        private Sprite[] _tableIcons;

        [SerializeField]
        private Sprite[] _lampIcons;

        [SerializeField]
        private Sprite[] _rugIcons;

        [SerializeField]
        private Sprite[] _windowIcons;

        [SerializeField]
        private Sprite[] _curtainIcons;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _shopButtonSound;

        [SerializeField]
        private AudioClip _decisionSound;

        public void PlayShopButtonSound()
        {
            _audioSource.PlayOneShot(_shopButtonSound);
        }

        private void Start()
        {
            _bedContainer.SetCurrentValue(_shopData.BedLevel);
            _bedContainer.SetLocks(_shopData.BedMaxLevel);
            _tableContainer.SetCurrentValue(_shopData.TableLevel);
            _tableContainer.SetLocks(_shopData.TableMaxLevel);
            _lampContainer.SetCurrentValue(_shopData.LampLevel);
            _lampContainer.SetLocks(_shopData.LampMaxLevel);
            _rugContainer.SetCurrentValue(_shopData.RugLevel);
            _rugContainer.SetLocks(_shopData.RugMaxLevel);
            _windowContainer.SetCurrentValue(_shopData.WindowLevel);
            _windowContainer.SetLocks(_shopData.WindowMaxLevel);
            _curtainContainer.SetCurrentValue(_shopData.CurtainLevel);
            _curtainContainer.SetLocks(_shopData.CurtainMaxLevel);
        }

        private void OnEnable()
        {
            _bedContainer.ValueChanged += BedValueChanged;
            _tableContainer.ValueChanged += TableValueChanged;
            _lampContainer.ValueChanged += LampValueChanged;
            _rugContainer.ValueChanged += RugValueChanged;
            _windowContainer.ValueChanged += WindowValueChanged;
            _curtainContainer.ValueChanged += CurtainValueChanged;
        }

        private void OnDisable()
        {
            _bedContainer.ValueChanged -= BedValueChanged;
            _tableContainer.ValueChanged -= TableValueChanged;
            _lampContainer.ValueChanged -= LampValueChanged;
            _rugContainer.ValueChanged -= RugValueChanged;
            _windowContainer.ValueChanged -= WindowValueChanged;
            _curtainContainer.ValueChanged -= CurtainValueChanged;
        }

        private void BedValueChanged(int value)
        {
            _bedIcon.sprite = _bedIcons[value];
            _bed.SetBedLevel(value);
            _audioSource.PlayOneShot(_decisionSound);
            if (value == _shopData.BedLevel) return;
            _shopData.BedLevel = value;
        }
        private void TableValueChanged(int value)
        {
            _tableIcon.sprite = _tableIcons[value];
            _table.SetTableLevel(value);
            _audioSource.PlayOneShot(_decisionSound);
            if (value == _shopData.TableLevel) return;
            _shopData.TableLevel = value;
        }
        private void LampValueChanged(int value)
        {
            _lampIcon.sprite = _lampIcons[value];
            _lamp.SetLampLevel(value);
            _audioSource.PlayOneShot(_decisionSound);
            if (value == _shopData.LampLevel) return;
            _shopData.LampLevel = value;
        }
        private void RugValueChanged(int value)
        {
            _rugIcon.sprite = _rugIcons[value];
            _rug.SetRugLevel(value);
            _audioSource.PlayOneShot(_decisionSound);
            if (value == _shopData.RugLevel) return;
            _shopData.RugLevel = value;
        }
        private void WindowValueChanged(int value)
        {
            _windowIcon.sprite = _windowIcons[value];
            _window.SetWindowLevel(value);
            _audioSource.PlayOneShot(_decisionSound);
            if (value == _shopData.WindowLevel) return;
            _shopData.WindowLevel = value;
        }
        private void CurtainValueChanged(int value)
        {
            _curtainIcon.sprite = _curtainIcons[value];
            _curtain.SetCurtainLevel(value);
            _audioSource.PlayOneShot(_decisionSound);
            if (value == _shopData.CurtainLevel) return;
            _shopData.CurtainLevel = value;
        }
    }
}
