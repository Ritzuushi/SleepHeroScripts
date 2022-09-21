using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RStudio.CurrencySystem;

namespace RStudio.ShopSystem
{
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField]
        private Button _bedUpgradeBtn;
        [SerializeField]
        private Button _tableUpgradeBtn;
        [SerializeField]
        private Button _lampUpgradeBtn;
        [SerializeField]
        private Button _rugUpgradeBtn;
        [SerializeField]
        private Button _windowUpgradeBtn;
        [SerializeField]
        private Button _curtainUpgradeBtn;

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

        [SerializeReference]
        private TextMeshProUGUI _bedPrice;
        [SerializeReference]
        private TextMeshProUGUI _tablePrice;
        [SerializeReference]
        private TextMeshProUGUI _lampPrice;
        [SerializeReference]
        private TextMeshProUGUI _rugPrice;
        [SerializeReference]
        private TextMeshProUGUI _windowPrice;
        [SerializeReference]
        private TextMeshProUGUI _curtainPrice;

        [SerializeField]
        private ShopData _shopData;

        [SerializeField]
        private CurrencyData _currencyData;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _shopUpgradeSound;

        [SerializeField]
        private AudioClip _shopFailedUpgradeSound;

        private int[] _priceArray = { 499, 999, 0 };

        public void PlayShopUpgradeSound()
        {
            _audioSource.PlayOneShot(_shopUpgradeSound);
        }

        public void PlayShopFailedUpgradeSound()
        {
            _audioSource.PlayOneShot(_shopFailedUpgradeSound);
        }

        private void Awake()
        {
            SetCurrencyText();
            InitInteractables();
        }

        private void InitInteractables()
        {
            if (_shopData.BedMaxLevel == 2)
            {
                _bedUpgradeBtn.interactable = false;
            }

            if (_shopData.TableMaxLevel == 2)
            {
                _tableUpgradeBtn.interactable = false;
            }

            if (_shopData.LampMaxLevel == 2)
            {
                _lampUpgradeBtn.interactable = false;
            }

            if (_shopData.RugMaxLevel == 2)
            {
                _rugUpgradeBtn.interactable = false;
            }

            if (_shopData.WindowMaxLevel == 2)
            {
                _windowUpgradeBtn.interactable = false;
            }

            if (_shopData.CurtainMaxLevel == 2)
            {
                _curtainUpgradeBtn.interactable = false;
            }
        }

        private void SetCurrencyText()
        {
            _bedPrice.SetText(_priceArray[_shopData.BedLevel].ToString());
            _tablePrice.SetText(_priceArray[_shopData.TableLevel].ToString());
            _lampPrice.SetText(_priceArray[_shopData.LampLevel].ToString());
            _rugPrice.SetText(_priceArray[_shopData.RugLevel].ToString());
            _windowPrice.SetText(_priceArray[_shopData.WindowLevel].ToString());
            _curtainPrice.SetText(_priceArray[_shopData.CurtainLevel].ToString());
        }

        public void HandleBedUpgrade()
        {
            if (_shopData.BedMaxLevel == 0)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[0]))
                {
                    PlayShopUpgradeSound();

                    _currencyData.DecreaseCurrency(_priceArray[0]);

                    _shopData.BedMaxLevel++;
                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }
            else if (_shopData.BedMaxLevel == 1)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[1]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[1]);

                    _shopData.BedMaxLevel++;
                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }

            _bedContainer.SetLocks(_shopData.BedMaxLevel);
            _bedPrice.SetText(_priceArray[_shopData.BedMaxLevel].ToString());
        }
        public void HandleTableUpgrade()
        {
            if (_shopData.TableMaxLevel == 0)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[0]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[0]);

                    _shopData.TableMaxLevel++;
                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }
            else if (_shopData.TableMaxLevel == 1)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[1]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[1]);

                    _shopData.TableMaxLevel++;

                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }



            _tableContainer.SetLocks(_shopData.TableMaxLevel);
            _tablePrice.SetText(_priceArray[_shopData.TableMaxLevel].ToString());
        }
        public void HandleLampUpgrade()
        {
            if (_shopData.LampMaxLevel == 0)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[0]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[0]);

                    _shopData.LampMaxLevel++;
                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }
            else if (_shopData.LampMaxLevel == 1)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[1]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[1]);

                    _shopData.LampMaxLevel++;

                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }



            _lampContainer.SetLocks(_shopData.LampMaxLevel);
            _lampPrice.SetText(_priceArray[_shopData.LampMaxLevel].ToString());
        }
        public void HandleRugUpgrade()
        {
            if (_shopData.RugMaxLevel == 0)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[0]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[0]);

                    _shopData.RugMaxLevel++;
                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }
            else if (_shopData.RugMaxLevel == 1)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[1]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[1]);

                    _shopData.RugMaxLevel++;

                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }



            _rugContainer.SetLocks(_shopData.RugMaxLevel);
            _rugPrice.SetText(_priceArray[_shopData.RugMaxLevel].ToString());
        }
        public void HandleWindowUpgrade()
        {
            if (_shopData.WindowMaxLevel == 0)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[0]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[0]);

                    _shopData.WindowMaxLevel++;
                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }
            else if (_shopData.WindowMaxLevel == 1)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[1]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[1]);

                    _shopData.WindowMaxLevel++;

                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }



            _windowContainer.SetLocks(_shopData.WindowMaxLevel);
            _windowPrice.SetText(_priceArray[_shopData.WindowMaxLevel].ToString());
        }
        public void HandleCurtainUpgrade()
        {
            if (_shopData.CurtainMaxLevel == 0)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[0]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[0]);

                    _shopData.CurtainMaxLevel++;
                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }
            else if (_shopData.CurtainMaxLevel == 1)
            {
                if (_currencyData.IsEnoughCurrency(_priceArray[1]))
                {
                    PlayShopUpgradeSound();
                    _currencyData.DecreaseCurrency(_priceArray[1]);

                    _shopData.CurtainMaxLevel++;

                }
                else
                {
                    PlayShopFailedUpgradeSound();
                }
            }



            _curtainContainer.SetLocks(_shopData.CurtainMaxLevel);
            _curtainPrice.SetText(_priceArray[_shopData.CurtainMaxLevel].ToString());
        }
    }
}
