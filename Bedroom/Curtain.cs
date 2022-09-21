using System;
using System.Collections.Generic;
using UnityEngine;
using RStudio.ShopSystem;

namespace RStudio.Bedroom
{
    public class Curtain : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] _curtainSprites;

        [SerializeField]
        private SpriteRenderer _curtainSprite;

        public void SetCurtainLevel(int bedLevel)
        {
            _curtainSprite.sprite = _curtainSprites[bedLevel];
        }
    }
}
