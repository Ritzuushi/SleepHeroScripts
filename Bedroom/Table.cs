using System;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio
{
    public class Table : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _tableSprite;

        [SerializeField]
        private Sprite[] _tableSprites;

        public void SetTableLevel(int value)
        {
            _tableSprite.sprite = _tableSprites[value];
        }
    }
}
