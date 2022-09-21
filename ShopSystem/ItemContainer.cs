using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RStudio.ShopSystem
{
    public class ItemContainer : MonoBehaviour
    {
        [SerializeField]
        private Button _choiceOne;
        [SerializeField]
        private Button _choiceTwo;
        [SerializeField]
        private Button _choiceThree;
        [SerializeField]
        private Button _upgradeButton;

        [SerializeField]
        private Image _choiceOneImage;
        [SerializeField]
        private Image _choiceTwoImage;
        [SerializeField]
        private Image _choiceThreeImage;

        [SerializeField]
        private Color _inactiveColor;

        [SerializeField]
        private TextMeshProUGUI _upgradePriceText;

        public event Action<int> ValueChanged;

        [SerializeField]
        private int _value;
        public int Value => _value;

        private int _maxValue;

        public void SetCurrentValue(int value)
        {
            _value = value;

            switch (value)
            {
                case 0:
                    HandleChoiceOne();
                    break;
                case 1:
                    HandleChoiceTwo();
                    break;
                case 2:
                    HandleChoiceThree();
                    break;
            }
        }

        public void SetLocks(int value)
        {
            switch (value)
            {
                case 0:
                    _choiceTwo.interactable = false;
                    _choiceThree.interactable = false;
                    break;
                case 1:
                    _choiceTwo.interactable = true;
                    _choiceThree.interactable = false;
                    break;
                case 2:
                    _choiceTwo.interactable = true;
                    _choiceThree.interactable = true;
                    break;
            }

            value = _maxValue;
        }

        public void HandleChoiceOne()
        {
            _value = 0;
            _choiceOneImage.color = Color.white;
            _choiceTwoImage.color = _inactiveColor;
            _choiceThreeImage.color = _inactiveColor;

            ValueChanged?.Invoke(_value);
        }

        public void HandleChoiceTwo()
        {
            _value = 1;
            _choiceOneImage.color = _inactiveColor;
            _choiceTwoImage.color = Color.white;
            _choiceThreeImage.color = _inactiveColor;

            ValueChanged?.Invoke(_value);
        }

        public void HandleChoiceThree()
        {
            _value = 2;
            _choiceOneImage.color = _inactiveColor;
            _choiceTwoImage.color = _inactiveColor;
            _choiceThreeImage.color = Color.white;

            ValueChanged?.Invoke(_value);
        }
    }
}
