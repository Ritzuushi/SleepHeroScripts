using System;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio.Bedroom
{
    public class Rug : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _rugSprite;

        [SerializeField]
        private Sprite[] _rugSprites;

        public void SetRugLevel(int value)
        {
            _rugSprite.sprite = _rugSprites[value];
        }
    }
}
