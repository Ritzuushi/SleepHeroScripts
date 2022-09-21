using System;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio.ShopSystem
{
    public class ShopUi : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _shopUi;

        private void Awake()
        {
            CloseShop();
        }

        public void OpenShop()
        {
            _shopUi.alpha = 1;
            _shopUi.interactable = true;
            _shopUi.blocksRaycasts = true;
        }

        public void CloseShop()
        {
            _shopUi.alpha = 0;
            _shopUi.interactable = false;
            _shopUi.blocksRaycasts = false;
        }
    }
}
